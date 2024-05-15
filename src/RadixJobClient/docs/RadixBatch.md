# RadixJobClient.Model.RadixBatch
RadixBatch holds general information about batch status

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BatchType** | **string** | BatchType Single job or multiple jobs batch | 
**CreationTime** | **string** | Radix batch creation timestamp | 
**Ended** | **string** | Ended timestamp | [optional] 
**JobStatuses** | [**List&lt;RadixBatchJobStatus&gt;**](RadixBatchJobStatus.md) | JobStatuses of the Radix batch jobs | [optional] 
**Message** | **string** | Status message, if any, of the job | [optional] 
**Name** | **string** | Name of the Radix batch | 
**Started** | **string** | Started timestamp | [optional] 
**Status** | **string** | Status of the job | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

