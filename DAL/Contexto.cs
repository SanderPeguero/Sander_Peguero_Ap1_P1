using Microsoft.EntityFrameworkCore;
using Sander_Peguero_Ap1_P1.Producto;

namespace Sander_Peguero_Ap1.Entidades{

    public class Contexto:DbContext{

        public DbSet<Producto> producto { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            
            optionsBuilder.UseSqlite(@"Data Source=Data\Productos.db");

        }
    }

}