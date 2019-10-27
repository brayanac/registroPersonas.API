
    using Microsoft.EntityFrameworkCore;
    using registroPersonas.API.Models;
    
namespace registroPersonas.API.Data{
    public class DataContext: DbContext 
    {
        public DbSet <Persona> Personas{get; set;}
    
    public DataContext(DbContextOptions<DataContext> options): base(options){
    }
    }
}