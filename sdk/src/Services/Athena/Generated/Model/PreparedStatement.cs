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
 * Do not modify this file. This file is generated from the athena-2017-05-18.normal.json service model.
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
namespace Amazon.Athena.Model
{
    /// <summary>
    /// A prepared SQL statement for use with Athena.
    /// </summary>
    public partial class PreparedStatement
    {
        private string _description;
        private DateTime? _lastModifiedTime;
        private string _queryStatement;
        private string _statementName;
        private string _workGroupName;

        /// <summary>
        /// Gets and sets the property Description. 
        /// <para>
        /// The description of the prepared statement.
        /// </para>
        /// </summary>
        [AWSProperty(Min=1, Max=1024)]
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        // Check to see if Description property is set
        internal bool IsSetDescription()
        {
            return this._description != null;
        }

        /// <summary>
        /// Gets and sets the property LastModifiedTime. 
        /// <para>
        /// The last modified time of the prepared statement.
        /// </para>
        /// </summary>
        public DateTime? LastModifiedTime
        {
            get { return this._lastModifiedTime; }
            set { this._lastModifiedTime = value; }
        }

        // Check to see if LastModifiedTime property is set
        internal bool IsSetLastModifiedTime()
        {
            return this._lastModifiedTime.HasValue; 
        }

        /// <summary>
        /// Gets and sets the property QueryStatement. 
        /// <para>
        /// The query string for the prepared statement.
        /// </para>
        /// </summary>
        [AWSProperty(Min=1, Max=262144)]
        public string QueryStatement
        {
            get { return this._queryStatement; }
            set { this._queryStatement = value; }
        }

        // Check to see if QueryStatement property is set
        internal bool IsSetQueryStatement()
        {
            return this._queryStatement != null;
        }

        /// <summary>
        /// Gets and sets the property StatementName. 
        /// <para>
        /// The name of the prepared statement.
        /// </para>
        /// </summary>
        [AWSProperty(Min=1, Max=256)]
        public string StatementName
        {
            get { return this._statementName; }
            set { this._statementName = value; }
        }

        // Check to see if StatementName property is set
        internal bool IsSetStatementName()
        {
            return this._statementName != null;
        }

        /// <summary>
        /// Gets and sets the property WorkGroupName. 
        /// <para>
        /// The name of the workgroup to which the prepared statement belongs.
        /// </para>
        /// </summary>
        public string WorkGroupName
        {
            get { return this._workGroupName; }
            set { this._workGroupName = value; }
        }

        // Check to see if WorkGroupName property is set
        internal bool IsSetWorkGroupName()
        {
            return this._workGroupName != null;
        }

    }
}