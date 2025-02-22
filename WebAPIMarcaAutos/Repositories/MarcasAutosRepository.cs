using Microsoft.EntityFrameworkCore;
using WebAPIMarcaAutos.Config;
using WebAPIMarcaAutos.Models;

namespace WebAPIMarcaAutos.Repositories
{
    public class MarcasAutosRepository : IMarcasAutosRepository
    {
        private readonly AppDbContext _context;

        public MarcasAutosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MarcasAutos>> GetAllMarcasAutos()
        {
            return await _context.MarcasAutos.ToListAsync();
        }
    }
}
