using RestApi.Data;
using RestApi.DTOs.ArbetserfarenhetDtos;
using RestApi.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RestApi.EndPoints
{
    public class ArbetserfarenhetEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/arbetserfarenhet/{id}", async (CVContext context, int id) =>
            {
                if (id <= 0)
                {
                    return Results.BadRequest(new { message = "ID kan inte vara mindre än 1" });
                }

                try
                {
                    var arbetserfarenhet = await context.Arbetserfarenheter
                    .Where(a => a.ArbetserfarenhetID == id)
                    .Select(a => new ArbetserfarenhetDTO
                    {
                        Företag = a.Företag,
                        Jobbtitel = a.Jobbtitel,
                        Jobbbeskrivning = a.Jobbbeskrivning,
                        Jobbstart = a.Jobbstart,
                        Jobbslut = a.Jobbslut
                    })
                    .FirstOrDefaultAsync();


                    if (arbetserfarenhet == null)
                    {
                        return Results.NotFound(new { message = "Arbetserfarenhet inte hittad" });
                    }

                    return Results.Ok(arbetserfarenhet);

                }
                catch (Exception)
                {
                    return Results.Json("Ett fel inträffade när arbetserfarenhet skulle hämtas");

                }
            }).WithName("GetArbetserfarenhet efter Id");

            app.MapPost("/Arbetserfarenhet", async (CVContext context, ArbetserfarenhetCreateDTO newArebetserfarenhet) =>
            {
                if (newArebetserfarenhet == null)
                {
                    return Results.BadRequest(new { message = "Arbetserfarenhet kan inte vara null" });
                }

                try
                {
                    var validationContext = new ValidationContext(newArebetserfarenhet);
                    var validationResults = new List<ValidationResult>();
                    bool isValid = Validator.TryValidateObject(newArebetserfarenhet, validationContext, validationResults, true);

                    if (!isValid)
                    {
                        return Results.BadRequest(new { message = "Ogiltig data", errors = validationResults });
                    }


                    var person = await context.Personer.FindAsync(newArebetserfarenhet.PersonID);
                    if (person == null)
                    {
                        return Results.NotFound(new { message = "Person inte hittad" });
                    }

                    var arbetserfarenhet = new Arbetserfarenhet
                    {
                        Företag = newArebetserfarenhet.Företag,
                        Jobbtitel = newArebetserfarenhet.Jobbtitel,
                        Jobbbeskrivning = newArebetserfarenhet.Jobbbeskrivning,
                        Jobbstart = newArebetserfarenhet.Jobbstart,
                        Jobbslut = newArebetserfarenhet.Jobbslut,
                        PerosonID_FK = newArebetserfarenhet.PersonID
                    };

                    context.Arbetserfarenheter.Add(arbetserfarenhet);
                    await context.SaveChangesAsync();

                    return Results.Created($"/arbetserfarenhet/{arbetserfarenhet.ArbetserfarenhetID}", new { message = "Arbetserfarenhet skapad", arbetserfarenhet });

                }
                catch (Exception)
                {

                    return Results.Json("Ett fel inträffade när arbetserfarenhet skulle skapas");
                }

            });

            app.MapPut("/arbetserfarenhet/{id}", async (CVContext context, int id, ArbetserfarenhetPutDTO updatedArbetserfarenhet) =>
            {
                if (id <= 0)
                {
                    return Results.BadRequest(new { message = "ID kan inte vara mindre än 1" });
                }
                try
                {
                    var arbetserfarenhet = await context.Arbetserfarenheter.FindAsync(id);
                    if (arbetserfarenhet == null)
                    {
                        return Results.NotFound(new { message = "Arbetserfarenhet inte hittad" });
                    }
                    arbetserfarenhet.Företag = updatedArbetserfarenhet.Företag;
                    arbetserfarenhet.Jobbtitel = updatedArbetserfarenhet.Jobbtitel;
                    arbetserfarenhet.Jobbbeskrivning = updatedArbetserfarenhet.Jobbbeskrivning;
                    arbetserfarenhet.Jobbstart = updatedArbetserfarenhet.Jobbstart;
                    arbetserfarenhet.Jobbslut = updatedArbetserfarenhet.Jobbslut;
                    await context.SaveChangesAsync();
                    return Results.Ok(new { message = "Arbetserfarenhet uppdaterad", arbetserfarenhet });
                }
                catch (Exception)
                {
                    return Results.Json("Ett fel inträffade när arbetserfarenhet skulle uppdateras");
                }
            }).WithName("Uppdatera Arbetserfarenhet");


            app.MapPatch("/arbetserfarenhet/{id}", async (CVContext context, ArbetserfarenhetPatchDTO arbetserfarenhetDto, int id) =>
            {
                if (id <= 0)
                {
                    return Results.BadRequest(new { message = "ID kan inte vara mindre än 1" });
                }

                try
                {
                    var arbetserfarenhet = await context.Arbetserfarenheter
                    .FirstOrDefaultAsync(a => a.ArbetserfarenhetID == id);

                    if (arbetserfarenhet == null)
                    {
                        return Results.NotFound(new { message = "Arbetserfarenhet inte hittad" });
                    }

                    if (arbetserfarenhetDto.Företag != null)
                    {
                        arbetserfarenhet.Företag = arbetserfarenhetDto.Företag;
                    }
                    if (arbetserfarenhetDto.Jobbtitel != null)
                    {
                        arbetserfarenhet.Jobbtitel = arbetserfarenhetDto.Jobbtitel;
                    }
                    if (arbetserfarenhetDto.Jobbbeskrivning != null)
                    {
                        arbetserfarenhet.Jobbbeskrivning = arbetserfarenhetDto.Jobbbeskrivning;
                    }
                    if (arbetserfarenhetDto.Jobbstart != null)
                    {
                        arbetserfarenhet.Jobbstart = arbetserfarenhetDto.Jobbstart;
                    }
                    if (arbetserfarenhetDto.Jobbslut != null)
                    {
                        arbetserfarenhet.Jobbslut = arbetserfarenhetDto.Jobbslut;
                    }

                    await context.SaveChangesAsync();
                    return Results.AcceptedAtRoute("Hämta arbetserfarenhet efter ID", new { id = arbetserfarenhet.PerosonID_FK}, arbetserfarenhet);
                }
                catch (Exception)
                {
                    return Results.Json("Ett fel inträffade när arbetserfarenhet skulle uppdateras");

                }

            });


            app.MapDelete("/arbetserfarenhet/{id}", async (CVContext context, int id) =>
            {
                if (id <= 0)
                {
                    return Results.BadRequest(new { message = "ID kan inte vara mindre än 1" });
                }
                try
                {
                    var arbetserfarenhet = await context.Arbetserfarenheter.FindAsync(id);
                    if (arbetserfarenhet == null)
                    {
                        return Results.NotFound(new { message = "Arbetserfarenhet inte hittad" });
                    }
                    context.Arbetserfarenheter.Remove(arbetserfarenhet);
                    await context.SaveChangesAsync();
                    return Results.Ok(new { message = "Arbetserfarenhet borttagen" });
                }
                catch (Exception)
                {
                    return Results.Json("Ett fel inträffade när arbetserfarenhet skulle tas bort");
                }
            }).WithName("Ta bort Arbetserfarenhet");


        }
    }
}
