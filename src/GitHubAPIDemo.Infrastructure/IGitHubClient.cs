namespace GitHubAPIDemo.Infrastructure
{
    public interface IGitHubClient
    {
         Task<HttpResponseMessage> GetAsync(string apiURL);
    }
}
