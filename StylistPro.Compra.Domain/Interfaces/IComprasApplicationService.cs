using StylistPro.Compra.Domain.Entities;
using StylistPro.Compra.Domain.Interfaces.Dtos;

namespace StylistPro.Compra.Domain.Interfaces
{
    public interface IComprasApplicationService
    {
        IEnumerable<ComprasEntity> ObterTodasCompras();
        ComprasEntity? ObterComprasPorId(int id);
        ComprasEntity? SalvarDadosCompras(IComprasDto entity);
        ComprasEntity? EditarDadosCompras(int id, IComprasDto entity);
        ComprasEntity? DeletarDadosCompras(int id);

    }
}