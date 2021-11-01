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
    /// JobScheduleDescription holds description about scheduling job
    /// </summary>
    [DataContract(Name = "JobScheduleDescription")]
    public partial class JobScheduleDescription : IEquatable<JobScheduleDescription>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobScheduleDescription" /> class.
        /// </summary>
        /// <param name="node">node.</param>
        /// <param name="payload">Payload holding json data to be mapped to component.</param>
        /// <param name="resources">resources.</param>
        public JobScheduleDescription(RadixNode node = default(RadixNode), string payload = default(string), ResourceRequirements resources = default(ResourceRequirements))
        {
            this.Node = node;
            this.Payload = payload;
            this.Resources = resources;
        }

        /// <summary>
        /// Gets or Sets Node
        /// </summary>
        [DataMember(Name = "node", EmitDefaultValue = false)]
        public RadixNode Node { get; set; }

        /// <summary>
        /// Payload holding json data to be mapped to component
        /// </summary>
        /// <value>Payload holding json data to be mapped to component</value>
        [DataMember(Name = "payload", EmitDefaultValue = false)]
        public string Payload { get; set; }

        /// <summary>
        /// Gets or Sets Resources
        /// </summary>
        [DataMember(Name = "resources", EmitDefaultValue = false)]
        public ResourceRequirements Resources { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JobScheduleDescription {\n");
            sb.Append("  Node: ").Append(Node).Append("\n");
            sb.Append("  Payload: ").Append(Payload).Append("\n");
            sb.Append("  Resources: ").Append(Resources).Append("\n");
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
                if (this.Node != null)
                    hashCode = hashCode * 59 + this.Node.GetHashCode();
                if (this.Payload != null)
                    hashCode = hashCode * 59 + this.Payload.GetHashCode();
                if (this.Resources != null)
                    hashCode = hashCode * 59 + this.Resources.GetHashCode();
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