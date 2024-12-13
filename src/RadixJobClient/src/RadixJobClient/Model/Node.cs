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
    /// Node defines node attributes, where container should be scheduled
    /// </summary>
    [DataContract(Name = "Node")]
    public partial class Node : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node" /> class.
        /// </summary>
        /// <param name="gpu">Defines rules for allowed GPU types..</param>
        /// <param name="gpuCount">Defines minimum number of required GPUs..</param>
        public Node(string gpu = default(string), string gpuCount = default(string))
        {
            this.Gpu = gpu;
            this.GpuCount = gpuCount;
        }

        /// <summary>
        /// Defines rules for allowed GPU types.
        /// </summary>
        /// <value>Defines rules for allowed GPU types.</value>
        [DataMember(Name = "gpu", EmitDefaultValue = true)]
        public string Gpu { get; set; }

        /// <summary>
        /// Defines minimum number of required GPUs.
        /// </summary>
        /// <value>Defines minimum number of required GPUs.</value>
        [DataMember(Name = "gpuCount", EmitDefaultValue = true)]
        public string GpuCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
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