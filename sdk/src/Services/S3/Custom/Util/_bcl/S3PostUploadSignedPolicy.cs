﻿/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *    __  _    _  ___
 *   (  )( \/\/ )/ __)
 *   /__\ \    / \__ \
 *  (_)(_) \/\/  (___/
 *
 *  AWS SDK for .NET
 *
 */

using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Amazon.Runtime;
using Amazon.Util;
using System.Globalization;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Amazon.S3.Util
{
    /// <summary>
    /// Utility class for managing and exchanging HTTP POST uploads of objects to Amazon S3.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This object supports creating, marshalling, and unmarshalling of the information needed to build 
    /// an authenticated HTTP POST request to S3 for uploading objects according to a policy. 
    /// </para>
    /// For more information, <see href="http://docs.aws.amazon.com/AmazonS3/latest/dev/UsingHTTPPOST.html"/>
    /// </remarks>
    [XmlRootAttribute(IsNullable = false)]
    public class S3PostUploadSignedPolicy
    {
        private static JsonDocumentOptions options = new JsonDocumentOptions { AllowTrailingCommas = true };
    /// <summary>
    ///  Given a policy and AWS credentials, produce a S3PostUploadSignedPolicy.
    /// </summary>
    /// <param name="policy">JSON string representing the policy to sign</param>
    /// <param name="credentials">Credentials to sign the policy with</param>
    /// <param name="region">Service region endpoint.</param>
    /// <returns>A signed policy object for use with an S3PostUploadRequest.</returns>
    public static S3PostUploadSignedPolicy GetSignedPolicy(string policy, AWSCredentials credentials, RegionEndpoint region)
        {
            var signedAt = AWSSDKUtils.CorrectedUtcNow;

            ImmutableCredentials iCreds = credentials.GetCredentials();
            var algorithm = "AWS4-HMAC-SHA256";
            var dateStamp = Runtime.Internal.Auth.AWS4Signer.FormatDateTime(signedAt, AWSSDKUtils.ISO8601BasicDateFormat);
            var dateTimeStamp = Runtime.Internal.Auth.AWS4Signer.FormatDateTime(signedAt, AWSSDKUtils.ISO8601BasicDateTimeFormat);
            var credentialString = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}/{3}/{4}/", iCreds.AccessKey, dateStamp, region.SystemName, "s3", Runtime.Internal.Auth.AWS4Signer.Terminator);

            Dictionary<string, string> extraConditions = new Dictionary<string, string> {
                { S3Constants.PostFormDataXAmzCredential, credentialString },
                { S3Constants.PostFormDataXAmzAlgorithm, algorithm },
                { S3Constants.PostFormDataXAmzDate, dateTimeStamp }
            };
            if (iCreds.UseToken) { extraConditions[S3Constants.PostFormDataSecurityToken] = iCreds.Token; }

            var policyBytes = addConditionsToPolicy(policy, extraConditions);

            var base64Policy = Convert.ToBase64String(policyBytes);

            var signingKey = Runtime.Internal.Auth.AWS4Signer.ComposeSigningKey(iCreds.SecretKey, region.SystemName, dateStamp, "s3");

            var signature = AWSSDKUtils.ToHex(Runtime.Internal.Auth.AWS4Signer.ComputeKeyedHash(SigningAlgorithm.HmacSHA256, signingKey, base64Policy), true);

            return new S3PostUploadSignedPolicy
            {
                Policy = base64Policy,
                Signature = signature,
                AccessKeyId = iCreds.AccessKey,
                SecurityToken = iCreds.Token,
                Algorithm = algorithm,
                Date = dateTimeStamp,
                Credential = credentialString
            };
        }

        private static byte[] addConditionsToPolicy(string policy, Dictionary<string, string> newConditions)
        {
            var json = JsonNode.Parse(policy, null, options) as JsonObject;
            var jsonConditions = json["conditions"] as JsonArray;

            if (jsonConditions != null)
            {
                foreach (var newCond in newConditions)
                {
                    bool found = false;
                    for (int i = 0; i < jsonConditions.Count; i++)
                    {
                        if (jsonConditions[i] is JsonObject obj && obj.ContainsKey(newCond.Key))
                        {
                            obj[newCond.Key] = newCond.Value;
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        var newCondition = new JsonObject
                        {
                            [newCond.Key] = newCond.Value
                        };
                        jsonConditions.Add(newCondition);
                    }
                }
            }
            return Encoding.UTF8.GetBytes(json.ToJsonString().Trim());
        }
        
        /// <summary>
        /// The policy document which governs what uploads can be done.
        /// </summary>
        public string Policy { get; set; }

        /// <summary>
        /// The signature for the policy.
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// The AWS Access Key Id for the credential pair that produced the signature.
        /// </summary>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// The security token from session or instance credentials.
        /// </summary>
        public string SecurityToken { get; set; }
        
        /// <summary>
        /// The signing algorithm used. Required as a field in the post Amazon
        /// S3 can re-calculate the signature.
        /// </summary>
        public string Algorithm { get; set; }

        /// <summary>
        /// The date value in ISO8601 format. It is the same date used in
        /// creating the signing key.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// In addition to the access key ID, this provides scope information
        /// used in calculating the signing key for signature calculation. 
        /// </summary>
        public string Credential { get; set; }

        /// <summary>
        /// Get the policy document as a human readable string.
        /// </summary>
        /// <returns>Human readable policy document.</returns>
        public string GetReadablePolicy()
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(this.Policy));
        }

        private static string
            KEY_POLICY = "policy",
            KEY_SIGNATURE = "signature",
            KEY_ACCESSKEY = "access_key";

        /// <summary>
        /// JSON representation of this object
        /// </summary>
        /// <returns>JSON string</returns>
        public string ToJson()
        {
            var json = new JsonObject
            {
                [KEY_POLICY] = this.Policy,
                [KEY_SIGNATURE] = this.Signature,
                [KEY_ACCESSKEY] = this.AccessKeyId
            };

            return json.ToJsonString();
        }

        /// <summary>
        /// XML Representation of this object
        /// </summary>
        /// <returns>XML String</returns>
        public string ToXml()
        {
            StringBuilder xml = new StringBuilder(1024);
            var serializer = new XmlSerializer(this.GetType());
            using (StringWriter sw = new StringWriter(xml, CultureInfo.InvariantCulture))
            {
                serializer.Serialize(sw, this);
            }
            return xml.ToString();
        }

        /// <summary>
        /// Create an instance of this class from a JSON string.
        /// </summary>
        /// <param name="policyJson">JSON string</param>
        /// <returns>Instance of S3PostUploadSignedPolicy</returns>
        public static S3PostUploadSignedPolicy GetSignedPolicyFromJson(string policyJson)
        {
            try
            {
                using (var doc = JsonDocument.Parse(policyJson))
                {
                    var json = doc.RootElement;

                    // Check if required fields exist and are of the correct type
                    if (!json.TryGetProperty(KEY_POLICY, out var policyNode) || policyNode.ValueKind != JsonValueKind.String)
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "JSON document requires '{0}' field"), KEY_POLICY);
                    if (!json.TryGetProperty(KEY_SIGNATURE, out var signatureNode) || signatureNode.ValueKind != JsonValueKind.String)
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "JSON document requires '{0}' field"), KEY_SIGNATURE);
                    if (!json.TryGetProperty(KEY_ACCESSKEY, out var accessKeyNode) || accessKeyNode.ValueKind != JsonValueKind.String)
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "JSON document requires '{0}' field"), KEY_ACCESSKEY);

                    return new S3PostUploadSignedPolicy
                    {
                        Policy = policyNode.GetString(),
                        Signature = signatureNode.GetString(),
                        AccessKeyId = accessKeyNode.GetString()
                    };
                }
            }
            catch (JsonException e)
            {
                throw new ArgumentException("Invalid JSON document", e);
            }
        }

        /// <summary>
        /// Create an instance of this class from an XML string.
        /// </summary>
        /// <param name="policyXml">XML string generated by ToXml()</param>
        /// <returns>Instance of S3PostUploadSignedPolicy</returns>
        public static S3PostUploadSignedPolicy GetSignedPolicyFromXml(string policyXml)
        {
            var reader = new StringReader(policyXml);
            XmlSerializer serializer = new XmlSerializer(typeof(S3PostUploadSignedPolicy));

            S3PostUploadSignedPolicy policy;
            try
            {
                policy = serializer.Deserialize(reader) as S3PostUploadSignedPolicy;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Could not parse XML", e);
            }

            if (String.IsNullOrEmpty(policy.AccessKeyId))
                throw new ArgumentException("XML Document requries 'AccessKeyId' field");
            if (String.IsNullOrEmpty(policy.Policy))
                throw new ArgumentException("XML Document requries 'Policy' field");
            if (String.IsNullOrEmpty(policy.Signature))
                throw new ArgumentException("XML Document requries 'Signature' field");

            return policy;
        }
    }
}
