using WebAPIMarcaAutos.Models;

namespace WebAPIMarcaAutos.Repositories
{
    public interface IMarcasAutosRepository
    {
        public Task<IEnumerable<MarcasAutos>> GetAllMarcasAutos();
    }
}
