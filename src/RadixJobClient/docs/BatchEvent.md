# RadixJobClient.Model.BatchEvent
BatchEvent holds general information about batch event on change of status

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BatchName** | **string** | BatchName Optional Batch ID of a job | [optional] 
**BatchType** | **string** | BatchType Single job or multiple jobs batch | [optional] 
**Created** | **string** | Created timestamp | 
**Ended** | **string** | Ended timestamp | [optional] 
**Event** | **string** |  | 
**JobId** | **string** | JobId Optional ID of a job | [optional] 
**JobStatuses** | [**List&lt;JobStatus&gt;**](JobStatus.md) | JobStatuses of the jobs in the batch | [optional] 
**Message** | **string** | Message, if any, of the job | [optional] 
**Name** | **string** | Name of the job | 
**Started** | **string** | Started timestamp | [optional] 
**Status** | **string** | Status of the job | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

