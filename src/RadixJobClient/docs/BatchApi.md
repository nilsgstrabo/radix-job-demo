# RadixJobClient.Api.BatchApi

All URIs are relative to */api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateBatch**](BatchApi.md#createbatch) | **POST** /batches | Create batch |
| [**DeleteBatch**](BatchApi.md#deletebatch) | **DELETE** /batches/{batchName} | Delete batch |
| [**GetBatch**](BatchApi.md#getbatch) | **GET** /batches/{batchName} | Gets batch |
| [**GetBatchJob**](BatchApi.md#getbatchjob) | **GET** /batches/{batchName}/jobs/{jobName} | Gets batch job |
| [**GetBatches**](BatchApi.md#getbatches) | **GET** /batches/ | Gets batches |
| [**StopBatch**](BatchApi.md#stopbatch) | **POST** /batches/{batchName}/stop | Stop batch |
| [**StopBatchJob**](BatchApi.md#stopbatchjob) | **POST** /batches/{batchName}/jobs/{jobName}/stop | Stop batch job |

<a id="createbatch"></a>
# **CreateBatch**
> BatchStatus CreateBatch (BatchScheduleDescription batchCreation)

Create batch

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class CreateBatchExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new BatchApi(config);
            var batchCreation = new BatchScheduleDescription(); // BatchScheduleDescription | Batch to create

            try
            {
                // Create batch
                BatchStatus result = apiInstance.CreateBatch(batchCreation);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BatchApi.CreateBatch: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateBatchWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create batch
    ApiResponse<BatchStatus> response = apiInstance.CreateBatchWithHttpInfo(batchCreation);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BatchApi.CreateBatchWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **batchCreation** | [**BatchScheduleDescription**](BatchScheduleDescription.md) | Batch to create |  |

### Return type

[**BatchStatus**](BatchStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful create batch |  -  |
| **400** | Bad request |  -  |
| **404** | Not found |  -  |
| **422** | Invalid data in request |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletebatch"></a>
# **DeleteBatch**
> Status DeleteBatch (string batchName)

Delete batch

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class DeleteBatchExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new BatchApi(config);
            var batchName = "batchName_example";  // string | Name of batch

            try
            {
                // Delete batch
                Status result = apiInstance.DeleteBatch(batchName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BatchApi.DeleteBatch: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteBatchWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete batch
    ApiResponse<Status> response = apiInstance.DeleteBatchWithHttpInfo(batchName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BatchApi.DeleteBatchWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **batchName** | **string** | Name of batch |  |

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
| **200** | Successful delete batch |  -  |
| **404** | Not found |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getbatch"></a>
# **GetBatch**
> BatchStatus GetBatch (string batchName)

Gets batch

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class GetBatchExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new BatchApi(config);
            var batchName = "batchName_example";  // string | Name of batch

            try
            {
                // Gets batch
                BatchStatus result = apiInstance.GetBatch(batchName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BatchApi.GetBatch: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetBatchWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Gets batch
    ApiResponse<BatchStatus> response = apiInstance.GetBatchWithHttpInfo(batchName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BatchApi.GetBatchWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **batchName** | **string** | Name of batch |  |

### Return type

[**BatchStatus**](BatchStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful get batch |  -  |
| **404** | Not found |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getbatchjob"></a>
# **GetBatchJob**
> JobStatus GetBatchJob (string batchName, string jobName)

Gets batch job

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class GetBatchJobExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new BatchApi(config);
            var batchName = "batchName_example";  // string | Name of batch
            var jobName = "jobName_example";  // string | Name of job

            try
            {
                // Gets batch job
                JobStatus result = apiInstance.GetBatchJob(batchName, jobName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BatchApi.GetBatchJob: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetBatchJobWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Gets batch job
    ApiResponse<JobStatus> response = apiInstance.GetBatchJobWithHttpInfo(batchName, jobName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BatchApi.GetBatchJobWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **batchName** | **string** | Name of batch |  |
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

<a id="getbatches"></a>
# **GetBatches**
> List&lt;BatchStatus&gt; GetBatches ()

Gets batches

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class GetBatchesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new BatchApi(config);

            try
            {
                // Gets batches
                List<BatchStatus> result = apiInstance.GetBatches();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BatchApi.GetBatches: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetBatchesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Gets batches
    ApiResponse<List<BatchStatus>> response = apiInstance.GetBatchesWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BatchApi.GetBatchesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;BatchStatus&gt;**](BatchStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful get batches |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="stopbatch"></a>
# **StopBatch**
> Status StopBatch (string batchName)

Stop batch

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class StopBatchExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new BatchApi(config);
            var batchName = "batchName_example";  // string | Name of batch

            try
            {
                // Stop batch
                Status result = apiInstance.StopBatch(batchName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BatchApi.StopBatch: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StopBatchWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Stop batch
    ApiResponse<Status> response = apiInstance.StopBatchWithHttpInfo(batchName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BatchApi.StopBatchWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **batchName** | **string** | Name of batch |  |

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
| **200** | Successful stop batch |  -  |
| **400** | Bad request |  -  |
| **404** | Not found |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="stopbatchjob"></a>
# **StopBatchJob**
> Status StopBatchJob (string batchName, string jobName)

Stop batch job

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class StopBatchJobExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "/api/v1";
            var apiInstance = new BatchApi(config);
            var batchName = "batchName_example";  // string | Name of batch
            var jobName = "jobName_example";  // string | Name of job

            try
            {
                // Stop batch job
                Status result = apiInstance.StopBatchJob(batchName, jobName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BatchApi.StopBatchJob: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StopBatchJobWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Stop batch job
    ApiResponse<Status> response = apiInstance.StopBatchJobWithHttpInfo(batchName, jobName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BatchApi.StopBatchJobWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **batchName** | **string** | Name of batch |  |
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
| **200** | Successful stop batch job |  -  |
| **400** | Bad request |  -  |
| **404** | Not found |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

