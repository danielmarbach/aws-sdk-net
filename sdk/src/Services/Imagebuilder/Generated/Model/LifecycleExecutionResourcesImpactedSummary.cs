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
 * Do not modify this file. This file is generated from the imagebuilder-2019-12-02.normal.json service model.
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
namespace Amazon.Imagebuilder.Model
{
    /// <summary>
    /// Contains details for an image resource that was identified for a lifecycle action.
    /// </summary>
    public partial class LifecycleExecutionResourcesImpactedSummary
    {
        private bool? _hasImpactedResources;

        /// <summary>
        /// Gets and sets the property HasImpactedResources. 
        /// <para>
        /// Indicates whether an image resource that was identified for a lifecycle action has
        /// associated resources that are also impacted.
        /// </para>
        /// </summary>
        public bool? HasImpactedResources
        {
            get { return this._hasImpactedResources; }
            set { this._hasImpactedResources = value; }
        }

        // Check to see if HasImpactedResources property is set
        internal bool IsSetHasImpactedResources()
        {
            return this._hasImpactedResources.HasValue; 
        }

    }
}