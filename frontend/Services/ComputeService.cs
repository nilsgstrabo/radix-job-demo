using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using frontend.Controllers;
using System.Net.Http.Json;
using System.Text.Json;
using RadixJobClient.Api;
using RadixJobClient.Model;
using System.Collections.Generic;
using System.Runtime.Versioning;

// public class JobStatus
// {
//     public string Name { get; set; }
//     public string Started { get; set; }
//     public string Ended { get; set; }
//     public string Status { get; set; }
// }



public interface IComputeService
{
    Task<List<JobStatus>> GetJobs();
    Task<JobStatus> CreateJob(JobRequest request);

}

// public class ComputeRequest
// {
//     public string Payload { get; set; }
//     public JobResourceRequirements Resources { get; set; }
// }

public class ComputePayload
{
    public int ImageId { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public MandelbrotCoord Top { get; set; }
    public MandelbrotCoord Bottom { get; set; }

}

// public class Resource
// {
//     public string Cpu { get; set; }
//     public string Memory { get; set; }
// }

// public class JobResourceRequirements
// {
//     public Resource Requests { get; set; }
//     public Resource Limits { get; set; }
// }

public class ComputeService : IComputeService
{
    private readonly ILogger _logger;
    private readonly IJobApi _jobApi;

    public ComputeService(IJobApi jobApi, ILogger<ComputeService> logger)
    {
        _logger = logger;
        _jobApi = jobApi;
    }

    public async Task<List<JobStatus>> GetJobs()
    {
        return await _jobApi.GetJobsAsync();
    }

    public async Task<RadixJobClient.Model.JobStatus> CreateJob(JobRequest request)
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
        
        JobScheduleDescription jobRequest = new JobScheduleDescription(){ Payload = payload };
        
        if (request.Cpu!=JobResourceEnum.Default || request.Memory!=JobResourceEnum.Default) {
            jobRequest.Resources=GetResources(request.Memory, request.Cpu);
        }

        _logger.LogInformation("Payload: {0}", payload);
        return await _jobApi.CreateJobAsync(jobRequest);
    }

    private RadixJobClient.Model.ResourceRequirements GetResources(JobResourceEnum memory, JobResourceEnum cpu) {
        string memResource="";
        string cpuResource="";

        switch(memory) {
            case JobResourceEnum.High:
                memResource="1000Mi";
                break;
            case JobResourceEnum.Medium:
                memResource="500Mi";
                break;
            case JobResourceEnum.Low:
                memResource="100Mi";
                break;
            case JobResourceEnum.VeryLow:
                memResource="1Mi";
                break;
        }

        switch(cpu) {
            case JobResourceEnum.High:
                cpuResource="1";
                break;
            case JobResourceEnum.Medium:
                cpuResource="500m";
                break;
            case JobResourceEnum.Low:
                cpuResource="100m";
                break;
        }

        var resource = new Dictionary<string, string>();
       
        if(memResource!="") {
            resource.Add("memory", memResource);
        }

        if(cpuResource!="") {
            resource.Add("cpu", cpuResource);
        }

        return new RadixJobClient.Model.ResourceRequirements() {
            Requests=resource,
            Limits=resource
        };
    }
}