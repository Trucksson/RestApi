using RestApi.Models; //importera Github objektet
using RestApi.DTOs;
using RestApi.DTOs.GithubDtos; //importera Github DTO objektet
using System.Text.Json;

namespace RestApi.EndPoints
{
    public class GitHubEndPoints
    {
        private static readonly HttpClient httpClient = new();

        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/github/{användarnamn}", async (string username) =>
            {
                if (string.IsNullOrWhiteSpace(username))
                    return Results.BadRequest(new { message = "Användarnamn kan inte vara tomt." });

                try
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/users/{username}/repos");

                    requestMessage.Headers.UserAgent.ParseAdd("RestApi");
                        
                    var response = await httpClient.SendAsync(requestMessage);

                    if (!response.IsSuccessStatusCode)
                    {
                        return Results.Json(new { message = $"Github API retunerad {response.StatusCode}" }, statusCode: (int)response.StatusCode);
                    }

                    var content = await response.Content.ReadAsStringAsync();
                    var repositories = System.Text.Json.JsonSerializer.Deserialize<List<Github>>(content);

                    if (repositories == null || repositories.Count == 0)
                    {
                        return Results.NotFound(new { message = "No repos found XD" });
                    }

                    var repositoryList = repositories.Select(repo => new
                    {
                        Name = repo.RepostiryName,
                        Language = string.IsNullOrEmpty(repo.RepositoryLanguage) ? "Ingen information" : repo.RepositoryLanguage,
                        Description = string.IsNullOrEmpty(repo.RepositoryDescription) ? "Ingen information" : repo.RepositoryDescription,
                        Link = repo.RepositoryLink
                    }).ToList();

                    return Results.Ok(repositoryList);
                }

                /*TODO:
                 * Förbättra felhantering
                 * Kolla närmare på response.StatusCode
                 */

                catch (HttpRequestException ex)
                {
                    return Results.Problem(ex.Message);
                }
                catch (JsonException ex)
                {
                    return Results.Problem(ex.Message);
                }

            }).WithName("GetGitHubRepositories");
        }
    }
}
