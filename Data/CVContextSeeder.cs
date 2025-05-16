using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.EndPoints // Nu kanske
{
    public static class CVContextSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    Namn = "Henric Test",
                    Mobilnummer = "0701234567",
                    Epost = "henric@test.se",
                    Beskrivning = "Test"
                }
            );

            modelBuilder.Entity<Utbildning>().HasData(
                new Utbildning
                {
                    UtbildningID = 1,
                    Skola = "Cool.se",
                    UtbildningExamen = "Test",
                    UtbildningBeskrivning = "Test",
                    UtbildningStart = new DateOnly(2020, 8, 15),
                    UtbildningSlut = new DateOnly(2023, 6, 5),
                    PersonId_FK = 1
                }
            );

            modelBuilder.Entity<Arbetserfarenhet>().HasData(
                new Arbetserfarenhet
                {
                    ArbetserfarenhetID = 1,
                    Företag = "BigBoi AB",
                    Jobbtitel = "Utvecklare",
                    Jobbbeskrivning = ".NET och databaser",
                    Jobbstart = new DateOnly(2023, 9, 1),
                    Jobbslut = new DateOnly(2024, 3, 31),
                    PersonId_FK = 1
                }
            );
        }
    }
}
