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
    /// Status is a return value for calls that don&#39;t return other objects or when a request returns an error
    /// </summary>
    [DataContract(Name = "Status")]
    public partial class Status : IEquatable<Status>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Status" /> class.
        /// </summary>
        /// <param name="code">Suggested HTTP return code for this status, 0 if not set..</param>
        /// <param name="message">A human-readable description of the status of this operation..</param>
        /// <param name="reason">reason.</param>
        /// <param name="status">Status of the operation. One of: \&quot;Success\&quot; or \&quot;Failure\&quot;..</param>
        public Status(long code = default(long), string message = default(string), string reason = default(string), string status = default(string))
        {
            this.Code = code;
            this.Message = message;
            this.Reason = reason;
            this._Status = status;
        }

        /// <summary>
        /// Suggested HTTP return code for this status, 0 if not set.
        /// </summary>
        /// <value>Suggested HTTP return code for this status, 0 if not set.</value>
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public long Code { get; set; }

        /// <summary>
        /// A human-readable description of the status of this operation.
        /// </summary>
        /// <value>A human-readable description of the status of this operation.</value>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets Reason
        /// </summary>
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public string Reason { get; set; }

        /// <summary>
        /// Status of the operation. One of: \&quot;Success\&quot; or \&quot;Failure\&quot;.
        /// </summary>
        /// <value>Status of the operation. One of: \&quot;Success\&quot; or \&quot;Failure\&quot;.</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string _Status { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Status {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  _Status: ").Append(_Status).Append("\n");
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
            return this.Equals(input as Status);
        }

        /// <summary>
        /// Returns true if Status instances are equal
        /// </summary>
        /// <param name="input">Instance of Status to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Status input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Code == input.Code ||
                    this.Code.Equals(input.Code)
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.Reason == input.Reason ||
                    (this.Reason != null &&
                    this.Reason.Equals(input.Reason))
                ) && 
                (
                    this._Status == input._Status ||
                    (this._Status != null &&
                    this._Status.Equals(input._Status))
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
                hashCode = hashCode * 59 + this.Code.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.Reason != null)
                    hashCode = hashCode * 59 + this.Reason.GetHashCode();
                if (this._Status != null)
                    hashCode = hashCode * 59 + this._Status.GetHashCode();
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
