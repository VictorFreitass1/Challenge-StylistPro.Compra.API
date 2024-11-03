using StylistPro.Compra.Data.AppData;
using StylistPro.Compra.Domain.Entities;
using StylistPro.Compra.Domain.Interfaces;

namespace StylistPro.Compra.Data.Repositories
{
    public class ComprasRepository : IComprasRepository
    {
        private readonly ApplicationContext _context;

        public ComprasRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ComprasEntity? DeletarDados(int id)
        {
            var compra = _context.Compras.Find(id);

            if (compra is not null)
            {
                _context.Compras.Remove(compra);
                _context.SaveChanges();

                return compra;
            }

            return null;
        }

        public ComprasEntity? EditarDados(ComprasEntity entity)
        {
            var compra = _context.Compras.Find(entity.Id);

            if (compra is not null)
            {
                compra.DataDaCompra = entity.DataDaCompra;
                compra.Status = entity.Status;

                _context.Compras.Update(compra);
                _context.SaveChanges();

                return compra;
            }

            return null;
        }

        public ComprasEntity? ObterPorId(int id)
        {
            var compra = _context.Compras.Find(id);

            if (compra is not null)
            {
                return compra;
            }

            return null;
        }

        public IEnumerable<ComprasEntity> ObterTodos()
        {
            var compras = _context.Compras.ToList();
        
            return compras;
        }

        public ComprasEntity? SalvarDados(ComprasEntity entity)
        {
            _context.Compras.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
