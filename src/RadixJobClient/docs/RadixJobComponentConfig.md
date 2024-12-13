# RadixJobClient.Model.RadixJobComponentConfig
RadixJobComponentConfig holds description of RadixJobComponent

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BackoffLimit** | **int** | BackoffLimit defines attempts to restart job if it fails. Corresponds to BackoffLimit in K8s. | [optional] 
**FailurePolicy** | [**FailurePolicy**](FailurePolicy.md) |  | [optional] 
**ImageTagName** | **string** | ImageTagName defines the image tag name to use for the job image | [optional] 
**Node** | [**Node**](Node.md) |  | [optional] 
**Resources** | [**Resources**](Resources.md) |  | [optional] 
**TimeLimitSeconds** | **long** | TimeLimitSeconds defines maximum job run time. Corresponds to ActiveDeadlineSeconds in K8s. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

