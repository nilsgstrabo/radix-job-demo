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
    /// FailurePolicyRuleOnExitCodes describes the requirement for handling a failed job replica based on its exit code.
    /// </summary>
    [DataContract]
    public partial class FailurePolicyRuleOnExitCodes : IEquatable<FailurePolicyRuleOnExitCodes>
    {

        /// <summary>
        /// Represents the relationship between the job replica's exit code and the specified values. Replicas completed with success (exit code 0) are excluded from the requirement check. In FailurePolicyRuleOnExitCodesOpIn  The requirement is satisfied if the job replica's exit code is in the set of specified values. NotIn FailurePolicyRuleOnExitCodesOpNotIn  The requirement is satisfied if the job replica's exit code is not in the set of specified values.
        /// </summary>
        /// <value>Represents the relationship between the job replica's exit code and the specified values. Replicas completed with success (exit code 0) are excluded from the requirement check. In FailurePolicyRuleOnExitCodesOpIn  The requirement is satisfied if the job replica's exit code is in the set of specified values. NotIn FailurePolicyRuleOnExitCodesOpNotIn  The requirement is satisfied if the job replica's exit code is not in the set of specified values.</value>
        [TypeConverter(typeof(CustomEnumConverter<OperatorEnum>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum OperatorEnum
        {
            
            /// <summary>
            /// Enum InEnum for In
            /// </summary>
            [EnumMember(Value = "In")]
            InEnum = 1,
            
            /// <summary>
            /// Enum NotInEnum for NotIn
            /// </summary>
            [EnumMember(Value = "NotIn")]
            NotInEnum = 2
        }

        /// <summary>
        /// Represents the relationship between the job replica&#39;s exit code and the specified values. Replicas completed with success (exit code 0) are excluded from the requirement check. In FailurePolicyRuleOnExitCodesOpIn  The requirement is satisfied if the job replica&#39;s exit code is in the set of specified values. NotIn FailurePolicyRuleOnExitCodesOpNotIn  The requirement is satisfied if the job replica&#39;s exit code is not in the set of specified values.
        /// </summary>
        /// <value>Represents the relationship between the job replica&#39;s exit code and the specified values. Replicas completed with success (exit code 0) are excluded from the requirement check. In FailurePolicyRuleOnExitCodesOpIn  The requirement is satisfied if the job replica&#39;s exit code is in the set of specified values. NotIn FailurePolicyRuleOnExitCodesOpNotIn  The requirement is satisfied if the job replica&#39;s exit code is not in the set of specified values.</value>
        [Required]
        [DataMember(Name="operator", EmitDefaultValue=true)]
        public OperatorEnum Operator { get; set; }

        /// <summary>
        /// Specifies the set of values. The job replica&#39;s exit code is checked against this set of values with respect to the operator. The list must not contain duplicates. Value &#39;0&#39; cannot be used for the In operator.
        /// </summary>
        /// <value>Specifies the set of values. The job replica&#39;s exit code is checked against this set of values with respect to the operator. The list must not contain duplicates. Value &#39;0&#39; cannot be used for the In operator.</value>
        [Required]
        [DataMember(Name="values", EmitDefaultValue=false)]
        public List<int> Values { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FailurePolicyRuleOnExitCodes {\n");
            sb.Append("  Operator: ").Append(Operator).Append("\n");
            sb.Append("  Values: ").Append(Values).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
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
            return obj.GetType() == GetType() && Equals((FailurePolicyRuleOnExitCodes)obj);
        }

        /// <summary>
        /// Returns true if FailurePolicyRuleOnExitCodes instances are equal
        /// </summary>
        /// <param name="other">Instance of FailurePolicyRuleOnExitCodes to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FailurePolicyRuleOnExitCodes other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Operator == other.Operator ||
                    
                    Operator.Equals(other.Operator)
                ) && 
                (
                    Values == other.Values ||
                    Values != null &&
                    other.Values != null &&
                    Values.SequenceEqual(other.Values)
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
                    
                    hashCode = hashCode * 59 + Operator.GetHashCode();
                    if (Values != null)
                    hashCode = hashCode * 59 + Values.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(FailurePolicyRuleOnExitCodes left, FailurePolicyRuleOnExitCodes right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FailurePolicyRuleOnExitCodes left, FailurePolicyRuleOnExitCodes right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
