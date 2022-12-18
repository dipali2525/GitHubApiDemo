namespace GitHubAPIDemo.Infrastructure
{
    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient httpClient;

        public GitHubClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> GetAsync(string apiURL)
        {
            return await httpClient.GetAsync(apiURL);
        }
    }
}
