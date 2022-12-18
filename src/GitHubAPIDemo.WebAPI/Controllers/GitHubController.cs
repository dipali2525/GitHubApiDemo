using GitHubAPIDemo.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GitHubAPIDemo.WebAPI.Controllers
{
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly GitHubService _gitHubService;
        private readonly ILogger<GitHubController> _logger;

        public GitHubController(GitHubService gitHubService, ILogger<GitHubController> logger)
        {
            this._gitHubService = gitHubService;
            this._logger = logger;
        }
        // POST api/<GitHubController>
        [HttpPost("retrieveUsers")]
        public async Task<IActionResult>  Post([FromBody] List<string> userNames)
        {
           var result = await _gitHubService.GetUsersInfo(userNames);
            _logger.LogInformation($"{string.Join(",",userNames)}");
            return Ok(result);
            
        }
    }
}
