using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPIMarcaAutos.Controllers;
using WebAPIMarcaAutos.Models;
using WebAPIMarcaAutos.Repositories;
using WebAPIMarcaAutos.Services;
using Xunit;

namespace TestUnitarios
{
    public class MarcasAutosTests
    {
        private readonly Mock<IMarcasAutosRepository> _marcasAutosRepositoryMock;
        private readonly Mock<IMarcasAutosService> _marcasAutosServiceMock;
        private readonly MarcasAutosController _controller;

        public MarcasAutosTests()
        {
            // Mock de la dependencia del repositorio
            _marcasAutosRepositoryMock = new Mock<IMarcasAutosRepository>();
            // Mock del servicio
            _marcasAutosServiceMock = new Mock<IMarcasAutosService>();
            // Controlador con el servicio mockeado
            _controller = new MarcasAutosController(_marcasAutosServiceMock.Object);
        }

        [Fact]
        public async Task GetAllMarcasAutos_ReturnsListOfMarcasAutos()
        {
            var marcasAutos = new List<MarcasAutos>
            {
                new MarcasAutos { Id = 1, Nombre = "Toyota" },
                new MarcasAutos { Id = 2, Nombre = "Ford" }
            };

            // Configuramos el mock del servicio 
            _marcasAutosRepositoryMock
                .Setup(repo => repo.GetAllMarcasAutos())
                .ReturnsAsync(marcasAutos);

            var marcasAutosService = new MarcasAutosService(_marcasAutosRepositoryMock.Object);

            var result = await marcasAutosService.GetAllMarcasAutos();

            Assert.NotNull(result);
            Assert.Contains(result, m => m.Nombre == "Toyota");
            Assert.Contains(result, m => m.Nombre == "Ford");
        }

        [Fact]
        public async Task GetMarcasAutos_ReturnsOkResult_WithListOfMarcasAutos()
        {
            var marcasAutos = new List<MarcasAutos>
            {
                new MarcasAutos { Id = 1, Nombre = "Toyota" },
                new MarcasAutos { Id = 2, Nombre = "Ford" }
            };

            // Configuramos el mock del servicio
            _marcasAutosServiceMock
                .Setup(service => service.GetAllMarcasAutos())
                .ReturnsAsync(marcasAutos);

            var result = await _controller.GetMarcasAutos();

            var actionResult = Assert.IsType<OkObjectResult>(result.Result);

            var returnValue = Assert.IsAssignableFrom<IEnumerable<MarcasAutos>>(actionResult.Value);

            Assert.Equal(2, returnValue.Count());
            Assert.Contains(returnValue, m => m.Nombre == "Toyota");
            Assert.Contains(returnValue, m => m.Nombre == "Ford");
        }
    }
}
