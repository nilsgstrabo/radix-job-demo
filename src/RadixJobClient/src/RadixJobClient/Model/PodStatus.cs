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
    /// PodStatus
    /// </summary>
    [DataContract(Name = "PodStatus")]
    public partial class PodStatus : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PodStatus" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PodStatus() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PodStatus" /> class.
        /// </summary>
        /// <param name="containerStarted">Container started timestamp.</param>
        /// <param name="created">Created timestamp.</param>
        /// <param name="endTime">The time at which the batch job&#39;s pod finishedAt..</param>
        /// <param name="exitCode">Exit status from the last termination of the container.</param>
        /// <param name="image">The image the container is running..</param>
        /// <param name="imageId">ImageID of the container&#39;s image..</param>
        /// <param name="name">Pod name (required).</param>
        /// <param name="podIndex">The index of the pod in the re-starts.</param>
        /// <param name="reason">A brief CamelCase message indicating details about why the job is in this phase.</param>
        /// <param name="replicaStatus">replicaStatus.</param>
        /// <param name="restartCount">RestartCount count of restarts of a component container inside a pod.</param>
        /// <param name="startTime">The time at which the batch job&#39;s pod startedAt.</param>
        /// <param name="statusMessage">StatusMessage provides message describing the status of a component container inside a pod.</param>
        public PodStatus(DateTimeOffset containerStarted = default(DateTimeOffset), DateTimeOffset created = default(DateTimeOffset), DateTimeOffset endTime = default(DateTimeOffset), int exitCode = default(int), string image = default(string), string imageId = default(string), string name = default(string), long podIndex = default(long), string reason = default(string), ReplicaStatus replicaStatus = default(ReplicaStatus), int restartCount = default(int), DateTimeOffset startTime = default(DateTimeOffset), string statusMessage = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for PodStatus and cannot be null");
            }
            this.Name = name;
            this.ContainerStarted = containerStarted;
            this.Created = created;
            this.EndTime = endTime;
            this.ExitCode = exitCode;
            this.Image = image;
            this.ImageId = imageId;
            this.PodIndex = podIndex;
            this.Reason = reason;
            this.ReplicaStatus = replicaStatus;
            this.RestartCount = restartCount;
            this.StartTime = startTime;
            this.StatusMessage = statusMessage;
        }

        /// <summary>
        /// Container started timestamp
        /// </summary>
        /// <value>Container started timestamp</value>
        [DataMember(Name = "containerStarted", EmitDefaultValue = true)]
        public DateTimeOffset ContainerStarted { get; set; }

        /// <summary>
        /// Created timestamp
        /// </summary>
        /// <value>Created timestamp</value>
        [DataMember(Name = "created", EmitDefaultValue = true)]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// The time at which the batch job&#39;s pod finishedAt.
        /// </summary>
        /// <value>The time at which the batch job&#39;s pod finishedAt.</value>
        [DataMember(Name = "endTime", EmitDefaultValue = true)]
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// Exit status from the last termination of the container
        /// </summary>
        /// <value>Exit status from the last termination of the container</value>
        [DataMember(Name = "exitCode", EmitDefaultValue = true)]
        public int ExitCode { get; set; }

        /// <summary>
        /// The image the container is running.
        /// </summary>
        /// <value>The image the container is running.</value>
        /*
        <example>radixdev.azurecr.io/app-server:cdgkg</example>
        */
        [DataMember(Name = "image", EmitDefaultValue = true)]
        public string Image { get; set; }

        /// <summary>
        /// ImageID of the container&#39;s image.
        /// </summary>
        /// <value>ImageID of the container&#39;s image.</value>
        /*
        <example>radixdev.azurecr.io/app-server@sha256:d40cda01916ef63da3607c03785efabc56eb2fc2e0dab0726b1a843e9ded093f</example>
        */
        [DataMember(Name = "imageId", EmitDefaultValue = true)]
        public string ImageId { get; set; }

        /// <summary>
        /// Pod name
        /// </summary>
        /// <value>Pod name</value>
        /*
        <example>server-78fc8857c4-hm76l</example>
        */
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The index of the pod in the re-starts
        /// </summary>
        /// <value>The index of the pod in the re-starts</value>
        [DataMember(Name = "podIndex", EmitDefaultValue = true)]
        public long PodIndex { get; set; }

        /// <summary>
        /// A brief CamelCase message indicating details about why the job is in this phase
        /// </summary>
        /// <value>A brief CamelCase message indicating details about why the job is in this phase</value>
        [DataMember(Name = "reason", EmitDefaultValue = true)]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or Sets ReplicaStatus
        /// </summary>
        [DataMember(Name = "replicaStatus", EmitDefaultValue = true)]
        public ReplicaStatus ReplicaStatus { get; set; }

        /// <summary>
        /// RestartCount count of restarts of a component container inside a pod
        /// </summary>
        /// <value>RestartCount count of restarts of a component container inside a pod</value>
        [DataMember(Name = "restartCount", EmitDefaultValue = true)]
        public int RestartCount { get; set; }

        /// <summary>
        /// The time at which the batch job&#39;s pod startedAt
        /// </summary>
        /// <value>The time at which the batch job&#39;s pod startedAt</value>
        [DataMember(Name = "startTime", EmitDefaultValue = true)]
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// StatusMessage provides message describing the status of a component container inside a pod
        /// </summary>
        /// <value>StatusMessage provides message describing the status of a component container inside a pod</value>
        [DataMember(Name = "statusMessage", EmitDefaultValue = true)]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PodStatus {\n");
            sb.Append("  ContainerStarted: ").Append(ContainerStarted).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
            sb.Append("  ExitCode: ").Append(ExitCode).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  ImageId: ").Append(ImageId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PodIndex: ").Append(PodIndex).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  ReplicaStatus: ").Append(ReplicaStatus).Append("\n");
            sb.Append("  RestartCount: ").Append(RestartCount).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  StatusMessage: ").Append(StatusMessage).Append("\n");
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
