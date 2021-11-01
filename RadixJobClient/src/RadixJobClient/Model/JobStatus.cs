/*
 * classification Radix API.
 *
 * This is the API Server for the Radix job scheduler.
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
    /// JobStatus holds general information about job status
    /// </summary>
    [DataContract(Name = "JobStatus")]
    public partial class JobStatus : IEquatable<JobStatus>, IValidatableObject
    {
        /// <summary>
        /// Status of the job
        /// </summary>
        /// <value>Status of the job</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Waiting for value: Waiting
            /// </summary>
            [EnumMember(Value = "Waiting")]
            Waiting = 1,

            /// <summary>
            /// Enum Running for value: Running
            /// </summary>
            [EnumMember(Value = "Running")]
            Running = 2,

            /// <summary>
            /// Enum Succeeded for value: Succeeded
            /// </summary>
            [EnumMember(Value = "Succeeded")]
            Succeeded = 3,

            /// <summary>
            /// Enum Stopping for value: Stopping
            /// </summary>
            [EnumMember(Value = "Stopping")]
            Stopping = 4,

            /// <summary>
            /// Enum Stopped for value: Stopped
            /// </summary>
            [EnumMember(Value = "Stopped")]
            Stopped = 5,

            /// <summary>
            /// Enum Failed for value: Failed
            /// </summary>
            [EnumMember(Value = "Failed")]
            Failed = 6

        }


        /// <summary>
        /// Status of the job
        /// </summary>
        /// <value>Status of the job</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="JobStatus" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected JobStatus() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JobStatus" /> class.
        /// </summary>
        /// <param name="ended">Ended timestamp.</param>
        /// <param name="name">Name of the job (required).</param>
        /// <param name="started">Started timestamp.</param>
        /// <param name="status">Status of the job.</param>
        public JobStatus(string ended = default(string), string name = default(string), string started = default(string), StatusEnum? status = default(StatusEnum?))
        {
            // to ensure "name" is required (not null)
            if (name == null) {
                throw new ArgumentNullException("name is a required property for JobStatus and cannot be null");
            }
            this.Name = name;
            this.Ended = ended;
            this.Started = started;
            this.Status = status;
        }

        /// <summary>
        /// Ended timestamp
        /// </summary>
        /// <value>Ended timestamp</value>
        [DataMember(Name = "ended", EmitDefaultValue = false)]
        public string Ended { get; set; }

        /// <summary>
        /// Name of the job
        /// </summary>
        /// <value>Name of the job</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Started timestamp
        /// </summary>
        /// <value>Started timestamp</value>
        [DataMember(Name = "started", EmitDefaultValue = false)]
        public string Started { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JobStatus {\n");
            sb.Append("  Ended: ").Append(Ended).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Started: ").Append(Started).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return this.Equals(input as JobStatus);
        }

        /// <summary>
        /// Returns true if JobStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of JobStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(JobStatus input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Ended == input.Ended ||
                    (this.Ended != null &&
                    this.Ended.Equals(input.Ended))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Started == input.Started ||
                    (this.Started != null &&
                    this.Started.Equals(input.Started))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
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
                if (this.Ended != null)
                    hashCode = hashCode * 59 + this.Ended.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Started != null)
                    hashCode = hashCode * 59 + this.Started.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
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