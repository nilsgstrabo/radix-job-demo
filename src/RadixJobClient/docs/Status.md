# RadixJobClient.Model.Status
Status is a return value for calls that don't return other objects or when a request returns an error

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Code** | **long** | Suggested HTTP return code for this status, 0 if not set. | [optional] 
**Message** | **string** | A human-readable description of the status of this operation. | [optional] 
**Reason** | **string** |  | [optional] 
**VarStatus** | **string** | Status of the operation. One of: \&quot;Success\&quot; or \&quot;Failure\&quot;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

