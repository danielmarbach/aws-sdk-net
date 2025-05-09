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
 * Do not modify this file. This file is generated from the privatenetworks-2021-12-03.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Amazon.Private5G.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using System.Text.Json;
using System.Buffers;
#if !NETFRAMEWORK
using ThirdParty.RuntimeBackports;
#endif
#pragma warning disable CS0612,CS0618
namespace Amazon.Private5G.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// StartNetworkResourceUpdate Request Marshaller
    /// </summary>       
    public class StartNetworkResourceUpdateRequestMarshaller : IMarshaller<IRequest, StartNetworkResourceUpdateRequest> , IMarshaller<IRequest,AmazonWebServiceRequest>
    {
        /// <summary>
        /// Marshaller the request object to the HTTP request.
        /// </summary>  
        /// <param name="input"></param>
        /// <returns></returns>
        public IRequest Marshall(AmazonWebServiceRequest input)
        {
            return this.Marshall((StartNetworkResourceUpdateRequest)input);
        }

        /// <summary>
        /// Marshaller the request object to the HTTP request.
        /// </summary>  
        /// <param name="publicRequest"></param>
        /// <returns></returns>
        public IRequest Marshall(StartNetworkResourceUpdateRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.Private5G");
            request.Headers["Content-Type"] = "application/json";
            request.Headers[Amazon.Util.HeaderKeys.XAmzApiVersion] = "2021-12-03";
            request.HttpMethod = "POST";

            request.ResourcePath = "/v1/network-resources/update";
#if !NETFRAMEWORK
            using ArrayPoolBufferWriter<byte> arrayPoolBufferWriter = new ArrayPoolBufferWriter<byte>();
            using Utf8JsonWriter writer = new Utf8JsonWriter(arrayPoolBufferWriter);
#else
            using var memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
#endif
            writer.WriteStartObject();
            var context = new JsonMarshallerContext(request, writer);
            if(publicRequest.IsSetCommitmentConfiguration())
            {
                context.Writer.WritePropertyName("commitmentConfiguration");
                context.Writer.WriteStartObject();

                var marshaller = CommitmentConfigurationMarshaller.Instance;
                marshaller.Marshall(publicRequest.CommitmentConfiguration, context);

                context.Writer.WriteEndObject();
            }

            if(publicRequest.IsSetNetworkResourceArn())
            {
                context.Writer.WritePropertyName("networkResourceArn");
                context.Writer.WriteStringValue(publicRequest.NetworkResourceArn);
            }

            if(publicRequest.IsSetReturnReason())
            {
                context.Writer.WritePropertyName("returnReason");
                context.Writer.WriteStringValue(publicRequest.ReturnReason);
            }

            if(publicRequest.IsSetShippingAddress())
            {
                context.Writer.WritePropertyName("shippingAddress");
                context.Writer.WriteStartObject();

                var marshaller = AddressMarshaller.Instance;
                marshaller.Marshall(publicRequest.ShippingAddress, context);

                context.Writer.WriteEndObject();
            }

            if(publicRequest.IsSetUpdateType())
            {
                context.Writer.WritePropertyName("updateType");
                context.Writer.WriteStringValue(publicRequest.UpdateType);
            }

            writer.WriteEndObject();
            writer.Flush();
            // ToArray() must be called here because aspects of sigv4 signing require a byte array
#if !NETFRAMEWORK
            request.Content = arrayPoolBufferWriter.WrittenMemory.ToArray();
#else
            request.Content = memoryStream.ToArray();
#endif
            


            return request;
        }
        private static StartNetworkResourceUpdateRequestMarshaller _instance = new StartNetworkResourceUpdateRequestMarshaller();        

        internal static StartNetworkResourceUpdateRequestMarshaller GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// Gets the singleton.
        /// </summary>  
        public static StartNetworkResourceUpdateRequestMarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}