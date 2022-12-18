using GitHubAPIDemo.Core.Contracts;
using GitHubAPIDemo.Core.Models;
using System.Diagnostics;

namespace GitHubAPIDemo.Core.Services
{
    public class GitHubService
    {
        private readonly IGitHubRepository _gitHubRepository;

        public GitHubService(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository = gitHubRepository;
        }

        public async Task<List<GitHubUserInfo>> GetUsersInfo(List<string> userNames)
        {
            var distinctUserNames = userNames.Distinct().ToAsyncEnumerable();

            var userlist = distinctUserNames.SelectAwait(async username => await  _gitHubRepository.GetUserInfo(username))
                .Where(t => t is not null);
            var users = await userlist.OrderBy(t => t.Name).ToListAsync();
            return users;
        }
    }
}