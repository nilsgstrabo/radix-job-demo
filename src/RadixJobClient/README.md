# RadixJobClient - the C# library for the Radix job scheduler server.

This is the API Server for the Radix job scheduler server.

This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 1.0.0
- SDK version: 1.0.0
- Generator version: 7.10.0
- Build package: org.openapitools.codegen.languages.CSharpClientCodegen
    For more information, please visit [https://equinor.slack.com/messages/CBKM6N2JY](https://equinor.slack.com/messages/CBKM6N2JY)

<a id="frameworks-supported"></a>
## Frameworks supported

<a id="dependencies"></a>
## Dependencies

- [RestSharp](https://www.nuget.org/packages/RestSharp) - 112.0.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 13.0.2 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742).
NOTE: RestSharp for .Net Core creates a new socket for each api call, which can lead to a socket exhaustion problem. See [RestSharp#1406](https://github.com/restsharp/RestSharp/issues/1406).

<a id="installation"></a>
## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;
```
<a id="packaging"></a>
## Packaging

A `.nuspec` is included with the project. You can follow the Nuget quickstart to [create](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-package) and [publish](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#publish-the-package) packages.

This `.nuspec` uses placeholders from the `.csproj`, so build the `.csproj` directly:

```
nuget pack -Build -OutputDirectory out RadixJobClient.csproj
```

Then, publish to a [local feed](https://docs.microsoft.com/en-us/nuget/hosting-packages/local-feeds) or [other host](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) and consume the new package via Nuget as usual.

<a id="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

<a id="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using RadixJobClient.Api;
using RadixJobClient.Client;
using RadixJobClient.Model;

namespace Example
{
    public class Example
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
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BatchApi.CreateBatch: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a id="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to */api/v1*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*BatchApi* | [**CreateBatch**](docs/BatchApi.md#createbatch) | **POST** /batches | Create batch
*BatchApi* | [**DeleteBatch**](docs/BatchApi.md#deletebatch) | **DELETE** /batches/{batchName} | Delete batch
*BatchApi* | [**GetBatch**](docs/BatchApi.md#getbatch) | **GET** /batches/{batchName} | Gets batch
*BatchApi* | [**GetBatchJob**](docs/BatchApi.md#getbatchjob) | **GET** /batches/{batchName}/jobs/{jobName} | Gets batch job
*BatchApi* | [**GetBatches**](docs/BatchApi.md#getbatches) | **GET** /batches/ | Gets batches
*BatchApi* | [**StopBatch**](docs/BatchApi.md#stopbatch) | **POST** /batches/{batchName}/stop | Stop batch
*BatchApi* | [**StopBatchJob**](docs/BatchApi.md#stopbatchjob) | **POST** /batches/{batchName}/jobs/{jobName}/stop | Stop batch job
*JobApi* | [**CreateJob**](docs/JobApi.md#createjob) | **POST** /jobs | Create job
*JobApi* | [**DeleteJob**](docs/JobApi.md#deletejob) | **DELETE** /jobs/{jobName} | Delete job
*JobApi* | [**GetJob**](docs/JobApi.md#getjob) | **GET** /jobs/{jobName} | Gets job
*JobApi* | [**GetJobs**](docs/JobApi.md#getjobs) | **GET** /jobs/ | Gets jobs
*JobApi* | [**StopJob**](docs/JobApi.md#stopjob) | **POST** /jobs/{jobName}/stop | Stop job


<a id="documentation-for-models"></a>
## Documentation for Models

 - [Model.BatchEvent](docs/BatchEvent.md)
 - [Model.BatchScheduleDescription](docs/BatchScheduleDescription.md)
 - [Model.BatchStatus](docs/BatchStatus.md)
 - [Model.FailurePolicy](docs/FailurePolicy.md)
 - [Model.FailurePolicyRule](docs/FailurePolicyRule.md)
 - [Model.FailurePolicyRuleOnExitCodes](docs/FailurePolicyRuleOnExitCodes.md)
 - [Model.JobScheduleDescription](docs/JobScheduleDescription.md)
 - [Model.JobStatus](docs/JobStatus.md)
 - [Model.Node](docs/Node.md)
 - [Model.PodStatus](docs/PodStatus.md)
 - [Model.RadixJobComponentConfig](docs/RadixJobComponentConfig.md)
 - [Model.ReplicaStatus](docs/ReplicaStatus.md)
 - [Model.Resources](docs/Resources.md)
 - [Model.Status](docs/Status.md)


<a id="documentation-for-authorization"></a>
## Documentation for Authorization

Endpoints do not require authorization.

