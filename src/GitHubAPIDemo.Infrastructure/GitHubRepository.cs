using GitHubAPIDemo.Core.Contracts;
using GitHubAPIDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitHubAPIDemo.Infrastructure
{

    internal class GitHubRepository : IGitHubRepository
    {
        private readonly HttpClient _httpClient;

        public GitHubRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<GitHubUserInfo> GetUserInfo(string userName)
        {
           var data = await _httpClient.GetAsync($"https://api.github.com/users/{userName}");
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
