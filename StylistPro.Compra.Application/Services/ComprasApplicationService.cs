using StylistPro.Compra.Domain.Entities;
using StylistPro.Compra.Domain.Interfaces;
using StylistPro.Compra.Domain.Interfaces.Dtos;

namespace StylistPro.Compra.Application.Services
{
    public class ComprasApplicationService : IComprasApplicationService
    {
        private readonly IComprasRepository _comprasRepository;

        public ComprasApplicationService(IComprasRepository comprasRepository)
        {
            _comprasRepository = comprasRepository;
        }

        public ComprasEntity? DeletarDadosCompras(int id)
        {
            return _comprasRepository.DeletarDados(id);
        }

        public ComprasEntity? EditarDadosCompras(int id, IComprasDto entity)
        {
            entity.Validate();

            return _comprasRepository.EditarDados(new ComprasEntity
            {
                Id = id,
                DataDaCompra = entity.DataDaCompra,
                Status = entity.Status,
            });
        }

        public ComprasEntity? ObterComprasPorId(int id)
        {
            return _comprasRepository.ObterPorId(id);
        }

        public IEnumerable<ComprasEntity> ObterTodasCompras()
        {
            return _comprasRepository.ObterTodos();
        }

        public ComprasEntity? SalvarDadosCompras(IComprasDto entity)
        {
            entity.Validate();

            return _comprasRepository.SalvarDados(new ComprasEntity
            {
                DataDaCompra = entity.DataDaCompra,
                Status = entity.Status,
            });

        }
    }
}
