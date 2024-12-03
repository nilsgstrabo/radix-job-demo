/*
 * Radix job scheduler server.
 *
 * This is the API Server for the Radix job scheduler server.
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using RadixJobServer.Converters;

namespace RadixJobServer.Models
{ 
    /// <summary>
    /// JobStatus holds general information about job status
    /// </summary>
    [DataContract]
    public partial class JobStatus : IEquatable<JobStatus>
    {
        /// <summary>
        /// DeploymentName for this batch
        /// </summary>
        /// <value>DeploymentName for this batch</value>
        [DataMember(Name="DeploymentName", EmitDefaultValue=false)]
        public string DeploymentName { get; set; }

        /// <summary>
        /// Defines a user defined ID of the batch.
        /// </summary>
        /// <value>Defines a user defined ID of the batch.</value>
        [DataMember(Name="batchId", EmitDefaultValue=false)]
        public string BatchId { get; set; }

        /// <summary>
        /// BatchName Optional Batch ID of a job
        /// </summary>
        /// <value>BatchName Optional Batch ID of a job</value>
        [DataMember(Name="batchName", EmitDefaultValue=false)]
        public string BatchName { get; set; }

        /// <summary>
        /// Created timestamp
        /// </summary>
        /// <value>Created timestamp</value>
        [Required]
        [DataMember(Name="created", EmitDefaultValue=false)]
        public string Created { get; set; }

        /// <summary>
        /// Ended timestamp
        /// </summary>
        /// <value>Ended timestamp</value>
        [DataMember(Name="ended", EmitDefaultValue=false)]
        public string Ended { get; set; }

        /// <summary>
        /// The number of times the container for the job has failed. +optional
        /// </summary>
        /// <value>The number of times the container for the job has failed. +optional</value>
        [DataMember(Name="failed", EmitDefaultValue=false)]
        public int Failed { get; set; }

        /// <summary>
        /// JobId Optional ID of a job
        /// </summary>
        /// <value>JobId Optional ID of a job</value>
        [DataMember(Name="jobId", EmitDefaultValue=false)]
        public string JobId { get; set; }

        /// <summary>
        /// Message, if any, of the job
        /// </summary>
        /// <value>Message, if any, of the job</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }

        /// <summary>
        /// Name of the job
        /// </summary>
        /// <value>Name of the job</value>
        [Required]
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// PodStatuses for each pod of the job
        /// </summary>
        /// <value>PodStatuses for each pod of the job</value>
        [DataMember(Name="podStatuses", EmitDefaultValue=false)]
        public List<PodStatus> PodStatuses { get; set; }

        /// <summary>
        /// Timestamp of the job restart, if applied. +optional
        /// </summary>
        /// <value>Timestamp of the job restart, if applied. +optional</value>
        [DataMember(Name="restart", EmitDefaultValue=false)]
        public string Restart { get; set; }

        /// <summary>
        /// Started timestamp
        /// </summary>
        /// <value>Started timestamp</value>
        [DataMember(Name="started", EmitDefaultValue=false)]
        public string Started { get; set; }


        /// <summary>
        /// Status of the job Running = Job is running Succeeded = Job has succeeded Failed = Job has failed Waiting = Job is waiting Stopping = Job is stopping Stopped = Job has been stopped Active = Job is active Completed = Job is completed
        /// </summary>
        /// <value>Status of the job Running = Job is running Succeeded = Job has succeeded Failed = Job has failed Waiting = Job is waiting Stopping = Job is stopping Stopped = Job has been stopped Active = Job is active Completed = Job is completed</value>
        [TypeConverter(typeof(CustomEnumConverter<StatusEnum>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum StatusEnum
        {
            
            /// <summary>
            /// Enum RunningEnum for Running
            /// </summary>
            [EnumMember(Value = "Running")]
            RunningEnum = 1,
            
            /// <summary>
            /// Enum SucceededEnum for Succeeded
            /// </summary>
            [EnumMember(Value = "Succeeded")]
            SucceededEnum = 2,
            
            /// <summary>
            /// Enum FailedEnum for Failed
            /// </summary>
            [EnumMember(Value = "Failed")]
            FailedEnum = 3,
            
            /// <summary>
            /// Enum WaitingEnum for Waiting
            /// </summary>
            [EnumMember(Value = "Waiting")]
            WaitingEnum = 4,
            
            /// <summary>
            /// Enum StoppingEnum for Stopping
            /// </summary>
            [EnumMember(Value = "Stopping")]
            StoppingEnum = 5,
            
            /// <summary>
            /// Enum StoppedEnum for Stopped
            /// </summary>
            [EnumMember(Value = "Stopped")]
            StoppedEnum = 6,
            
            /// <summary>
            /// Enum ActiveEnum for Active
            /// </summary>
            [EnumMember(Value = "Active")]
            ActiveEnum = 7,
            
            /// <summary>
            /// Enum CompletedEnum for Completed
            /// </summary>
            [EnumMember(Value = "Completed")]
            CompletedEnum = 8
        }

        /// <summary>
        /// Status of the job Running &#x3D; Job is running Succeeded &#x3D; Job has succeeded Failed &#x3D; Job has failed Waiting &#x3D; Job is waiting Stopping &#x3D; Job is stopping Stopped &#x3D; Job has been stopped Active &#x3D; Job is active Completed &#x3D; Job is completed
        /// </summary>
        /// <value>Status of the job Running &#x3D; Job is running Succeeded &#x3D; Job has succeeded Failed &#x3D; Job has failed Waiting &#x3D; Job is waiting Stopping &#x3D; Job is stopping Stopped &#x3D; Job has been stopped Active &#x3D; Job is active Completed &#x3D; Job is completed</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Updated timestamp when the status was updated
        /// </summary>
        /// <value>Updated timestamp when the status was updated</value>
        [DataMember(Name="updated", EmitDefaultValue=false)]
        public string Updated { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JobStatus {\n");
            sb.Append("  DeploymentName: ").Append(DeploymentName).Append("\n");
            sb.Append("  BatchId: ").Append(BatchId).Append("\n");
            sb.Append("  BatchName: ").Append(BatchName).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Ended: ").Append(Ended).Append("\n");
            sb.Append("  Failed: ").Append(Failed).Append("\n");
            sb.Append("  JobId: ").Append(JobId).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PodStatuses: ").Append(PodStatuses).Append("\n");
            sb.Append("  Restart: ").Append(Restart).Append("\n");
            sb.Append("  Started: ").Append(Started).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Updated: ").Append(Updated).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((JobStatus)obj);
        }

        /// <summary>
        /// Returns true if JobStatus instances are equal
        /// </summary>
        /// <param name="other">Instance of JobStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(JobStatus other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    DeploymentName == other.DeploymentName ||
                    DeploymentName != null &&
                    DeploymentName.Equals(other.DeploymentName)
                ) && 
                (
                    BatchId == other.BatchId ||
                    BatchId != null &&
                    BatchId.Equals(other.BatchId)
                ) && 
                (
                    BatchName == other.BatchName ||
                    BatchName != null &&
                    BatchName.Equals(other.BatchName)
                ) && 
                (
                    Created == other.Created ||
                    Created != null &&
                    Created.Equals(other.Created)
                ) && 
                (
                    Ended == other.Ended ||
                    Ended != null &&
                    Ended.Equals(other.Ended)
                ) && 
                (
                    Failed == other.Failed ||
                    
                    Failed.Equals(other.Failed)
                ) && 
                (
                    JobId == other.JobId ||
                    JobId != null &&
                    JobId.Equals(other.JobId)
                ) && 
                (
                    Message == other.Message ||
                    Message != null &&
                    Message.Equals(other.Message)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    PodStatuses == other.PodStatuses ||
                    PodStatuses != null &&
                    other.PodStatuses != null &&
                    PodStatuses.SequenceEqual(other.PodStatuses)
                ) && 
                (
                    Restart == other.Restart ||
                    Restart != null &&
                    Restart.Equals(other.Restart)
                ) && 
                (
                    Started == other.Started ||
                    Started != null &&
                    Started.Equals(other.Started)
                ) && 
                (
                    Status == other.Status ||
                    
                    Status.Equals(other.Status)
                ) && 
                (
                    Updated == other.Updated ||
                    Updated != null &&
                    Updated.Equals(other.Updated)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (DeploymentName != null)
                    hashCode = hashCode * 59 + DeploymentName.GetHashCode();
                    if (BatchId != null)
                    hashCode = hashCode * 59 + BatchId.GetHashCode();
                    if (BatchName != null)
                    hashCode = hashCode * 59 + BatchName.GetHashCode();
                    if (Created != null)
                    hashCode = hashCode * 59 + Created.GetHashCode();
                    if (Ended != null)
                    hashCode = hashCode * 59 + Ended.GetHashCode();
                    
                    hashCode = hashCode * 59 + Failed.GetHashCode();
                    if (JobId != null)
                    hashCode = hashCode * 59 + JobId.GetHashCode();
                    if (Message != null)
                    hashCode = hashCode * 59 + Message.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (PodStatuses != null)
                    hashCode = hashCode * 59 + PodStatuses.GetHashCode();
                    if (Restart != null)
                    hashCode = hashCode * 59 + Restart.GetHashCode();
                    if (Started != null)
                    hashCode = hashCode * 59 + Started.GetHashCode();
                    
                    hashCode = hashCode * 59 + Status.GetHashCode();
                    if (Updated != null)
                    hashCode = hashCode * 59 + Updated.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(JobStatus left, JobStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(JobStatus left, JobStatus right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
