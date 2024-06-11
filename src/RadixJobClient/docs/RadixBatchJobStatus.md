# RadixJobClient.Model.RadixBatchJobStatus
RadixBatchJobStatus holds general information about batch job status

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreationTime** | **string** | Radix batch job creation timestamp | 
**Ended** | **string** | Ended timestamp | [optional] 
**JobId** | **string** | JobId Optional ID of a job | [optional] 
**Message** | **string** | Status message, if any, of the job | [optional] 
**Name** | **string** | Name of the Radix batch job | 
**PodStatuses** | [**List&lt;RadixBatchJobPodStatus&gt;**](RadixBatchJobPodStatus.md) | PodStatuses for each pod of the job | [optional] 
**Started** | **string** | Started timestamp | [optional] 
**Status** | **string** | Status of the job | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

