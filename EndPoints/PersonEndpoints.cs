using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.DTOs.PersonDtos;
using RestApi.DTOs.UtbildningDtos;
using RestApi.DTOs.ArbetserfarenhetDtos;
using RestApi.Models;
using System.ComponentModel.DataAnnotations;

namespace RestApi.EndPoints
{
    public static class PersonEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            // GET: Hämta alla personer med valfri filtrering
            app.MapGet("/person", async (CVContext context, string? namn, string? epost) =>
            {
                var query = context.Personer
                    .Include(p => p.Utbildningar)
                    .Include(p => p.Arbetserfarenheter)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(namn))
                    query = query.Where(p => p.Namn.ToLower().Contains(namn.ToLower()));

                if (!string.IsNullOrEmpty(epost))
                    query = query.Where(p => p.Epost.ToLower().Contains(epost.ToLower()));

                var personer = await query
                    .Select(p => new PersonListDTO
                    {
                        PersonId = p.PersonId,
                        namn = p.Namn,
                        Mobilnummer = p.Mobilnummer,
                        Epost = p.Epost,
                        Beskrivning = p.Beskrivning,
                        Utbildningar = p.Utbildningar.Select(u => new UtbildningDTO
                        {
                            Skola = u.Skola,
                            UtbildningExamen = u.UtbildningExamen,
                            UtbildningStart = u.UtbildningStart,
                            UtbildningSlut = u.UtbildningSlut
                        }).ToList(),
                        Arbetserfarenheter = p.Arbetserfarenheter.Select(a => new ArbetserfarenhetDTO
                        {
                            Företag = a.Företag,
                            Jobbtitel = a.Jobbtitel,
                            Jobbbeskrivning = a.Jobbbeskrivning,
                            Jobbstart = a.Jobbstart,
                            Jobbslut = a.Jobbslut
                        }).ToList()
                    })
                    .ToListAsync();

                return Results.Ok(personer);
            });

            // GET: Hämta detaljerad informatio om en person
            app.MapGet("/person/{id}/details", async (CVContext context, int id) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new { message = "Ogiltigt ID." });

                var person = await context.Personer
                    .Include(p => p.Utbildningar)
                    .Include(p => p.Arbetserfarenheter)
                    .Where(p => p.PersonId == id)
                    .Select(p => new PersonWithDetailsDTO
                    {
                        namn = p.Namn,
                        Mobilnummer = p.Mobilnummer,
                        Epost = p.Epost,
                        Beskrivning = p.Beskrivning,
                        Utbildningar = p.Utbildningar.Select(u => new UtbildningDTO
                        {
                            Skola = u.Skola,
                            UtbildningExamen = u.UtbildningExamen,
                            UtbildningStart = u.UtbildningStart,
                            UtbildningSlut = u.UtbildningSlut
                        }).ToList(),
                        Arbetserfarenheter = p.Arbetserfarenheter.Select(a => new ArbetserfarenhetDTO
                        {
                            Företag = a.Företag,
                            Jobbtitel = a.Jobbtitel,
                            Jobbbeskrivning = a.Jobbbeskrivning,
                            Jobbstart = a.Jobbstart,
                            Jobbslut = a.Jobbslut
                        }).ToList()
                    })
                    .SingleOrDefaultAsync();

                return person == null
                    ? Results.NotFound(new { message = "Person hittades inte." })
                    : Results.Ok(person);
            });

            // GET: Hämta en person
            app.MapGet("/person/{id}", async (CVContext context, int id) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new { message = "Ogiltigt ID." });

                var person = await context.Personer
                    .Where(p => p.PersonId == id)
                    .Select(p => new PersonDTO
                    {
                        namn = p.Namn,
                        Mobilnummer = p.Mobilnummer,
                        Epost = p.Epost,
                        Beskrivning = p.Beskrivning
                    })
                    .SingleOrDefaultAsync();

                return person == null
                    ? Results.NotFound(new { message = "Person hittades inte." })
                    : Results.Ok(person);
            });

            // POST: Skapa ny person
            app.MapPost("/person", async (CVContext context, PersonCreateDTO dto) =>
            {
                var validationContext = new ValidationContext(dto);
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(dto, validationContext, validationResults, true))
                    return Results.BadRequest(validationResults.Select(v => v.ErrorMessage));

                var person = new Person
                {
                    Namn = dto.namn,
                    Mobilnummer = dto.Mobilnummer,
                    Epost = dto.Epost,
                    Beskrivning = dto.Beskrivning
                };

                context.Personer.Add(person);
                await context.SaveChangesAsync();

                return Results.Created($"/person/{person.PersonId}", new { message = "Person skapad." });
            });

            // PUT: Uppdatera hela personen
            app.MapPut("/person/{id}", async (CVContext context, PersonPutDTO dto, int id) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new { message = "Ogiltigt ID." });

                var person = await context.Personer.FirstOrDefaultAsync(p => p.PersonId == id);
                if (person == null)
                    return Results.NotFound(new { message = "Person hittades inte." });

                var validationContext = new ValidationContext(dto);
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(dto, validationContext, validationResults, true))
                    return Results.BadRequest(validationResults.Select(v => v.ErrorMessage));

                person.Namn = dto.namn;
                person.Mobilnummer = dto.Mobilnummer;
                person.Epost = dto.Epost;
                person.Beskrivning = dto.Beskrivning;

                await context.SaveChangesAsync();

                return Results.Ok(new { message = "Person uppdaterad." });
            });

            // PATCH: Uppdatera del av personen .
            app.MapPatch("/person/{id}", async (CVContext context, PersonPatchDTO dto, int id) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new { message = "Ogiltigt ID." });

                var person = await context.Personer.FirstOrDefaultAsync(p => p.PersonId == id);
                if (person == null)
                    return Results.NotFound(new { message = "Person hittades inte." });

                if (dto.namn != null) person.Namn = dto.namn;
                if (dto.Mobilnummer != null) person.Mobilnummer = dto.Mobilnummer;
                if (dto.Epost != null) person.Epost = dto.Epost;
                if (dto.Beskrivning != null) person.Beskrivning = dto.Beskrivning;

                await context.SaveChangesAsync();
                return Results.Ok(new { message = "Person delvis uppdaterad." });
            });

            // DELETE: Ta bort person
            app.MapDelete("/person/{id}", async (CVContext context, int id) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new { message = "Ogiltigt ID." });

                var person = await context.Personer.FirstOrDefaultAsync(p => p.PersonId == id);
                if (person == null)
                    return Results.NotFound(new { message = "Person hittades inte." });

                context.Personer.Remove(person);
                await context.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}