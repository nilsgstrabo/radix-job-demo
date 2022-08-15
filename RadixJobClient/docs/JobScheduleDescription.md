# RadixJobClient.Model.JobScheduleDescription
JobScheduleDescription holds description about scheduling job

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**JobId** | **string** | JobId Optional ID of a job | [optional] 
**Node** | [**RadixNode**](RadixNode.md) |  | [optional] 
**Payload** | **string** | Payload holding json data to be mapped to component | [optional] 
**Resources** | [**ResourceRequirements**](ResourceRequirements.md) |  | [optional] 
**TimeLimitSeconds** | **long** | TimeLimitSeconds defines maximum job run time. Corresponds to ActiveDeadlineSeconds in K8s. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

