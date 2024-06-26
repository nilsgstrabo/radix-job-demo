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
    /// JobScheduleDescription holds description about scheduling job
    /// </summary>
    [DataContract(Name = "JobScheduleDescription")]
    public partial class JobScheduleDescription : IEquatable<JobScheduleDescription>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobScheduleDescription" /> class.
        /// </summary>
        /// <param name="backoffLimit">BackoffLimit defines attempts to restart job if it fails. Corresponds to BackoffLimit in K8s..</param>
        /// <param name="imageTagName">ImageTagName defines the image tag name to use for the job image.</param>
        /// <param name="jobId">JobId Optional ID of a job.</param>
        /// <param name="node">Node defines node attributes, where container should be scheduled.</param>
        /// <param name="payload">Payload holding json data to be mapped to component.</param>
        /// <param name="resources">Resource describes the compute resource requirements..</param>
        /// <param name="timeLimitSeconds">TimeLimitSeconds defines maximum job run time. Corresponds to ActiveDeadlineSeconds in K8s..</param>
        public JobScheduleDescription(int backoffLimit = default(int), string imageTagName = default(string), string jobId = default(string), Object node = default(Object), string payload = default(string), Object resources = default(Object), long timeLimitSeconds = default(long))
        {
            this.BackoffLimit = backoffLimit;
            this.ImageTagName = imageTagName;
            this.JobId = jobId;
            this.Node = node;
            this.Payload = payload;
            this.Resources = resources;
            this.TimeLimitSeconds = timeLimitSeconds;
        }

        /// <summary>
        /// BackoffLimit defines attempts to restart job if it fails. Corresponds to BackoffLimit in K8s.
        /// </summary>
        /// <value>BackoffLimit defines attempts to restart job if it fails. Corresponds to BackoffLimit in K8s.</value>
        [DataMember(Name = "backoffLimit", EmitDefaultValue = false)]
        public int BackoffLimit { get; set; }

        /// <summary>
        /// ImageTagName defines the image tag name to use for the job image
        /// </summary>
        /// <value>ImageTagName defines the image tag name to use for the job image</value>
        [DataMember(Name = "imageTagName", EmitDefaultValue = false)]
        public string ImageTagName { get; set; }

        /// <summary>
        /// JobId Optional ID of a job
        /// </summary>
        /// <value>JobId Optional ID of a job</value>
        [DataMember(Name = "jobId", EmitDefaultValue = false)]
        public string JobId { get; set; }

        /// <summary>
        /// Node defines node attributes, where container should be scheduled
        /// </summary>
        /// <value>Node defines node attributes, where container should be scheduled</value>
        [DataMember(Name = "node", EmitDefaultValue = false)]
        public Object Node { get; set; }

        /// <summary>
        /// Payload holding json data to be mapped to component
        /// </summary>
        /// <value>Payload holding json data to be mapped to component</value>
        [DataMember(Name = "payload", EmitDefaultValue = false)]
        public string Payload { get; set; }

        /// <summary>
        /// Resource describes the compute resource requirements.
        /// </summary>
        /// <value>Resource describes the compute resource requirements.</value>
        [DataMember(Name = "resources", EmitDefaultValue = false)]
        public Object Resources { get; set; }

        /// <summary>
        /// TimeLimitSeconds defines maximum job run time. Corresponds to ActiveDeadlineSeconds in K8s.
        /// </summary>
        /// <value>TimeLimitSeconds defines maximum job run time. Corresponds to ActiveDeadlineSeconds in K8s.</value>
        [DataMember(Name = "timeLimitSeconds", EmitDefaultValue = false)]
        public long TimeLimitSeconds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JobScheduleDescription {\n");
            sb.Append("  BackoffLimit: ").Append(BackoffLimit).Append("\n");
            sb.Append("  ImageTagName: ").Append(ImageTagName).Append("\n");
            sb.Append("  JobId: ").Append(JobId).Append("\n");
            sb.Append("  Node: ").Append(Node).Append("\n");
            sb.Append("  Payload: ").Append(Payload).Append("\n");
            sb.Append("  Resources: ").Append(Resources).Append("\n");
            sb.Append("  TimeLimitSeconds: ").Append(TimeLimitSeconds).Append("\n");
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
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as JobScheduleDescription);
        }

        /// <summary>
        /// Returns true if JobScheduleDescription instances are equal
        /// </summary>
        /// <param name="input">Instance of JobScheduleDescription to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(JobScheduleDescription input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.BackoffLimit == input.BackoffLimit ||
                    this.BackoffLimit.Equals(input.BackoffLimit)
                ) && 
                (
                    this.ImageTagName == input.ImageTagName ||
                    (this.ImageTagName != null &&
                    this.ImageTagName.Equals(input.ImageTagName))
                ) && 
                (
                    this.JobId == input.JobId ||
                    (this.JobId != null &&
                    this.JobId.Equals(input.JobId))
                ) && 
                (
                    this.Node == input.Node ||
                    (this.Node != null &&
                    this.Node.Equals(input.Node))
                ) && 
                (
                    this.Payload == input.Payload ||
                    (this.Payload != null &&
                    this.Payload.Equals(input.Payload))
                ) && 
                (
                    this.Resources == input.Resources ||
                    (this.Resources != null &&
                    this.Resources.Equals(input.Resources))
                ) && 
                (
                    this.TimeLimitSeconds == input.TimeLimitSeconds ||
                    this.TimeLimitSeconds.Equals(input.TimeLimitSeconds)
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
                int hashCode = 41;
                hashCode = hashCode * 59 + this.BackoffLimit.GetHashCode();
                if (this.ImageTagName != null)
                    hashCode = hashCode * 59 + this.ImageTagName.GetHashCode();
                if (this.JobId != null)
                    hashCode = hashCode * 59 + this.JobId.GetHashCode();
                if (this.Node != null)
                    hashCode = hashCode * 59 + this.Node.GetHashCode();
                if (this.Payload != null)
                    hashCode = hashCode * 59 + this.Payload.GetHashCode();
                if (this.Resources != null)
                    hashCode = hashCode * 59 + this.Resources.GetHashCode();
                hashCode = hashCode * 59 + this.TimeLimitSeconds.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
