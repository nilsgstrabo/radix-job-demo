# RadixJobClient.Api.JobApi

All URIs are relative to */api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateJob**](JobApi.md#createjob) | **POST** /jobs | Create job |
| [**DeleteJob**](JobApi.md#deletejob) | **DELETE** /jobs/{jobName} | Delete job |
| [**GetJob**](JobApi.md#getjob) | **GET** /jobs/{jobName} | Gets job |
| [**GetJobs**](JobApi.md#getjobs) | **GET** /jobs/ | Gets jobs |
| [**StopJob**](JobApi.md#stopjob) | **POST** /jobs/{jobName}/stop | Stop job |

<a id="createjob"></a>
# **CreateJob**
> JobStatus CreateJob (JobScheduleDescription jobCreation)

Create job

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class CreateJobExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new JobApi(config);
            var jobCreation = new JobScheduleDescription(); // JobScheduleDescription | Job to create

            try
            {
                // Create job
                JobStatus result = apiInstance.CreateJob(jobCreation);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JobApi.CreateJob: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateJobWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create job
    ApiResponse<JobStatus> response = apiInstance.CreateJobWithHttpInfo(jobCreation);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JobApi.CreateJobWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobCreation** | [**JobScheduleDescription**](JobScheduleDescription.md) | Job to create |  |

### Return type

[**JobStatus**](JobStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful create job |  -  |
| **400** | Bad request |  -  |
| **404** | Not found |  -  |
| **422** | Invalid data in request |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletejob"></a>
# **DeleteJob**
> Status DeleteJob (string jobName)

Delete job

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class DeleteJobExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new JobApi(config);
            var jobName = "jobName_example";  // string | Name of job

            try
            {
                // Delete job
                Status result = apiInstance.DeleteJob(jobName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JobApi.DeleteJob: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteJobWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete job
    ApiResponse<Status> response = apiInstance.DeleteJobWithHttpInfo(jobName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JobApi.DeleteJobWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobName** | **string** | Name of job |  |

### Return type

[**Status**](Status.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful delete job |  -  |
| **404** | Not found |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getjob"></a>
# **GetJob**
> JobStatus GetJob (string jobName)

Gets job

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class GetJobExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new JobApi(config);
            var jobName = "jobName_example";  // string | Name of job

            try
            {
                // Gets job
                JobStatus result = apiInstance.GetJob(jobName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JobApi.GetJob: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetJobWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Gets job
    ApiResponse<JobStatus> response = apiInstance.GetJobWithHttpInfo(jobName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JobApi.GetJobWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobName** | **string** | Name of job |  |

### Return type

[**JobStatus**](JobStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful get job |  -  |
| **404** | Not found |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getjobs"></a>
# **GetJobs**
> List&lt;JobStatus&gt; GetJobs ()

Gets jobs

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class GetJobsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new JobApi(config);

            try
            {
                // Gets jobs
                List<JobStatus> result = apiInstance.GetJobs();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JobApi.GetJobs: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetJobsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Gets jobs
    ApiResponse<List<JobStatus>> response = apiInstance.GetJobsWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JobApi.GetJobsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;JobStatus&gt;**](JobStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful get jobs |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="stopjob"></a>
# **StopJob**
> Status StopJob (string jobName)

Stop job

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class StopJobExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new JobApi(config);
            var jobName = "jobName_example";  // string | Name of job

            try
            {
                // Stop job
                Status result = apiInstance.StopJob(jobName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JobApi.StopJob: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StopJobWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Stop job
    ApiResponse<Status> response = apiInstance.StopJobWithHttpInfo(jobName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JobApi.StopJobWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobName** | **string** | Name of job |  |

### Return type

[**Status**](Status.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful delete job |  -  |
| **400** | Bad request |  -  |
| **404** | Not found |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

