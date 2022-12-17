namespace GitHubAPIDemo.Core.Unit.Test
{
    internal class GitHubService
    {
        private readonly IGitHubRepository _gitHubRepository;

        public GitHubService(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository = gitHubRepository;
        }

        internal async Task<List<GitHubUserInfo>> GetUsersInfo(List<string> userNames)
        {
            var users = new List<GitHubUserInfo>();
            var distinctUserNames = userNames.Distinct();
            foreach (var userName in distinctUserNames)
            {
                var user = await _gitHubRepository.GetUserInfo(userName);

                if(user is not null)
                    users.Add(user);
            }

            return users.OrderBy(u => u.Name).ToList();
        }
    }

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