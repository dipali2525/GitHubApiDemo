using System.Text.Json;
using System.Text.Json.Serialization;

namespace GitHubAPIDemo.Core.Models
{
    public class GitHubUserInfo
    {
        [JsonPropertyName("name")]

        public string Name { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("followers")]
        public int NumberOfFollowers { get; set; }

        [JsonPropertyName("public_repos")]
        public int NumberOfPublicRepositories { get; set; }
        public double AverageNumberOfFollowers => NumberOfPublicRepositories == 0 ? 0 :Math.Round(NumberOfFollowers / Convert.ToDouble( NumberOfPublicRepositories));
    }
}