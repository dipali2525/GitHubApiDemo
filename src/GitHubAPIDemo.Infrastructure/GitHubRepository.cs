using GitHubAPIDemo.Core.Contracts;
using GitHubAPIDemo.Core.Models;
using System.Text.Json;

namespace GitHubAPIDemo.Infrastructure
{

    public class GitHubRepository : IGitHubRepository
    {
        private readonly IGitHubClient _httpClient;

        public GitHubRepository(IGitHubClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<GitHubUserInfo> GetUserInfo(string userName)
        {
           var data = await _httpClient.GetAsync($"users/{userName}");
            if(data != null && data.IsSuccessStatusCode) {
                var dataContent = await data.Content.ReadAsStreamAsync();
                var userInfo = await JsonSerializer.DeserializeAsync<GitHubUserInfo>(dataContent);
                return userInfo;
            }
            return null;
        }

        public Task<List<GitHubUserInfo>> GetUsersInfo(List<string> userNames)
        {
            throw new NotImplementedException();
        }
    }
}
