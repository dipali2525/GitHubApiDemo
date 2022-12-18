using GitHubAPIDemo.Core.Contracts;
using GitHubAPIDemo.Core.Services;
using GitHubAPIDemo.Infrastructure;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGitHubRepository, GitHubRepository>();
builder.Services.AddScoped<GitHubService>();
builder.Services.AddHttpClient<IGitHubClient, GitHubClient>(_httpClient =>
{
    _httpClient.BaseAddress = new Uri("https://api.github.com/");
    _httpClient.DefaultRequestHeaders.Add(
         HeaderNames.Accept, "application/vnd.github.v3+json");
    _httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent,"request");
    _httpClient.DefaultRequestHeaders.Add(
        "X-GitHub-Api-Version", "2022-11-28");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
