using StylistPro.Compra.Data.AppData;
using StylistPro.Compra.Data.Repositories;
using StylistPro.Compra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StylistPro.Compras.Tests
{
    public class ComprasRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly ComprasRepository _comprasRepository;

        public ComprasRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationContext(_options);
            _comprasRepository = new ComprasRepository(_context);
        }

        [Fact]
        public void SalvarDados_DeveAdicionarCompraERetornarCompraEntity()
        {
            // Arrange
            var compra = new ComprasEntity { DataDaCompra = DateTime.Now, Status = "Concluída" };

            // Act
            var resultado = _comprasRepository.SalvarDados(compra);

            // Assert
            var compraNoDb = _context.Compras.FirstOrDefault(c => c.Id == resultado.Id);
            Assert.NotNull(compraNoDb);
            Assert.Equal(compra.DataDaCompra, compraNoDb.DataDaCompra);
            Assert.Equal(compra.Status, compraNoDb.Status);
        }

        [Fact]
        public void EditarDados_DeveAtualizarCompraERetornarCompraEntity_QuandoCompraExiste()
        {
            // Arrange
            var compra = new ComprasEntity { DataDaCompra = DateTime.Now, Status = "Pendente" };
            _context.Compras.Add(compra);
            _context.SaveChanges();

            compra.Status = "Concluída";

            // Act
            var resultado = _comprasRepository.EditarDados(compra);

            // Assert
            var compraNoDb = _context.Compras.FirstOrDefault(c => c.Id == compra.Id);
            Assert.NotNull(compraNoDb);
            Assert.Equal("Concluída", compraNoDb.Status);
        }

        [Fact]
        public void ObterPorId_DeveRetornarCompraEntity_QuandoCompraExiste()
        {
            // Arrange
            var compra = new ComprasEntity { DataDaCompra = DateTime.Now, Status = "Aguardando" };
            _context.Compras.Add(compra);
            _context.SaveChanges();

            // Act
            var resultado = _comprasRepository.ObterPorId(compra.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(compra.Id, resultado.Id);
            Assert.Equal(compra.DataDaCompra, resultado.DataDaCompra);
            Assert.Equal(compra.Status, resultado.Status);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeCompras_QuandoExistiremCompras()
        {
            // Arrange
            _context.Compras.RemoveRange(_context.Compras);
            _context.SaveChanges();

            var compras = new List<ComprasEntity>
            {
                new ComprasEntity { DataDaCompra = DateTime.Now, Status = "Finalizada" },
                new ComprasEntity { DataDaCompra = DateTime.Now.AddDays(-1), Status = "Em Processamento" }
            };
            _context.Compras.AddRange(compras);
            _context.SaveChanges();

            // Act
            var resultado = _comprasRepository.ObterTodos();

            // Assert
            Assert.Equal(compras.Count, resultado.Count());
            Assert.Contains(resultado, c => c.Status == "Finalizada");
            Assert.Contains(resultado, c => c.Status == "Em Processamento");
        }

        [Fact]
        public void DeletarDados_DeveRemoverCompraRetornarCompraEntity_QuandoCompraExiste()
        {
            // Arrange
            var compra = new ComprasEntity { DataDaCompra = DateTime.Now, Status = "Cancelada" };
            _context.Compras.Add(compra);
            _context.SaveChanges();

            // Act
            var resultado = _comprasRepository.DeletarDados(compra.Id);

            // Assert
            var compraNoDb = _context.Compras.FirstOrDefault(c => c.Id == compra.Id);

            Assert.Null(compraNoDb);
            Assert.Equal(compra, resultado);
        }
    }
}
