using Moq;
using StylistPro.Compra.Application.Services;
using StylistPro.Compra.Domain.Entities;
using StylistPro.Compra.Domain.Interfaces;
using StylistPro.Compra.Domain.Interfaces.Dtos;

namespace StylistPro.Compras.Tests
{
    public class ComprasApplicationServiceTests
    {
        private readonly Mock<IComprasRepository> _repositoryMock;

        private readonly ComprasApplicationService _comprasService;

        public ComprasApplicationServiceTests()
        {
            _repositoryMock = new Mock<IComprasRepository>();

            _comprasService = new ComprasApplicationService(_repositoryMock.Object);
        }

        [Fact]
        public void SalvarDadosCompras_DeveRetornarCompraEntity_QuandoAdicionarComSucesso()
        {
            // Arrange
            var compraDtoMock = new Mock<IComprasDto>();
            compraDtoMock.Setup(c => c.DataDaCompra).Returns(DateTime.Now);
            compraDtoMock.Setup(c => c.Status).Returns("Concluída");

            var compraEsperada = new ComprasEntity { DataDaCompra = DateTime.Now, Status = "Concluída" };

            _repositoryMock.Setup(r => r.SalvarDados(It.IsAny<ComprasEntity>())).Returns(compraEsperada);

            // Act
            var resultado = _comprasService.SalvarDadosCompras(compraDtoMock.Object);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(compraEsperada.DataDaCompra, resultado.DataDaCompra);
            Assert.Equal(compraEsperada.Status, resultado.Status);
        }

        [Fact]
        public void EditarDadosCompras_DeveRetornarCompraEntity_QuandoEditarComSucesso()
        {
            // Arrange
            var compraDtoMock = new Mock<IComprasDto>();
            compraDtoMock.Setup(c => c.DataDaCompra).Returns(DateTime.Now);
            compraDtoMock.Setup(c => c.Status).Returns("Pendente");

            var compraEsperada = new ComprasEntity { Id = 1, DataDaCompra = DateTime.Now, Status = "Pendente" };
            _repositoryMock.Setup(r => r.EditarDados(It.IsAny<ComprasEntity>())).Returns(compraEsperada);

            // Act
            var resultado = _comprasService.EditarDadosCompras(1, compraDtoMock.Object);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(compraEsperada.Id, resultado.Id);
            Assert.Equal(compraEsperada.DataDaCompra, resultado.DataDaCompra);
            Assert.Equal(compraEsperada.Status, resultado.Status);
        }

        [Fact]
        public void ObterComprasPorId_DeveRetornarCompraEntity_QuandoCompraExiste()
        {
            // Arrange
            var compraEsperada = new ComprasEntity { Id = 1, DataDaCompra = DateTime.Now, Status = "Aguardando" };
            _repositoryMock.Setup(r => r.ObterPorId(1)).Returns(compraEsperada);

            // Act
            var resultado = _comprasService.ObterComprasPorId (1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(compraEsperada.Id, resultado.Id);
            Assert.Equal(compraEsperada.DataDaCompra, resultado.DataDaCompra);
            Assert.Equal(compraEsperada.Status, resultado.Status);
        }

        [Fact]
        public void ObterTodasCompras_DeveRetornarListaDeCompras_QuandoExistiremCompras()
        {
            // Arrange
            var comprasEsperadas = new List<ComprasEntity>
            {
                new ComprasEntity { Id = 1, DataDaCompra = DateTime.Now, Status = "Finalizada" },
                new ComprasEntity { Id = 2, DataDaCompra = DateTime.Now.AddDays(-1), Status = "Em Processamento" }
            };
            _repositoryMock.Setup(r => r.ObterTodos()).Returns(comprasEsperadas);

            // Act
            var resultado = _comprasService.ObterTodasCompras();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
            Assert.Equal(comprasEsperadas.First().Status, resultado.First().Status);
        }

        [Fact]
        public void DeletarDadosCompras_DeveRetornarCompraEntity_QuandoRemoverComSucesso()
        {
            // Arrange
            var compraEsperada = new ComprasEntity { Id = 1, DataDaCompra = DateTime.Now, Status = "Cancelada" };
            _repositoryMock.Setup(r => r.DeletarDados(1)).Returns(compraEsperada);

            // Act
            var resultado = _comprasService.DeletarDadosCompras(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(compraEsperada.Id, resultado.Id);
            Assert.Equal(compraEsperada.DataDaCompra, resultado.DataDaCompra);
            Assert.Equal(compraEsperada.Status, resultado.Status);
        }
    }
}
