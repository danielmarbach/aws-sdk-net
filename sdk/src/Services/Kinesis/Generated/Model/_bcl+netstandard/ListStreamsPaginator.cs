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
 * Do not modify this file. This file is generated from the kinesis-2013-12-02.normal.json service model.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;

#pragma warning disable CS0612,CS0618
namespace Amazon.Kinesis.Model
{
    /// <summary>
    /// Base class for ListStreams paginators.
    /// </summary>
    internal sealed partial class ListStreamsPaginator : IPaginator<ListStreamsResponse>, IListStreamsPaginator
    {
        private readonly IAmazonKinesis _client;
        private readonly ListStreamsRequest _request;
        private int _isPaginatorInUse = 0;
        
        /// <summary>
        /// Enumerable containing all full responses for the operation
        /// </summary>
        public IPaginatedEnumerable<ListStreamsResponse> Responses => new PaginatedResponse<ListStreamsResponse>(this);

        /// <summary>
        /// Enumerable containing all of the StreamNames
        /// </summary>
        public IPaginatedEnumerable<string> StreamNames => 
            new PaginatedResultKeyResponse<ListStreamsResponse, string>(this, (i) => i.StreamNames ?? new List<string>());

        /// <summary>
        /// Enumerable containing all of the StreamSummaries
        /// </summary>
        public IPaginatedEnumerable<StreamSummary> StreamSummaries => 
            new PaginatedResultKeyResponse<ListStreamsResponse, StreamSummary>(this, (i) => i.StreamSummaries ?? new List<StreamSummary>());

        internal ListStreamsPaginator(IAmazonKinesis client, ListStreamsRequest request)
        {
            this._client = client;
            this._request = request;
        }
#if BCL
        IEnumerable<ListStreamsResponse> IPaginator<ListStreamsResponse>.Paginate()
        {
            if (Interlocked.Exchange(ref _isPaginatorInUse, 1) != 0)
            {
                throw new System.InvalidOperationException("Paginator has already been consumed and cannot be reused. Please create a new instance.");
            }
            PaginatorUtils.SetUserAgentAdditionOnRequest(_request);
            var nextToken = _request.NextToken;
            ListStreamsResponse response;
            do
            {
                _request.NextToken = nextToken;
                response = _client.ListStreams(_request);
                nextToken = response.NextToken;
                yield return response;
            }
            while (response.HasMoreStreams.GetValueOrDefault());
        }
#endif
#if AWS_ASYNC_ENUMERABLES_API
        async IAsyncEnumerable<ListStreamsResponse> IPaginator<ListStreamsResponse>.PaginateAsync([System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken)
        {
            if (Interlocked.Exchange(ref _isPaginatorInUse, 1) != 0)
            {
                throw new System.InvalidOperationException("Paginator has already been consumed and cannot be reused. Please create a new instance.");
            }
            PaginatorUtils.SetUserAgentAdditionOnRequest(_request);
            var nextToken = _request.NextToken;
            ListStreamsResponse response;
            do
            {
                _request.NextToken = nextToken;
                response = await _client.ListStreamsAsync(_request, cancellationToken).ConfigureAwait(false);
                nextToken = response.NextToken;
                cancellationToken.ThrowIfCancellationRequested();
                yield return response;
            }
            while (response.HasMoreStreams.GetValueOrDefault());
        }
#endif
    }
}