# RadixJobClient.Api.BatchApi

All URIs are relative to *http://localhost/api/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateBatch**](BatchApi.md#createbatch) | **POST** /batches | Create batch
[**DeleteBatch**](BatchApi.md#deletebatch) | **DELETE** /batches/{batchName} | Delete batch
[**GetBatch**](BatchApi.md#getbatch) | **GET** /batches/{batchName} | Gets batch
[**GetBatches**](BatchApi.md#getbatches) | **GET** /batches/ | Gets batches


<a name="createbatch"></a>
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
            config.BasePath = "http://localhost/api/v1";
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
                Debug.Print("Exception when calling BatchApi.CreateBatch: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **batchCreation** | [**BatchScheduleDescription**](BatchScheduleDescription.md)| Batch to create | 

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

<a name="deletebatch"></a>
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
            config.BasePath = "http://localhost/api/v1";
            var apiInstance = new BatchApi(config);
            var batchName = batchName_example;  // string | Name of batch

            try
            {
                // Delete batch
                Status result = apiInstance.DeleteBatch(batchName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BatchApi.DeleteBatch: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **batchName** | **string**| Name of batch | 

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

<a name="getbatch"></a>
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
            config.BasePath = "http://localhost/api/v1";
            var apiInstance = new BatchApi(config);
            var batchName = batchName_example;  // string | Name of batch

            try
            {
                // Gets batch
                BatchStatus result = apiInstance.GetBatch(batchName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BatchApi.GetBatch: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **batchName** | **string**| Name of batch | 

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

<a name="getbatches"></a>
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
            config.BasePath = "http://localhost/api/v1";
            var apiInstance = new BatchApi(config);

            try
            {
                // Gets batches
                List<BatchStatus> result = apiInstance.GetBatches();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BatchApi.GetBatches: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
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

