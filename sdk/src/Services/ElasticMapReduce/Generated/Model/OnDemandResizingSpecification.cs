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
 * Do not modify this file. This file is generated from the elasticmapreduce-2009-03-31.normal.json service model.
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
namespace Amazon.ElasticMapReduce.Model
{
    /// <summary>
    /// The resize specification for On-Demand Instances in the instance fleet, which contains
    /// the resize timeout period.
    /// </summary>
    public partial class OnDemandResizingSpecification
    {
        private OnDemandProvisioningAllocationStrategy _allocationStrategy;
        private OnDemandCapacityReservationOptions _capacityReservationOptions;
        private int? _timeoutDurationMinutes;

        /// <summary>
        /// Gets and sets the property AllocationStrategy. 
        /// <para>
        /// Specifies the allocation strategy to use to launch On-Demand instances during a resize.
        /// The default is <c>lowest-price</c>.
        /// </para>
        /// </summary>
        public OnDemandProvisioningAllocationStrategy AllocationStrategy
        {
            get { return this._allocationStrategy; }
            set { this._allocationStrategy = value; }
        }

        // Check to see if AllocationStrategy property is set
        internal bool IsSetAllocationStrategy()
        {
            return this._allocationStrategy != null;
        }

        /// <summary>
        /// Gets and sets the property CapacityReservationOptions.
        /// </summary>
        public OnDemandCapacityReservationOptions CapacityReservationOptions
        {
            get { return this._capacityReservationOptions; }
            set { this._capacityReservationOptions = value; }
        }

        // Check to see if CapacityReservationOptions property is set
        internal bool IsSetCapacityReservationOptions()
        {
            return this._capacityReservationOptions != null;
        }

        /// <summary>
        /// Gets and sets the property TimeoutDurationMinutes. 
        /// <para>
        /// On-Demand resize timeout in minutes. If On-Demand Instances are not provisioned within
        /// this time, the resize workflow stops. The minimum value is 5 minutes, and the maximum
        /// value is 10,080 minutes (7 days). The timeout applies to all resize workflows on the
        /// Instance Fleet. The resize could be triggered by Amazon EMR Managed Scaling or by
        /// the customer (via Amazon EMR Console, Amazon EMR CLI modify-instance-fleet or Amazon
        /// EMR SDK ModifyInstanceFleet API) or by Amazon EMR due to Amazon EC2 Spot Reclamation.
        /// </para>
        /// </summary>
        [AWSProperty(Min=0)]
        public int? TimeoutDurationMinutes
        {
            get { return this._timeoutDurationMinutes; }
            set { this._timeoutDurationMinutes = value; }
        }

        // Check to see if TimeoutDurationMinutes property is set
        internal bool IsSetTimeoutDurationMinutes()
        {
            return this._timeoutDurationMinutes.HasValue; 
        }

    }
}