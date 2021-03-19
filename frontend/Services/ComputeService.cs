using System.IO;
using System.Net.Http;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

public interface IComputeService
{
    Task GetJobs();

}

public class ComputeService : IComputeService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public ComputeService(HttpClient httpClient, ILogger<ComputeService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task GetJobs()
    {
        var result=await _httpClient.GetAsync("/api/v1/jobs");
        _logger.LogInformation(0, result.StatusCode.ToString());
    }

}