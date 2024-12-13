/*
 * Radix job scheduler server.
 *
 * This is the API Server for the Radix job scheduler server.
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = RadixJobClient.Client.OpenAPIDateConverter;

namespace RadixJobClient.Model
{
    /// <summary>
    /// BatchEvent holds general information about batch event on change of status
    /// </summary>
    [DataContract(Name = "BatchEvent")]
    public partial class BatchEvent : IValidatableObject
    {
        /// <summary>
        /// Status of the job Running &#x3D; Job is running Succeeded &#x3D; Job has succeeded Failed &#x3D; Job has failed Waiting &#x3D; Job is waiting Stopping &#x3D; Job is stopping Stopped &#x3D; Job has been stopped Active &#x3D; Job is active Completed &#x3D; Job is completed
        /// </summary>
        /// <value>Status of the job Running &#x3D; Job is running Succeeded &#x3D; Job has succeeded Failed &#x3D; Job has failed Waiting &#x3D; Job is waiting Stopping &#x3D; Job is stopping Stopped &#x3D; Job has been stopped Active &#x3D; Job is active Completed &#x3D; Job is completed</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Running for value: Running
            /// </summary>
            [EnumMember(Value = "Running")]
            Running = 1,

            /// <summary>
            /// Enum Succeeded for value: Succeeded
            /// </summary>
            [EnumMember(Value = "Succeeded")]
            Succeeded = 2,

            /// <summary>
            /// Enum Failed for value: Failed
            /// </summary>
            [EnumMember(Value = "Failed")]
            Failed = 3,

            /// <summary>
            /// Enum Waiting for value: Waiting
            /// </summary>
            [EnumMember(Value = "Waiting")]
            Waiting = 4,

            /// <summary>
            /// Enum Stopping for value: Stopping
            /// </summary>
            [EnumMember(Value = "Stopping")]
            Stopping = 5,

            /// <summary>
            /// Enum Stopped for value: Stopped
            /// </summary>
            [EnumMember(Value = "Stopped")]
            Stopped = 6,

            /// <summary>
            /// Enum Active for value: Active
            /// </summary>
            [EnumMember(Value = "Active")]
            Active = 7,

            /// <summary>
            /// Enum Completed for value: Completed
            /// </summary>
            [EnumMember(Value = "Completed")]
            Completed = 8
        }


        /// <summary>
        /// Status of the job Running &#x3D; Job is running Succeeded &#x3D; Job has succeeded Failed &#x3D; Job has failed Waiting &#x3D; Job is waiting Stopping &#x3D; Job is stopping Stopped &#x3D; Job has been stopped Active &#x3D; Job is active Completed &#x3D; Job is completed
        /// </summary>
        /// <value>Status of the job Running &#x3D; Job is running Succeeded &#x3D; Job has succeeded Failed &#x3D; Job has failed Waiting &#x3D; Job is waiting Stopping &#x3D; Job is stopping Stopped &#x3D; Job has been stopped Active &#x3D; Job is active Completed &#x3D; Job is completed</value>
        /*
        <example>Waiting</example>
        */
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchEvent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BatchEvent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchEvent" /> class.
        /// </summary>
        /// <param name="deploymentName">DeploymentName for this batch.</param>
        /// <param name="batchId">Defines a user defined ID of the batch..</param>
        /// <param name="batchName">BatchName Optional Batch ID of a job.</param>
        /// <param name="batchType">BatchType Single job or multiple jobs batch.</param>
        /// <param name="created">Created timestamp.</param>
        /// <param name="ended">Ended timestamp.</param>
        /// <param name="varEvent">varEvent (required).</param>
        /// <param name="failed">The number of times the container for the job has failed. +optional.</param>
        /// <param name="jobId">JobId Optional ID of a job.</param>
        /// <param name="jobStatuses">JobStatuses of the jobs in the batch.</param>
        /// <param name="message">Message, if any, of the job.</param>
        /// <param name="name">Name of the job (required).</param>
        /// <param name="podStatuses">PodStatuses for each pod of the job.</param>
        /// <param name="restart">Timestamp of the job restart, if applied. +optional.</param>
        /// <param name="started">Started timestamp.</param>
        /// <param name="status">Status of the job Running &#x3D; Job is running Succeeded &#x3D; Job has succeeded Failed &#x3D; Job has failed Waiting &#x3D; Job is waiting Stopping &#x3D; Job is stopping Stopped &#x3D; Job has been stopped Active &#x3D; Job is active Completed &#x3D; Job is completed.</param>
        /// <param name="updated">Updated timestamp when the status was updated.</param>
        public BatchEvent(string deploymentName = default(string), string batchId = default(string), string batchName = default(string), string batchType = default(string), DateTime created = default(DateTime), DateTime ended = default(DateTime), string varEvent = default(string), int failed = default(int), string jobId = default(string), List<JobStatus> jobStatuses = default(List<JobStatus>), string message = default(string), string name = default(string), List<PodStatus> podStatuses = default(List<PodStatus>), string restart = default(string), DateTime started = default(DateTime), StatusEnum? status = default(StatusEnum?), DateTime updated = default(DateTime))
        {
            // to ensure "varEvent" is required (not null)
            if (varEvent == null)
            {
                throw new ArgumentNullException("varEvent is a required property for BatchEvent and cannot be null");
            }
            this.Event = varEvent;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for BatchEvent and cannot be null");
            }
            this.Name = name;
            this.DeploymentName = deploymentName;
            this.BatchId = batchId;
            this.BatchName = batchName;
            this.BatchType = batchType;
            this.Created = created;
            this.Ended = ended;
            this.Failed = failed;
            this.JobId = jobId;
            this.JobStatuses = jobStatuses;
            this.Message = message;
            this.PodStatuses = podStatuses;
            this.Restart = restart;
            this.Started = started;
            this.Status = status;
            this.Updated = updated;
        }

        /// <summary>
        /// DeploymentName for this batch
        /// </summary>
        /// <value>DeploymentName for this batch</value>
        [DataMember(Name = "DeploymentName", EmitDefaultValue = false)]
        public string DeploymentName { get; set; }

        /// <summary>
        /// Defines a user defined ID of the batch.
        /// </summary>
        /// <value>Defines a user defined ID of the batch.</value>
        /*
        <example>&#39;batch-id-1&#39;</example>
        */
        [DataMember(Name = "batchId", EmitDefaultValue = false)]
        public string BatchId { get; set; }

        /// <summary>
        /// BatchName Optional Batch ID of a job
        /// </summary>
        /// <value>BatchName Optional Batch ID of a job</value>
        /*
        <example>&#39;batch1&#39;</example>
        */
        [DataMember(Name = "batchName", EmitDefaultValue = false)]
        public string BatchName { get; set; }

        /// <summary>
        /// BatchType Single job or multiple jobs batch
        /// </summary>
        /// <value>BatchType Single job or multiple jobs batch</value>
        /*
        <example>&quot;job&quot;</example>
        */
        [DataMember(Name = "batchType", EmitDefaultValue = false)]
        public string BatchType { get; set; }

        /// <summary>
        /// Created timestamp
        /// </summary>
        /// <value>Created timestamp</value>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public DateTime Created { get; set; }

        /// <summary>
        /// Ended timestamp
        /// </summary>
        /// <value>Ended timestamp</value>
        [DataMember(Name = "ended", EmitDefaultValue = false)]
        public DateTime Ended { get; set; }

        /// <summary>
        /// Gets or Sets Event
        /// </summary>
        [DataMember(Name = "event", IsRequired = true, EmitDefaultValue = true)]
        public string Event { get; set; }

        /// <summary>
        /// The number of times the container for the job has failed. +optional
        /// </summary>
        /// <value>The number of times the container for the job has failed. +optional</value>
        [DataMember(Name = "failed", EmitDefaultValue = false)]
        public int Failed { get; set; }

        /// <summary>
        /// JobId Optional ID of a job
        /// </summary>
        /// <value>JobId Optional ID of a job</value>
        /*
        <example>&#39;job1&#39;</example>
        */
        [DataMember(Name = "jobId", EmitDefaultValue = false)]
        public string JobId { get; set; }

        /// <summary>
        /// JobStatuses of the jobs in the batch
        /// </summary>
        /// <value>JobStatuses of the jobs in the batch</value>
        [DataMember(Name = "jobStatuses", EmitDefaultValue = false)]
        public List<JobStatus> JobStatuses { get; set; }

        /// <summary>
        /// Message, if any, of the job
        /// </summary>
        /// <value>Message, if any, of the job</value>
        /*
        <example>&quot;Error occurred&quot;</example>
        */
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Name of the job
        /// </summary>
        /// <value>Name of the job</value>
        /*
        <example>calculator</example>
        */
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// PodStatuses for each pod of the job
        /// </summary>
        /// <value>PodStatuses for each pod of the job</value>
        [DataMember(Name = "podStatuses", EmitDefaultValue = false)]
        public List<PodStatus> PodStatuses { get; set; }

        /// <summary>
        /// Timestamp of the job restart, if applied. +optional
        /// </summary>
        /// <value>Timestamp of the job restart, if applied. +optional</value>
        [DataMember(Name = "restart", EmitDefaultValue = false)]
        public string Restart { get; set; }

        /// <summary>
        /// Started timestamp
        /// </summary>
        /// <value>Started timestamp</value>
        [DataMember(Name = "started", EmitDefaultValue = false)]
        public DateTime Started { get; set; }

        /// <summary>
        /// Updated timestamp when the status was updated
        /// </summary>
        /// <value>Updated timestamp when the status was updated</value>
        [DataMember(Name = "updated", EmitDefaultValue = false)]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BatchEvent {\n");
            sb.Append("  DeploymentName: ").Append(DeploymentName).Append("\n");
            sb.Append("  BatchId: ").Append(BatchId).Append("\n");
            sb.Append("  BatchName: ").Append(BatchName).Append("\n");
            sb.Append("  BatchType: ").Append(BatchType).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Ended: ").Append(Ended).Append("\n");
            sb.Append("  Event: ").Append(Event).Append("\n");
            sb.Append("  Failed: ").Append(Failed).Append("\n");
            sb.Append("  JobId: ").Append(JobId).Append("\n");
            sb.Append("  JobStatuses: ").Append(JobStatuses).Append("\n");
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
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
