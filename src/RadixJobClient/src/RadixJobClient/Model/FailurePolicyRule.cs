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
    /// FailurePolicyRule
    /// </summary>
    [DataContract(Name = "FailurePolicyRule")]
    public partial class FailurePolicyRule : IValidatableObject
    {
        /// <summary>
        /// Specifies the action taken on a job replica failure when the onExitCodes requirements are satisfied. FailJob FailurePolicyRuleActionFailJob  This is an action which might be taken on a job replica failure - mark the  job as Failed and terminate all running pods. Ignore FailurePolicyRuleActionIgnore  This is an action which might be taken on a job replica failure - the counter towards  .backoffLimit is not incremented and a replacement replica is created. Count FailurePolicyRuleActionCount  This is an action which might be taken on a job replica failure - the replica failure  is handled in the default way - the counter towards .backoffLimit is incremented.
        /// </summary>
        /// <value>Specifies the action taken on a job replica failure when the onExitCodes requirements are satisfied. FailJob FailurePolicyRuleActionFailJob  This is an action which might be taken on a job replica failure - mark the  job as Failed and terminate all running pods. Ignore FailurePolicyRuleActionIgnore  This is an action which might be taken on a job replica failure - the counter towards  .backoffLimit is not incremented and a replacement replica is created. Count FailurePolicyRuleActionCount  This is an action which might be taken on a job replica failure - the replica failure  is handled in the default way - the counter towards .backoffLimit is incremented.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ActionEnum
        {
            /// <summary>
            /// Enum FailJob for value: FailJob
            /// </summary>
            [EnumMember(Value = "FailJob")]
            FailJob = 1,

            /// <summary>
            /// Enum Ignore for value: Ignore
            /// </summary>
            [EnumMember(Value = "Ignore")]
            Ignore = 2,

            /// <summary>
            /// Enum Count for value: Count
            /// </summary>
            [EnumMember(Value = "Count")]
            Count = 3
        }


        /// <summary>
        /// Specifies the action taken on a job replica failure when the onExitCodes requirements are satisfied. FailJob FailurePolicyRuleActionFailJob  This is an action which might be taken on a job replica failure - mark the  job as Failed and terminate all running pods. Ignore FailurePolicyRuleActionIgnore  This is an action which might be taken on a job replica failure - the counter towards  .backoffLimit is not incremented and a replacement replica is created. Count FailurePolicyRuleActionCount  This is an action which might be taken on a job replica failure - the replica failure  is handled in the default way - the counter towards .backoffLimit is incremented.
        /// </summary>
        /// <value>Specifies the action taken on a job replica failure when the onExitCodes requirements are satisfied. FailJob FailurePolicyRuleActionFailJob  This is an action which might be taken on a job replica failure - mark the  job as Failed and terminate all running pods. Ignore FailurePolicyRuleActionIgnore  This is an action which might be taken on a job replica failure - the counter towards  .backoffLimit is not incremented and a replacement replica is created. Count FailurePolicyRuleActionCount  This is an action which might be taken on a job replica failure - the replica failure  is handled in the default way - the counter towards .backoffLimit is incremented.</value>
        [DataMember(Name = "action", IsRequired = true, EmitDefaultValue = true)]
        public ActionEnum Action { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FailurePolicyRule" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FailurePolicyRule() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FailurePolicyRule" /> class.
        /// </summary>
        /// <param name="action">Specifies the action taken on a job replica failure when the onExitCodes requirements are satisfied. FailJob FailurePolicyRuleActionFailJob  This is an action which might be taken on a job replica failure - mark the  job as Failed and terminate all running pods. Ignore FailurePolicyRuleActionIgnore  This is an action which might be taken on a job replica failure - the counter towards  .backoffLimit is not incremented and a replacement replica is created. Count FailurePolicyRuleActionCount  This is an action which might be taken on a job replica failure - the replica failure  is handled in the default way - the counter towards .backoffLimit is incremented. (required).</param>
        /// <param name="onExitCodes">onExitCodes (required).</param>
        public FailurePolicyRule(ActionEnum action = default(ActionEnum), FailurePolicyRuleOnExitCodes onExitCodes = default(FailurePolicyRuleOnExitCodes))
        {
            this.Action = action;
            // to ensure "onExitCodes" is required (not null)
            if (onExitCodes == null)
            {
                throw new ArgumentNullException("onExitCodes is a required property for FailurePolicyRule and cannot be null");
            }
            this.OnExitCodes = onExitCodes;
        }

        /// <summary>
        /// Gets or Sets OnExitCodes
        /// </summary>
        [DataMember(Name = "onExitCodes", IsRequired = true, EmitDefaultValue = true)]
        public FailurePolicyRuleOnExitCodes OnExitCodes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FailurePolicyRule {\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  OnExitCodes: ").Append(OnExitCodes).Append("\n");
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
