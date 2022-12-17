namespace GitHubAPIDemo.Core.Models
{
    public class GitHubUserInfo
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Company { get; set; }
        public int NumberOfFollowers { get; set; }
        public int NumberOfPublicRepositories { get; set; }
        public double AverageNumberOfFollowers { get; set; }
    }
}