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
 * Do not modify this file. This file is generated from the lookoutmetrics-2017-07-25.normal.json service model.
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
namespace Amazon.LookoutMetrics.Model
{
    /// <summary>
    /// Aggregated statistics about a measure affected by an anomaly.
    /// </summary>
    public partial class ItemizedMetricStats
    {
        private string _metricName;
        private int? _occurrenceCount;

        /// <summary>
        /// Gets and sets the property MetricName. 
        /// <para>
        /// The name of the measure.
        /// </para>
        /// </summary>
        [AWSProperty(Min=1, Max=63)]
        public string MetricName
        {
            get { return this._metricName; }
            set { this._metricName = value; }
        }

        // Check to see if MetricName property is set
        internal bool IsSetMetricName()
        {
            return this._metricName != null;
        }

        /// <summary>
        /// Gets and sets the property OccurrenceCount. 
        /// <para>
        /// The number of times that the measure appears.
        /// </para>
        /// </summary>
        public int? OccurrenceCount
        {
            get { return this._occurrenceCount; }
            set { this._occurrenceCount = value; }
        }

        // Check to see if OccurrenceCount property is set
        internal bool IsSetOccurrenceCount()
        {
            return this._occurrenceCount.HasValue; 
        }

    }
}