# RadixJobClient.Model.JobStatus
JobStatus holds general information about job status

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DeploymentName** | **string** | DeploymentName for this batch | [optional] 
**BatchId** | **string** | Defines a user defined ID of the batch. | [optional] 
**BatchName** | **string** | BatchName Optional Batch ID of a job | [optional] 
**Created** | **DateTimeOffset** | Created timestamp | [optional] 
**Ended** | **DateTimeOffset** | Ended timestamp | [optional] 
**Failed** | **int** | The number of times the container for the job has failed. +optional | [optional] 
**JobId** | **string** | JobId Optional ID of a job | [optional] 
**Message** | **string** | Message, if any, of the job | [optional] 
**Name** | **string** | Name of the job | 
**PodStatuses** | [**List&lt;PodStatus&gt;**](PodStatus.md) | PodStatuses for each pod of the job | [optional] 
**Restart** | **string** | Timestamp of the job restart, if applied. +optional | [optional] 
**Started** | **DateTimeOffset** | Started timestamp | [optional] 
**Status** | **string** | Status of the job Running &#x3D; Job is running Succeeded &#x3D; Job has succeeded Failed &#x3D; Job has failed Waiting &#x3D; Job is waiting Stopping &#x3D; Job is stopping Stopped &#x3D; Job has been stopped Active &#x3D; Job is active Completed &#x3D; Job is completed | [optional] 
**Updated** | **DateTimeOffset** | Updated timestamp when the status was updated | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

