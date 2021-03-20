using System.Net.Cache;
using System.IO;
using System.Net.Http;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using frontend.Controllers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

public class JobStatus {
    public string Name {get;set;}
    public string Started {get;set;}
    public string Ended {get;set;}
    public string Status {get;set;}
}

public interface IComputeService
{
    Task GetJobs();
    Task<JobStatus> CreateJob(ComputeRequest request);

}

public class ComputePayload {
    public ComputeRequest Payload {get;set;}
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
        try
        {
            var result = await _httpClient.GetAsync("/api/v1/jobs");
            _logger.LogInformation(0, result.StatusCode.ToString());
        }
        catch (Exception ex)
        {
            _logger.LogError(0, ex, ex.Message);
        }

    }

    public async Task<JobStatus> CreateJob(ComputeRequest request)
    {
        try
        {
            ComputePayload payload=new ComputePayload {Payload=request};
            var result = await _httpClient.PostAsJsonAsync("/api/v1/jobs", payload);
            result.EnsureSuccessStatusCode();
            _logger.LogInformation(0, result.StatusCode.ToString());
            var job=await result.Content.ReadFromJsonAsync<JobStatus>();
            return job;
        }
        catch (Exception ex)
        {
            _logger.LogError(0, ex, ex.Message);
            throw;
        }

    }

}