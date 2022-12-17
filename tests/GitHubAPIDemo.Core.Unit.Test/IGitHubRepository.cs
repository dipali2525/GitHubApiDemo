namespace GitHubAPIDemo.Core.Unit.Test
{
    public interface IGitHubRepository
    {
        Task<List<GitHubUserInfo>> GetUsersInfo(List<string> userNames);
        Task<GitHubUserInfo> GetUserInfo(string userName);
    }
}