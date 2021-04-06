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
using System.Text.Json;

public class JobStatus
{
    public string Name { get; set; }
    public string Started { get; set; }
    public string Ended { get; set; }
    public string Status { get; set; }
}



public interface IComputeService
{
    Task<JobStatus[]> GetJobs();
    Task<JobStatus> CreateJob(JobRequest request);

}

public class ComputeRequest
{
    public string Payload { get; set; }
}

public class ComputePayload
{
    public int ImageId { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public MandelbrotCoord Top { get; set; }
    public MandelbrotCoord Bottom { get; set; }

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

    public async Task<JobStatus[]> GetJobs()
    {
        try
        {
        var result = await _httpClient.GetFromJsonAsync<JobStatus[]>("/api/v1/jobs",new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return result;    
        }
        catch (System.Exception ex)
        {
            
            throw;
        }
        
    }

    public async Task<JobStatus> CreateJob(JobRequest request)
    {
        ComputePayload payloadObj = new ComputePayload
        {
            ImageId = request.ImageId,
            Width = 1050,
            Height = 600,
            Top = request.MandelbrotWindow.Top,
            Bottom = request.MandelbrotWindow.Bottom
        };

        var payload = JsonSerializer.Serialize<ComputePayload>(payloadObj, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        ComputeRequest computePayload = new ComputeRequest { Payload = payload };
        _logger.LogInformation("Payload: {0}", computePayload);
        var result = await _httpClient.PostAsJsonAsync("/api/v1/jobs", computePayload);
        result.EnsureSuccessStatusCode();
        _logger.LogInformation(0, result.StatusCode.ToString());
        var job = await result.Content.ReadFromJsonAsync<JobStatus>();
        return job;
    }

}