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
    /// RadixJobComponentConfig holds description of RadixJobComponent
    /// </summary>
    [DataContract]
    public partial class RadixJobComponentConfig : IEquatable<RadixJobComponentConfig>
    {
        /// <summary>
        /// BackoffLimit defines attempts to restart job if it fails. Corresponds to BackoffLimit in K8s.
        /// </summary>
        /// <value>BackoffLimit defines attempts to restart job if it fails. Corresponds to BackoffLimit in K8s.</value>
        [DataMember(Name="backoffLimit", EmitDefaultValue=true)]
        public int BackoffLimit { get; set; }

        /// <summary>
        /// Gets or Sets FailurePolicy
        /// </summary>
        [DataMember(Name="failurePolicy", EmitDefaultValue=false)]
        public FailurePolicy FailurePolicy { get; set; }

        /// <summary>
        /// ImageTagName defines the image tag name to use for the job image
        /// </summary>
        /// <value>ImageTagName defines the image tag name to use for the job image</value>
        [DataMember(Name="imageTagName", EmitDefaultValue=false)]
        public string ImageTagName { get; set; }

        /// <summary>
        /// Gets or Sets Node
        /// </summary>
        [DataMember(Name="node", EmitDefaultValue=false)]
        public Node Node { get; set; }

        /// <summary>
        /// Gets or Sets Resources
        /// </summary>
        [DataMember(Name="resources", EmitDefaultValue=false)]
        public Resources Resources { get; set; }

        /// <summary>
        /// TimeLimitSeconds defines maximum job run time. Corresponds to ActiveDeadlineSeconds in K8s.
        /// </summary>
        /// <value>TimeLimitSeconds defines maximum job run time. Corresponds to ActiveDeadlineSeconds in K8s.</value>
        [DataMember(Name="timeLimitSeconds", EmitDefaultValue=true)]
        public long TimeLimitSeconds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RadixJobComponentConfig {\n");
            sb.Append("  BackoffLimit: ").Append(BackoffLimit).Append("\n");
            sb.Append("  FailurePolicy: ").Append(FailurePolicy).Append("\n");
            sb.Append("  ImageTagName: ").Append(ImageTagName).Append("\n");
            sb.Append("  Node: ").Append(Node).Append("\n");
            sb.Append("  Resources: ").Append(Resources).Append("\n");
            sb.Append("  TimeLimitSeconds: ").Append(TimeLimitSeconds).Append("\n");
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
            return obj.GetType() == GetType() && Equals((RadixJobComponentConfig)obj);
        }

        /// <summary>
        /// Returns true if RadixJobComponentConfig instances are equal
        /// </summary>
        /// <param name="other">Instance of RadixJobComponentConfig to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RadixJobComponentConfig other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    BackoffLimit == other.BackoffLimit ||
                    
                    BackoffLimit.Equals(other.BackoffLimit)
                ) && 
                (
                    FailurePolicy == other.FailurePolicy ||
                    FailurePolicy != null &&
                    FailurePolicy.Equals(other.FailurePolicy)
                ) && 
                (
                    ImageTagName == other.ImageTagName ||
                    ImageTagName != null &&
                    ImageTagName.Equals(other.ImageTagName)
                ) && 
                (
                    Node == other.Node ||
                    Node != null &&
                    Node.Equals(other.Node)
                ) && 
                (
                    Resources == other.Resources ||
                    Resources != null &&
                    Resources.Equals(other.Resources)
                ) && 
                (
                    TimeLimitSeconds == other.TimeLimitSeconds ||
                    
                    TimeLimitSeconds.Equals(other.TimeLimitSeconds)
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
                    
                    hashCode = hashCode * 59 + BackoffLimit.GetHashCode();
                    if (FailurePolicy != null)
                    hashCode = hashCode * 59 + FailurePolicy.GetHashCode();
                    if (ImageTagName != null)
                    hashCode = hashCode * 59 + ImageTagName.GetHashCode();
                    if (Node != null)
                    hashCode = hashCode * 59 + Node.GetHashCode();
                    if (Resources != null)
                    hashCode = hashCode * 59 + Resources.GetHashCode();
                    
                    hashCode = hashCode * 59 + TimeLimitSeconds.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(RadixJobComponentConfig left, RadixJobComponentConfig right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RadixJobComponentConfig left, RadixJobComponentConfig right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
