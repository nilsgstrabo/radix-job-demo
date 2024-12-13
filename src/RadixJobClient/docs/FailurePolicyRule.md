# RadixJobClient.Model.FailurePolicyRule

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Action** | **string** | Specifies the action taken on a job replica failure when the onExitCodes requirements are satisfied. FailJob FailurePolicyRuleActionFailJob  This is an action which might be taken on a job replica failure - mark the  job as Failed and terminate all running pods. Ignore FailurePolicyRuleActionIgnore  This is an action which might be taken on a job replica failure - the counter towards  .backoffLimit is not incremented and a replacement replica is created. Count FailurePolicyRuleActionCount  This is an action which might be taken on a job replica failure - the replica failure  is handled in the default way - the counter towards .backoffLimit is incremented. | 
**OnExitCodes** | [**FailurePolicyRuleOnExitCodes**](FailurePolicyRuleOnExitCodes.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

