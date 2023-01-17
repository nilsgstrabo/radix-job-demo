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
using Microsoft.AspNetCore.Builder;

public interface IComputeService
{
    Task<List<JobStatus>> GetJobs();
    Task<JobStatus> CreateJob(JobRequest request);
    Task<BatchStatus> CreateBatch(JobRequest request);

}

public class ComputePayload
{
    public int ImageId { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public MandelbrotCoord Top { get; set; }
    public MandelbrotCoord Bottom { get; set; }
    public int Sleep { get; set; }
    public bool Fail { get; set; }
    public string StringVal { get; set; }

}

public class ComputeService : IComputeService
{
    private readonly ILogger _logger;
    private readonly IJobApi _jobApi;
    private readonly IBatchApi _batchApi;

    public ComputeService(IJobApi jobApi, IBatchApi batchApi, ILogger<ComputeService> logger)
    {
        _logger = logger;
        _jobApi = jobApi;
        _batchApi = batchApi;
    }

    public async Task<List<JobStatus>> GetJobs()
    {
        return await _jobApi.GetJobsAsync();
    }

    public async Task<RadixJobClient.Model.JobStatus> CreateJob(JobRequest request)
    {
        var jobRequest = GetJobScheduleDescriptionFromJobRequest(request);
        
        _logger.LogInformation("JobRequest: {0}", request);
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
            case JobResourceEnum.TooLow:
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
            case JobResourceEnum.TooLow:
                cpuResource="1m";
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

    public async Task<BatchStatus> CreateBatch(JobRequest request)
    {
        var jobRequest = GetJobScheduleDescriptionFromJobRequest(request);

        var batchRequest=new BatchScheduleDescription(null, new List<JobScheduleDescription>{jobRequest});

        _logger.LogInformation("Payload: {0}", request);
        return await _batchApi.CreateBatchAsync(batchRequest);
    }

    private JobScheduleDescription GetJobScheduleDescriptionFromJobRequest(JobRequest request) {
        ComputePayload payloadObj = new ComputePayload
        {
            ImageId = request.ImageId,
            Width = 1050,
            Height = 600,
            Top = request.MandelbrotWindow.Top,
            Bottom = request.MandelbrotWindow.Bottom,
            Sleep = request.Sleep,
            Fail = request.Fail,
            StringVal = "my escaped \" string {}"
        };

        var payload = JsonSerializer.Serialize<ComputePayload>(payloadObj, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        
        JobScheduleDescription jobRequest = new JobScheduleDescription(){ Payload = payload };
        
        if (request.Cpu!=JobResourceEnum.Default || request.Memory!=JobResourceEnum.Default) {
            jobRequest.Resources=GetResources(request.Memory, request.Cpu);
        }

        return jobRequest;
    }
}