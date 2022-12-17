using GitHubAPIDemo.Core.Contracts;
using GitHubAPIDemo.Core.Models;

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
            var users = new List<GitHubUserInfo>();
            var distinctUserNames = userNames.Distinct();
            foreach (var userName in distinctUserNames)
            {
                var user = await _gitHubRepository.GetUserInfo(userName);

                if (user is not null)
                    users.Add(user);
            }

            return users.OrderBy(u => u.Name).ToList();
        }
    }
}