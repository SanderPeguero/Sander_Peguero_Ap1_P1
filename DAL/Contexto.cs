using Microsoft.EntityFrameworkCore;
using Sander_Peguero_Ap1_P1.Entidades;

public class Contexto:DbContext{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        
        optionsBuilder.UseSqlite(@"Data Source=Data\Libros.db");

    }
}