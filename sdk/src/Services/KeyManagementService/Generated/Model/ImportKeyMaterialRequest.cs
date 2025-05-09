/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

/*
 * Do not modify this file. This file is generated from the kms-2014-11-01.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Net;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

#pragma warning disable CS0612,CS0618,CS1570
namespace Amazon.KeyManagementService.Model
{
    /// <summary>
    /// Container for the parameters to the ImportKeyMaterial operation.
    /// Imports or reimports key material into an existing KMS key that was created without
    /// key material. <c>ImportKeyMaterial</c> also sets the expiration model and expiration
    /// date of the imported key material.
    /// 
    ///  
    /// <para>
    /// By default, KMS keys are created with key material that KMS generates. This operation
    /// supports <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
    /// key material</a>, an advanced feature that lets you generate and import the cryptographic
    /// key material for a KMS key. For more information about importing key material into
    /// KMS, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
    /// key material</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para>
    ///  
    /// <para>
    /// After you successfully import key material into a KMS key, you can <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html#reimport-key-material">reimport
    /// the same key material</a> into that KMS key, but you cannot import different key material.
    /// You might reimport key material to replace key material that expired or key material
    /// that you deleted. You might also reimport key material to change the expiration model
    /// or expiration date of the key material. 
    /// </para>
    ///  
    /// <para>
    /// Each time you import key material into KMS, you can determine whether (<c>ExpirationModel</c>)
    /// and when (<c>ValidTo</c>) the key material expires. To change the expiration of your
    /// key material, you must import it again, either by calling <c>ImportKeyMaterial</c>
    /// or using the <a href="kms/latest/developerguide/importing-keys-import-key-material.html#importing-keys-import-key-material-console">import
    /// features</a> of the KMS console.
    /// </para>
    ///  
    /// <para>
    /// Before calling <c>ImportKeyMaterial</c>:
    /// </para>
    ///  <ul> <li> 
    /// <para>
    /// Create or identify a KMS key with no key material. The KMS key must have an <c>Origin</c>
    /// value of <c>EXTERNAL</c>, which indicates that the KMS key is designed for imported
    /// key material. 
    /// </para>
    ///  
    /// <para>
    /// To create an new KMS key for imported key material, call the <a>CreateKey</a> operation
    /// with an <c>Origin</c> value of <c>EXTERNAL</c>. You can create a symmetric encryption
    /// KMS key, HMAC KMS key, asymmetric encryption KMS key, or asymmetric signing KMS key.
    /// You can also import key material into a <a href="kms/latest/developerguide/multi-region-keys-overview.html">multi-Region
    /// key</a> of any supported type. However, you can't import key material into a KMS key
    /// in a <a href="kms/latest/developerguide/custom-key-store-overview.html">custom key
    /// store</a>.
    /// </para>
    ///  </li> <li> 
    /// <para>
    /// Use the <a>DescribeKey</a> operation to verify that the <c>KeyState</c> of the KMS
    /// key is <c>PendingImport</c>, which indicates that the KMS key has no key material.
    /// 
    /// </para>
    ///  
    /// <para>
    /// If you are reimporting the same key material into an existing KMS key, you might need
    /// to call the <a>DeleteImportedKeyMaterial</a> to delete its existing key material.
    /// </para>
    ///  </li> <li> 
    /// <para>
    /// Call the <a>GetParametersForImport</a> operation to get a public key and import token
    /// set for importing key material. 
    /// </para>
    ///  </li> <li> 
    /// <para>
    /// Use the public key in the <a>GetParametersForImport</a> response to encrypt your key
    /// material.
    /// </para>
    ///  </li> </ul> 
    /// <para>
    ///  Then, in an <c>ImportKeyMaterial</c> request, you submit your encrypted key material
    /// and import token. When calling this operation, you must specify the following values:
    /// </para>
    ///  <ul> <li> 
    /// <para>
    /// The key ID or key ARN of the KMS key to associate with the imported key material.
    /// Its <c>Origin</c> must be <c>EXTERNAL</c> and its <c>KeyState</c> must be <c>PendingImport</c>.
    /// You cannot perform this operation on a KMS key in a <a href="kms/latest/developerguide/custom-key-store-overview.html">custom
    /// key store</a>, or on a KMS key in a different Amazon Web Services account. To get
    /// the <c>Origin</c> and <c>KeyState</c> of a KMS key, call <a>DescribeKey</a>.
    /// </para>
    ///  </li> <li> 
    /// <para>
    /// The encrypted key material. 
    /// </para>
    ///  </li> <li> 
    /// <para>
    /// The import token that <a>GetParametersForImport</a> returned. You must use a public
    /// key and token from the same <c>GetParametersForImport</c> response.
    /// </para>
    ///  </li> <li> 
    /// <para>
    /// Whether the key material expires (<c>ExpirationModel</c>) and, if so, when (<c>ValidTo</c>).
    /// For help with this choice, see <a href="https://docs.aws.amazon.com/en_us/kms/latest/developerguide/importing-keys.html#importing-keys-expiration">Setting
    /// an expiration time</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para>
    ///  
    /// <para>
    /// If you set an expiration date, KMS deletes the key material from the KMS key on the
    /// specified date, making the KMS key unusable. To use the KMS key in cryptographic operations
    /// again, you must reimport the same key material. However, you can delete and reimport
    /// the key material at any time, including before the key material expires. Each time
    /// you reimport, you can eliminate or reset the expiration time.
    /// </para>
    ///  </li> </ul> 
    /// <para>
    /// When this operation is successful, the key state of the KMS key changes from <c>PendingImport</c>
    /// to <c>Enabled</c>, and you can use the KMS key in cryptographic operations.
    /// </para>
    ///  
    /// <para>
    /// If this operation fails, use the exception to help determine the problem. If the error
    /// is related to the key material, the import token, or wrapping key, use <a>GetParametersForImport</a>
    /// to get a new public key and import token for the KMS key and repeat the import procedure.
    /// For help, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html#importing-keys-overview">How
    /// To Import Key Material</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para>
    ///  
    /// <para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para>
    ///  
    /// <para>
    ///  <b>Cross-account use</b>: No. You cannot perform this operation on a KMS key in a
    /// different Amazon Web Services account.
    /// </para>
    ///  
    /// <para>
    ///  <b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:ImportKeyMaterial</a>
    /// (key policy)
    /// </para>
    ///  
    /// <para>
    ///  <b>Related operations:</b> 
    /// </para>
    ///  <ul> <li> 
    /// <para>
    ///  <a>DeleteImportedKeyMaterial</a> 
    /// </para>
    ///  </li> <li> 
    /// <para>
    ///  <a>GetParametersForImport</a> 
    /// </para>
    ///  </li> </ul> 
    /// <para>
    ///  <b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    public partial class ImportKeyMaterialRequest : AmazonKeyManagementServiceRequest
    {
        private MemoryStream _encryptedKeyMaterial;
        private ExpirationModelType _expirationModel;
        private MemoryStream _importToken;
        private string _keyId;
        private DateTime? _validTo;

        /// <summary>
        /// Gets and sets the property EncryptedKeyMaterial. 
        /// <para>
        /// The encrypted key material to import. The key material must be encrypted under the
        /// public wrapping key that <a>GetParametersForImport</a> returned, using the wrapping
        /// algorithm that you specified in the same <c>GetParametersForImport</c> request.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true, Min=1, Max=6144)]
        public MemoryStream EncryptedKeyMaterial
        {
            get { return this._encryptedKeyMaterial; }
            set { this._encryptedKeyMaterial = value; }
        }

        // Check to see if EncryptedKeyMaterial property is set
        internal bool IsSetEncryptedKeyMaterial()
        {
            return this._encryptedKeyMaterial != null;
        }

        /// <summary>
        /// Gets and sets the property ExpirationModel. 
        /// <para>
        /// Specifies whether the key material expires. The default is <c>KEY_MATERIAL_EXPIRES</c>.
        /// For help with this choice, see <a href="https://docs.aws.amazon.com/en_us/kms/latest/developerguide/importing-keys.html#importing-keys-expiration">Setting
        /// an expiration time</a> in the <i>Key Management Service Developer Guide</i>.
        /// </para>
        ///  
        /// <para>
        /// When the value of <c>ExpirationModel</c> is <c>KEY_MATERIAL_EXPIRES</c>, you must
        /// specify a value for the <c>ValidTo</c> parameter. When value is <c>KEY_MATERIAL_DOES_NOT_EXPIRE</c>,
        /// you must omit the <c>ValidTo</c> parameter.
        /// </para>
        ///  
        /// <para>
        /// You cannot change the <c>ExpirationModel</c> or <c>ValidTo</c> values for the current
        /// import after the request completes. To change either value, you must reimport the
        /// key material.
        /// </para>
        /// </summary>
        public ExpirationModelType ExpirationModel
        {
            get { return this._expirationModel; }
            set { this._expirationModel = value; }
        }

        // Check to see if ExpirationModel property is set
        internal bool IsSetExpirationModel()
        {
            return this._expirationModel != null;
        }

        /// <summary>
        /// Gets and sets the property ImportToken. 
        /// <para>
        /// The import token that you received in the response to a previous <a>GetParametersForImport</a>
        /// request. It must be from the same response that contained the public key that you
        /// used to encrypt the key material.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true, Min=1, Max=6144)]
        public MemoryStream ImportToken
        {
            get { return this._importToken; }
            set { this._importToken = value; }
        }

        // Check to see if ImportToken property is set
        internal bool IsSetImportToken()
        {
            return this._importToken != null;
        }

        /// <summary>
        /// Gets and sets the property KeyId. 
        /// <para>
        /// The identifier of the KMS key that will be associated with the imported key material.
        /// This must be the same KMS key specified in the <c>KeyID</c> parameter of the corresponding
        /// <a>GetParametersForImport</a> request. The <c>Origin</c> of the KMS key must be <c>EXTERNAL</c>
        /// and its <c>KeyState</c> must be <c>PendingImport</c>. 
        /// </para>
        ///  
        /// <para>
        /// The KMS key can be a symmetric encryption KMS key, HMAC KMS key, asymmetric encryption
        /// KMS key, or asymmetric signing KMS key, including a <a href="kms/latest/developerguide/multi-region-keys-overview.html">multi-Region
        /// key</a> of any supported type. You cannot perform this operation on a KMS key in a
        /// custom key store, or on a KMS key in a different Amazon Web Services account.
        /// </para>
        ///  
        /// <para>
        /// Specify the key ID or key ARN of the KMS key.
        /// </para>
        ///  
        /// <para>
        /// For example:
        /// </para>
        ///  <ul> <li> 
        /// <para>
        /// Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c> 
        /// </para>
        ///  </li> <li> 
        /// <para>
        /// Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c>
        /// 
        /// </para>
        ///  </li> </ul> 
        /// <para>
        /// To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true, Min=1, Max=2048)]
        public string KeyId
        {
            get { return this._keyId; }
            set { this._keyId = value; }
        }

        // Check to see if KeyId property is set
        internal bool IsSetKeyId()
        {
            return this._keyId != null;
        }

        /// <summary>
        /// Gets and sets the property ValidTo. 
        /// <para>
        /// The date and time when the imported key material expires. This parameter is required
        /// when the value of the <c>ExpirationModel</c> parameter is <c>KEY_MATERIAL_EXPIRES</c>.
        /// Otherwise it is not valid.
        /// </para>
        ///  
        /// <para>
        /// The value of this parameter must be a future date and time. The maximum value is 365
        /// days from the request date.
        /// </para>
        ///  
        /// <para>
        /// When the key material expires, KMS deletes the key material from the KMS key. Without
        /// its key material, the KMS key is unusable. To use the KMS key in cryptographic operations,
        /// you must reimport the same key material.
        /// </para>
        ///  
        /// <para>
        /// You cannot change the <c>ExpirationModel</c> or <c>ValidTo</c> values for the current
        /// import after the request completes. To change either value, you must delete (<a>DeleteImportedKeyMaterial</a>)
        /// and reimport the key material.
        /// </para>
        /// </summary>
        public DateTime? ValidTo
        {
            get { return this._validTo; }
            set { this._validTo = value; }
        }

        // Check to see if ValidTo property is set
        internal bool IsSetValidTo()
        {
            return this._validTo.HasValue; 
        }

    }
}