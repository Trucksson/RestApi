// Imports
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.DTOs.UtbildningDtos;
using RestApi.Models;
using System.ComponentModel.DataAnnotations;

namespace RestApi.EndPoints
{
    public static class UtbildningEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            // GET hämtar utbildning
            app.MapGet("/utbildning/{id}", async (CVContext context, int id) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new { message = "Ogiltigt ID." });

                var utbildning = await context.Utbildningar
                    .Where(e => e.UtbildningID == id)
                    .Select(e => new UtbildningDTO
                    {
                        Skola = e.Skola,
                        UtbildningExamen = e.UtbildningExamen,
                        UtbildningStart = e.UtbildningStart,
                        UtbildningSlut = e.UtbildningSlut
                    })
                    .SingleOrDefaultAsync();

                return utbildning == null
                    ? Results.NotFound(new { message = "Utbildning hittades inte." })
                    : Results.Ok(utbildning);
            });

            // Post
            app.MapPost("/utbildning", async (CVContext context, UtbildningCreateDTO dto) =>
            {
                var validationContext = new ValidationContext(dto);
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(dto, validationContext, validationResults, true))
                    return Results.BadRequest(validationResults.Select(v => v.ErrorMessage));

                var utbildning = new Utbildning
                {
                    Skola = dto.Skola,
                    UtbildningExamen = dto.UtbildningExamen,
                    UtbildningBeskrivning = dto.UtbildningBeskrivning,
                    UtbildningStart = dto.UtbildningStart,
                    UtbildningSlut = dto.UtbildningSlut,
                    PersonId_FK = dto.PersonId
                };

                context.Utbildningar.Add(utbildning);
                await context.SaveChangesAsync();

                return Results.Created($"/utbildning/{utbildning.UtbildningID}", new { message = "Utbildning skapad." });
            });

            // Put för utbildning 
            app.MapPut("/utbildning/{id}", async (CVContext context, UtbildningPutDTO dto, int id) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new { message = "Ogiltigt ID." });

                var utbildning = await context.Utbildningar.FirstOrDefaultAsync(e => e.UtbildningID == id);
                if (utbildning == null)
                    return Results.NotFound(new { message = "Utbildning hittades inte." });

                var validationContext = new ValidationContext(dto);
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(dto, validationContext, validationResults, true))
                    return Results.BadRequest(validationResults.Select(v => v.ErrorMessage));

                utbildning.Skola = dto.Skola;
                utbildning.UtbildningExamen = dto.UtbildningExamen;
                utbildning.UtbildningStart = dto.UtbildningStart;
                utbildning.UtbildningSlut = dto.UtbildningSlut;

                await context.SaveChangesAsync();

                return Results.Ok(new { message = "Utbildning uppdaterad." });
            });

            // Patch för utblidningen
            app.MapPatch("/utbildning/{id}", async (CVContext context, UtbildningPatchDTO dto, int id) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new { message = "Ogiltigt ID." });

                var utbildning = await context.Utbildningar.FirstOrDefaultAsync(e => e.UtbildningID == id);
                if (utbildning == null)
                    return Results.NotFound(new { message = "Utbildning hittades inte." });

                if (dto.Skola != null) utbildning.Skola = dto.Skola;
                if (dto.UtbildningExamen != null) utbildning.UtbildningExamen = dto.UtbildningExamen;
                if (dto.UtbildningStart.HasValue) utbildning.UtbildningStart = dto.UtbildningStart.Value;
                if (dto.UtbildningSlut.HasValue) utbildning.UtbildningSlut = dto.UtbildningSlut.Value;

                await context.SaveChangesAsync();
                return Results.Ok(new { message = "Utbildning delvis uppdaterad." });
            });

            // DELETE: Ta bort utbildning
            app.MapDelete("/utbildning/{id}", async (CVContext context, int id) =>
            {
                if (id <= 0)
                    return Results.BadRequest(new { message = "Ogiltigt ID." });

                var utbildning = await context.Utbildningar.FirstOrDefaultAsync(e => e.UtbildningID == id);
                if (utbildning == null)
                    return Results.NotFound(new { message = "Utbildning hittades inte." });

                context.Utbildningar.Remove(utbildning);
                await context.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}