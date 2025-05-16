using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.EndPoints; 


namespace RestApi.Data
{
    public class CVContext : DbContext
    {
        public CVContext(DbContextOptions<CVContext> options) : base(options) { }

        public DbSet<Person> Personer { get; set; }
        public DbSet<Utbildning> Utbildningar { get; set; }
        public DbSet<Arbetserfarenhet> Arbetserfarenheter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            CVContextSeeder.Seed(modelBuilder);
        }
    }
}
