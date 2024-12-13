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
    /// Resources
    /// </summary>
    [DataContract(Name = "Resources")]
    public partial class Resources : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Resources" /> class.
        /// </summary>
        /// <param name="limits">limits.</param>
        /// <param name="requests">requests.</param>
        public Resources(Dictionary<string, string> limits = default(Dictionary<string, string>), Dictionary<string, string> requests = default(Dictionary<string, string>))
        {
            this.Limits = limits;
            this.Requests = requests;
        }

        /// <summary>
        /// Gets or Sets Limits
        /// </summary>
        [DataMember(Name = "limits", EmitDefaultValue = true)]
        public Dictionary<string, string> Limits { get; set; }

        /// <summary>
        /// Gets or Sets Requests
        /// </summary>
        [DataMember(Name = "requests", EmitDefaultValue = true)]
        public Dictionary<string, string> Requests { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Resources {\n");
            sb.Append("  Limits: ").Append(Limits).Append("\n");
            sb.Append("  Requests: ").Append(Requests).Append("\n");
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
