using InfrastructureTemplate.Application.Interfaces;
using InfrastructureTemplate.Context;
using InfrastructureTemplate.DTOs;
using InfrastructureTemplate.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace SignsBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _Context;

        public RoleController(IUnitOfWork unitOfWork, AppDbContext Context)
        {
            _unitOfWork = unitOfWork;
            _Context = Context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
            var roles = await _Context.Roles.ToListAsync();
            return Ok(roles);
        }
    }
}
