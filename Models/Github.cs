using System.Text.Json.Serialization;

namespace RestApi.Models
{
    public class Github
    {
        [JsonPropertyName("name")]
        public int RepostiryName { get; set; }
        [JsonPropertyName("language")]
        public string RepositoryLanguage { get; set; }
        [JsonPropertyName("description")]
        public string RepositoryDescription { get; set; }
        [JsonPropertyName("html_url")]
        public string RepositoryLink { get; set; }

        

    }
}
