# RadixJobClient.Model.FailurePolicy

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Rules** | [**List&lt;FailurePolicyRule&gt;**](FailurePolicyRule.md) | A list of failure policy rules. The rules are evaluated in order. Once a rule matches a job replica failure, the remaining of the rules are ignored. When no rule matches the failure, the default handling applies - the counter of failures is incremented and it is checked against the backoffLimit. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

