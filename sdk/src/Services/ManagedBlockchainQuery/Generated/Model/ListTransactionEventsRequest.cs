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
 * Do not modify this file. This file is generated from the managedblockchain-query-2023-05-04.normal.json service model.
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
namespace Amazon.ManagedBlockchainQuery.Model
{
    /// <summary>
    /// Container for the parameters to the ListTransactionEvents operation.
    /// Lists all the transaction events for a transaction 
    /// 
    ///  <note> 
    /// <para>
    /// This action will return transaction details for all transactions that are <i>confirmed</i>
    /// on the blockchain, even if they have not reached <a href="https://docs.aws.amazon.com/managed-blockchain/latest/ambq-dg/key-concepts.html#finality">finality</a>.
    /// 
    /// </para>
    ///  </note>
    /// </summary>
    public partial class ListTransactionEventsRequest : AmazonManagedBlockchainQueryRequest
    {
        private int? _maxResults;
        private QueryNetwork _network;
        private string _nextToken;
        private string _transactionHash;
        private string _transactionId;

        /// <summary>
        /// Gets and sets the property MaxResults. 
        /// <para>
        /// The maximum number of transaction events to list.
        /// </para>
        ///  
        /// <para>
        /// Default: <c>100</c> 
        /// </para>
        ///  <note> 
        /// <para>
        /// Even if additional results can be retrieved, the request can return less results than
        /// <c>maxResults</c> or an empty array of results.
        /// </para>
        ///  
        /// <para>
        /// To retrieve the next set of results, make another request with the returned <c>nextToken</c>
        /// value. The value of <c>nextToken</c> is <c>null</c> when there are no more results
        /// to return
        /// </para>
        ///  </note>
        /// </summary>
        [AWSProperty(Min=1, Max=250)]
        public int? MaxResults
        {
            get { return this._maxResults; }
            set { this._maxResults = value; }
        }

        // Check to see if MaxResults property is set
        internal bool IsSetMaxResults()
        {
            return this._maxResults.HasValue; 
        }

        /// <summary>
        /// Gets and sets the property Network. 
        /// <para>
        /// The blockchain network where the transaction events occurred.
        /// </para>
        /// </summary>
        [AWSProperty(Required=true)]
        public QueryNetwork Network
        {
            get { return this._network; }
            set { this._network = value; }
        }

        // Check to see if Network property is set
        internal bool IsSetNetwork()
        {
            return this._network != null;
        }

        /// <summary>
        /// Gets and sets the property NextToken. 
        /// <para>
        /// The pagination token that indicates the next set of results to retrieve.
        /// </para>
        /// </summary>
        [AWSProperty(Min=0, Max=131070)]
        public string NextToken
        {
            get { return this._nextToken; }
            set { this._nextToken = value; }
        }

        // Check to see if NextToken property is set
        internal bool IsSetNextToken()
        {
            return this._nextToken != null;
        }

        /// <summary>
        /// Gets and sets the property TransactionHash. 
        /// <para>
        /// The hash of a transaction. It is generated when a transaction is created.
        /// </para>
        /// </summary>
        public string TransactionHash
        {
            get { return this._transactionHash; }
            set { this._transactionHash = value; }
        }

        // Check to see if TransactionHash property is set
        internal bool IsSetTransactionHash()
        {
            return this._transactionHash != null;
        }

        /// <summary>
        /// Gets and sets the property TransactionId. 
        /// <para>
        /// The identifier of a Bitcoin transaction. It is generated when a transaction is created.
        /// </para>
        ///  <note> 
        /// <para>
        ///  <c>transactionId</c> is only supported on the Bitcoin networks.
        /// </para>
        ///  </note>
        /// </summary>
        public string TransactionId
        {
            get { return this._transactionId; }
            set { this._transactionId = value; }
        }

        // Check to see if TransactionId property is set
        internal bool IsSetTransactionId()
        {
            return this._transactionId != null;
        }

    }
}