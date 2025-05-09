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
 * Do not modify this file. This file is generated from the inspector2-2020-06-08.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Amazon.Inspector2.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
#pragma warning disable CS0612,CS0618
namespace Amazon.Inspector2.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// PackageFilter Marshaller
    /// </summary>
    public class PackageFilterMarshaller : IRequestMarshaller<PackageFilter, JsonMarshallerContext> 
    {
        /// <summary>
        /// Unmarshaller the response from the service to the response class.
        /// </summary>  
        /// <param name="requestObject"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void Marshall(PackageFilter requestObject, JsonMarshallerContext context)
        {
            if(requestObject == null)
                return;
            if(requestObject.IsSetArchitecture())
            {
                context.Writer.WritePropertyName("architecture");
                context.Writer.WriteStartObject();

                var marshaller = StringFilterMarshaller.Instance;
                marshaller.Marshall(requestObject.Architecture, context);

                context.Writer.WriteEndObject();
            }

            if(requestObject.IsSetEpoch())
            {
                context.Writer.WritePropertyName("epoch");
                context.Writer.WriteStartObject();

                var marshaller = NumberFilterMarshaller.Instance;
                marshaller.Marshall(requestObject.Epoch, context);

                context.Writer.WriteEndObject();
            }

            if(requestObject.IsSetFilePath())
            {
                context.Writer.WritePropertyName("filePath");
                context.Writer.WriteStartObject();

                var marshaller = StringFilterMarshaller.Instance;
                marshaller.Marshall(requestObject.FilePath, context);

                context.Writer.WriteEndObject();
            }

            if(requestObject.IsSetName())
            {
                context.Writer.WritePropertyName("name");
                context.Writer.WriteStartObject();

                var marshaller = StringFilterMarshaller.Instance;
                marshaller.Marshall(requestObject.Name, context);

                context.Writer.WriteEndObject();
            }

            if(requestObject.IsSetRelease())
            {
                context.Writer.WritePropertyName("release");
                context.Writer.WriteStartObject();

                var marshaller = StringFilterMarshaller.Instance;
                marshaller.Marshall(requestObject.Release, context);

                context.Writer.WriteEndObject();
            }

            if(requestObject.IsSetSourceLambdaLayerArn())
            {
                context.Writer.WritePropertyName("sourceLambdaLayerArn");
                context.Writer.WriteStartObject();

                var marshaller = StringFilterMarshaller.Instance;
                marshaller.Marshall(requestObject.SourceLambdaLayerArn, context);

                context.Writer.WriteEndObject();
            }

            if(requestObject.IsSetSourceLayerHash())
            {
                context.Writer.WritePropertyName("sourceLayerHash");
                context.Writer.WriteStartObject();

                var marshaller = StringFilterMarshaller.Instance;
                marshaller.Marshall(requestObject.SourceLayerHash, context);

                context.Writer.WriteEndObject();
            }

            if(requestObject.IsSetVersion())
            {
                context.Writer.WritePropertyName("version");
                context.Writer.WriteStartObject();

                var marshaller = StringFilterMarshaller.Instance;
                marshaller.Marshall(requestObject.Version, context);

                context.Writer.WriteEndObject();
            }

        }

        /// <summary>
        /// Singleton Marshaller.
        /// </summary>
        public readonly static PackageFilterMarshaller Instance = new PackageFilterMarshaller();

    }
}