# RadixJobClient.Model.PodStatus

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ContainerStarted** | **DateTimeOffset** | Container started timestamp | [optional] 
**Created** | **DateTimeOffset** | Created timestamp | [optional] 
**EndTime** | **DateTimeOffset** | The time at which the batch job&#39;s pod finishedAt. | [optional] 
**ExitCode** | **int** | Exit status from the last termination of the container | [optional] 
**Image** | **string** | The image the container is running. | [optional] 
**ImageId** | **string** | ImageID of the container&#39;s image. | [optional] 
**Name** | **string** | Pod name | 
**PodIndex** | **long** | The index of the pod in the re-starts | [optional] 
**Reason** | **string** | A brief CamelCase message indicating details about why the job is in this phase | [optional] 
**ReplicaStatus** | [**ReplicaStatus**](ReplicaStatus.md) |  | [optional] 
**RestartCount** | **int** | RestartCount count of restarts of a component container inside a pod | [optional] 
**StartTime** | **DateTimeOffset** | The time at which the batch job&#39;s pod startedAt | [optional] 
**StatusMessage** | **string** | StatusMessage provides message describing the status of a component container inside a pod | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

