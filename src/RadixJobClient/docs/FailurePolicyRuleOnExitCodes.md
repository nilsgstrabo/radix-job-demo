# RadixJobClient.Model.FailurePolicyRuleOnExitCodes
FailurePolicyRuleOnExitCodes describes the requirement for handling a failed job replica based on its exit code.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Operator** | **string** | Represents the relationship between the job replica&#39;s exit code and the specified values. Replicas completed with success (exit code 0) are excluded from the requirement check. In FailurePolicyRuleOnExitCodesOpIn  The requirement is satisfied if the job replica&#39;s exit code is in the set of specified values. NotIn FailurePolicyRuleOnExitCodesOpNotIn  The requirement is satisfied if the job replica&#39;s exit code is not in the set of specified values. | 
**Values** | **List&lt;int&gt;** | Specifies the set of values. The job replica&#39;s exit code is checked against this set of values with respect to the operator. The list must not contain duplicates. Value &#39;0&#39; cannot be used for the In operator. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

