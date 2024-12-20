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
    /// Node defines node attributes, where container should be scheduled
    /// </summary>
    [DataContract]
    public partial class Node : IEquatable<Node>
    {
        /// <summary>
        /// Defines rules for allowed GPU types.
        /// </summary>
        /// <value>Defines rules for allowed GPU types.</value>
        [DataMember(Name="gpu", EmitDefaultValue=false)]
        public string Gpu { get; set; }

        /// <summary>
        /// Defines minimum number of required GPUs.
        /// </summary>
        /// <value>Defines minimum number of required GPUs.</value>
        [DataMember(Name="gpuCount", EmitDefaultValue=false)]
        public string GpuCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Node {\n");
            sb.Append("  Gpu: ").Append(Gpu).Append("\n");
            sb.Append("  GpuCount: ").Append(GpuCount).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Node)obj);
        }

        /// <summary>
        /// Returns true if Node instances are equal
        /// </summary>
        /// <param name="other">Instance of Node to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Node other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Gpu == other.Gpu ||
                    Gpu != null &&
                    Gpu.Equals(other.Gpu)
                ) && 
                (
                    GpuCount == other.GpuCount ||
                    GpuCount != null &&
                    GpuCount.Equals(other.GpuCount)
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
                    if (Gpu != null)
                    hashCode = hashCode * 59 + Gpu.GetHashCode();
                    if (GpuCount != null)
                    hashCode = hashCode * 59 + GpuCount.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Node left, Node right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Node left, Node right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
