using InfrastructureTemplate.Application.Interfaces;
using InfrastructureTemplate.Context;
using InfrastructureTemplate.DTOs;
using InfrastructureTemplate.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignsBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _Context;

        public UsuarioController(IUnitOfWork unitOfWork, AppDbContext Context)
        {
            _unitOfWork = unitOfWork;
            _Context = Context;
        }

        [HttpPost]

        public async Task<IActionResult> CreateUser (UserCreateDto dto)
        {
            var user = new Users
            {
                UserName = dto.Username,
                email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                RoleId = dto.RoleId

            };
            _Context.Users.Add(user);
            await _Context.SaveChangesAsync();

            return Ok("Usuario Creado");
            

        }

       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllUsers()
        {
            var users = await _Context.Users
                .Include(u => u.Roles)
                .Select(u => new UserReadDto
                {
                    Id = u.RoleId,
                    Username = u.UserName,
                    Email = u.email,
                    RoleName = u.Roles.Role
                })
                .ToListAsync();

            return Ok(users);
        }
        }
}
