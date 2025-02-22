using WebAPIMarcaAutos.Models;
using WebAPIMarcaAutos.Repositories;

namespace WebAPIMarcaAutos.Services
{
    public class MarcasAutosService : IMarcasAutosService
    {
        private readonly IMarcasAutosRepository _marcasAutosRepository;

        public MarcasAutosService(IMarcasAutosRepository marcasAutosRepository)
        {
            _marcasAutosRepository = marcasAutosRepository;
        }

        public async Task<IEnumerable<MarcasAutos>> GetAllMarcasAutos()
        {
            return await _marcasAutosRepository.GetAllMarcasAutos();
        }
    }
}
