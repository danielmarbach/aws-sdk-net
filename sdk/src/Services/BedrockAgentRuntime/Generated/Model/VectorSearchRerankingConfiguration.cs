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
 * Do not modify this file. This file is generated from the bedrock-agent-runtime-2023-07-26.normal.json service model.
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
namespace Amazon.BedrockAgentRuntime.Model
{
    /// <summary>
    /// Contains configurations for reranking the retrieved results.
    /// </summary>
    public partial class VectorSearchRerankingConfiguration
    {
        private VectorSearchBedrockRerankingConfiguration _bedrockRerankingConfiguration;
        private VectorSearchRerankingConfigurationType _type;

        /// <summary>
        /// Gets and sets the property BedrockRerankingConfiguration. 
        /// <para>
        /// Contains configurations for an Amazon Bedrock reranker model.
        /// </para>
        /// </summary>
        public VectorSearchBedrockRerankingConfiguration BedrockRerankingConfiguration
        {
            get { return this._bedrockRerankingConfiguration; }
            set { this._bedrockRerankingConfiguration = value; }
        }

        // Check to see if BedrockRerankingConfiguration property is set
        internal bool IsSetBedrockRerankingConfiguration()
        {
            return this._bedrockRerankingConfiguration != null;
        }

        /// <summary>
        /// Gets and sets the property Type. 
        /// <para>
        /// The type of reranker model.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true)]
        public VectorSearchRerankingConfigurationType Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        // Check to see if Type property is set
        internal bool IsSetType()
        {
            return this._type != null;
        }

    }
}