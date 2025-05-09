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
 * Do not modify this file. This file is generated from the opensearch-2021-01-01.normal.json service model.
 */
using Amazon.Runtime.Internal;

#pragma warning disable CS0612,CS0618
namespace Amazon.OpenSearchService.Model
{
    /// <summary>
    /// Paginators for the OpenSearchService service
    ///</summary>
    public interface IOpenSearchServicePaginatorFactory
    {

        /// <summary>
        /// Paginator for DescribeDomainAutoTunes operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IDescribeDomainAutoTunesPaginator DescribeDomainAutoTunes(DescribeDomainAutoTunesRequest request);

        /// <summary>
        /// Paginator for DescribeInboundConnections operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IDescribeInboundConnectionsPaginator DescribeInboundConnections(DescribeInboundConnectionsRequest request);

        /// <summary>
        /// Paginator for DescribeOutboundConnections operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IDescribeOutboundConnectionsPaginator DescribeOutboundConnections(DescribeOutboundConnectionsRequest request);

        /// <summary>
        /// Paginator for DescribePackages operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IDescribePackagesPaginator DescribePackages(DescribePackagesRequest request);

        /// <summary>
        /// Paginator for DescribeReservedInstanceOfferings operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IDescribeReservedInstanceOfferingsPaginator DescribeReservedInstanceOfferings(DescribeReservedInstanceOfferingsRequest request);

        /// <summary>
        /// Paginator for DescribeReservedInstances operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IDescribeReservedInstancesPaginator DescribeReservedInstances(DescribeReservedInstancesRequest request);

        /// <summary>
        /// Paginator for GetPackageVersionHistory operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IGetPackageVersionHistoryPaginator GetPackageVersionHistory(GetPackageVersionHistoryRequest request);

        /// <summary>
        /// Paginator for GetUpgradeHistory operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IGetUpgradeHistoryPaginator GetUpgradeHistory(GetUpgradeHistoryRequest request);

        /// <summary>
        /// Paginator for ListApplications operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IListApplicationsPaginator ListApplications(ListApplicationsRequest request);

        /// <summary>
        /// Paginator for ListDomainMaintenances operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IListDomainMaintenancesPaginator ListDomainMaintenances(ListDomainMaintenancesRequest request);

        /// <summary>
        /// Paginator for ListDomainsForPackage operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IListDomainsForPackagePaginator ListDomainsForPackage(ListDomainsForPackageRequest request);

        /// <summary>
        /// Paginator for ListInstanceTypeDetails operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IListInstanceTypeDetailsPaginator ListInstanceTypeDetails(ListInstanceTypeDetailsRequest request);

        /// <summary>
        /// Paginator for ListPackagesForDomain operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IListPackagesForDomainPaginator ListPackagesForDomain(ListPackagesForDomainRequest request);

        /// <summary>
        /// Paginator for ListScheduledActions operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IListScheduledActionsPaginator ListScheduledActions(ListScheduledActionsRequest request);

        /// <summary>
        /// Paginator for ListVersions operation
        ///</summary>
        [AWSPaginator(
            InputToken = new[] { "NextToken" },
            LimitKey = "MaxResults",
            OutputToken = new[] { "NextToken" }
        )]
        IListVersionsPaginator ListVersions(ListVersionsRequest request);
    }
}