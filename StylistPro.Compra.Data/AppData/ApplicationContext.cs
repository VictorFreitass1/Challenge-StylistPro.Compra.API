using Microsoft.EntityFrameworkCore;
using StylistPro.Compra.Domain.Entities;

namespace StylistPro.Compra.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {    

        }

        public DbSet<ComprasEntity> Compras { get; set; }
    }
}
