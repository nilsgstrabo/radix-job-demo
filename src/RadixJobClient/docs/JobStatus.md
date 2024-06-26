# RadixJobClient.Model.JobStatus
JobStatus holds general information about job status

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BatchName** | **string** | BatchName Optional Batch ID of a job | [optional] 
**Created** | **string** | Created timestamp | 
**Ended** | **string** | Ended timestamp | [optional] 
**JobId** | **string** | JobId Optional ID of a job | [optional] 
**Message** | **string** | Message, if any, of the job | [optional] 
**Name** | **string** | Name of the job | 
**PodStatuses** | [**List&lt;PodStatus&gt;**](PodStatus.md) | PodStatuses for each pod of the job | [optional] 
**Started** | **string** | Started timestamp | [optional] 
**Status** | **string** | Status of the job | [optional] 
**Updated** | **string** | Updated timestamp when the status was updated | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

