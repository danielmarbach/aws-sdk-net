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
 * Do not modify this file. This file is generated from the cognito-idp-2016-04-18.normal.json service model.
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
namespace Amazon.CognitoIdentityProvider.Model
{
    /// <summary>
    /// This is the response object from the UpdateResourceServer operation.
    /// </summary>
    public partial class UpdateResourceServerResponse : AmazonWebServiceResponse
    {
        private ResourceServerType _resourceServer;

        /// <summary>
        /// Gets and sets the property ResourceServer. 
        /// <para>
        /// The updated details of the requested resource server.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true)]
        public ResourceServerType ResourceServer
        {
            get { return this._resourceServer; }
            set { this._resourceServer = value; }
        }

        // Check to see if ResourceServer property is set
        internal bool IsSetResourceServer()
        {
            return this._resourceServer != null;
        }

    }
}