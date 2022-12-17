namespace GitHubAPIDemo.Core.Unit.Test
{
    internal class GitHubService
    {
        public GitHubService()
        {
        }

        internal GitHubUserInfo GetUserData(string userName)
        {
            return new GitHubUserInfo();
        }
    }

    internal class GitHubUserInfo
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Company { get; set; }
        public int NumberOfFollowers { get; set; }
        public int NumberOfPublicRepositories { get; set; }
        public double AverageNumberOfFollowers { get; set; }
    }
}