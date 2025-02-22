using WebAPIMarcaAutos.Models;

namespace WebAPIMarcaAutos.Services
{
    public interface IMarcasAutosService
    {
        Task<IEnumerable<MarcasAutos>> GetAllMarcasAutos();
    }
}
