

using GitHubAPIDemo.Core.Models;

namespace GitHubAPIDemo.Core.Contracts
{
    public interface IGitHubRepository
    {
        Task<List<GitHubUserInfo>> GetUsersInfo(List<string> userNames);
        Task<GitHubUserInfo> GetUserInfo(string userName);
    }
}