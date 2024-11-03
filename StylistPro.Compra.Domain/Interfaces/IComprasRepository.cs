using StylistPro.Compra.Domain.Entities;

namespace StylistPro.Compra.Domain.Interfaces
{
    public interface IComprasRepository
    {
        IEnumerable<ComprasEntity> ObterTodos();
        ComprasEntity? ObterPorId(int id);
        ComprasEntity? SalvarDados(ComprasEntity entity);
        ComprasEntity? EditarDados(ComprasEntity entity);
        ComprasEntity? DeletarDados(int id);

    }
}