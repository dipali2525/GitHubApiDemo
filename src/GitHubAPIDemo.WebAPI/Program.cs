using GitHubAPIDemo.Core.Contracts;
using GitHubAPIDemo.Core.Services;
using GitHubAPIDemo.Infrastructure;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
      .AddJsonOptions(options =>
                    options.JsonSerializerOptions.PropertyNamingPolicy
                     = JsonNamingPolicy.CamelCase); ;
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
    _httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "HttpRequestsSample");
    _httpClient.DefaultRequestHeaders.Add(HeaderNames.Authorization, "Bearer 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");
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
