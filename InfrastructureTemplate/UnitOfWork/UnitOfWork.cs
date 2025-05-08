using InfrastructureTemplate.Application.Interfaces;
using InfrastructureTemplate.Context;
using InfrastructureTemplate.Model;
using InfrastructureTemplate.Repository;
using System.Threading.Tasks;

namespace InfrastructureTemplate.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGenericRepository<Users> _usuarioRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Users> UsuarioRepository =>
            _usuarioRepository = new GenericRepository<Users>(_context);

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
