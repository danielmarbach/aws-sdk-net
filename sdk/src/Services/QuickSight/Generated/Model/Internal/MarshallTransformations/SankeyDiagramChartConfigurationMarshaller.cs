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
 * Do not modify this file. This file is generated from the quicksight-2018-04-01.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Amazon.QuickSight.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
#pragma warning disable CS0612,CS0618
namespace Amazon.QuickSight.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// SankeyDiagramChartConfiguration Marshaller
    /// </summary>
    public class SankeyDiagramChartConfigurationMarshaller : IRequestMarshaller<SankeyDiagramChartConfiguration, JsonMarshallerContext> 
    {
        /// <summary>
        /// Unmarshaller the response from the service to the response class.
        /// </summary>  
        /// <param name="requestObject"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void Marshall(SankeyDiagramChartConfiguration requestObject, JsonMarshallerContext context)
        {
            if(requestObject == null)
                return;
            if(requestObject.IsSetDataLabels())
            {
                context.Writer.WritePropertyName("DataLabels");
                context.Writer.WriteStartObject();

                var marshaller = DataLabelOptionsMarshaller.Instance;
                marshaller.Marshall(requestObject.DataLabels, context);

                context.Writer.WriteEndObject();
            }

            if(requestObject.IsSetFieldWells())
            {
                context.Writer.WritePropertyName("FieldWells");
                context.Writer.WriteStartObject();

                var marshaller = SankeyDiagramFieldWellsMarshaller.Instance;
                marshaller.Marshall(requestObject.FieldWells, context);

                context.Writer.WriteEndObject();
            }

            if(requestObject.IsSetInteractions())
            {
                context.Writer.WritePropertyName("Interactions");
                context.Writer.WriteStartObject();

                var marshaller = VisualInteractionOptionsMarshaller.Instance;
                marshaller.Marshall(requestObject.Interactions, context);

                context.Writer.WriteEndObject();
            }

            if(requestObject.IsSetSortConfiguration())
            {
                context.Writer.WritePropertyName("SortConfiguration");
                context.Writer.WriteStartObject();

                var marshaller = SankeyDiagramSortConfigurationMarshaller.Instance;
                marshaller.Marshall(requestObject.SortConfiguration, context);

                context.Writer.WriteEndObject();
            }

        }

        /// <summary>
        /// Singleton Marshaller.
        /// </summary>
        public readonly static SankeyDiagramChartConfigurationMarshaller Instance = new SankeyDiagramChartConfigurationMarshaller();

    }
}