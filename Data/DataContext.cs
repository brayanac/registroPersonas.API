namespace registroPersonas.API.Data{
   
    using Microsoft.EntityFrameworkCore;
    using registroPersonas.API.Models;
    

    public class DataContext: DbContext 
    {
        public DbSet <Persona> Personas{get; set;}
    
    public DataContext(DbContextOptions<DataContext> options): base(options){
    }
    }
}