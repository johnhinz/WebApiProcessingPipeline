using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;

namespace WebApplication15
{
    public class HumberMessageProcesser : MessageProcessingHandler
    {

        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("I'm Here");
            return request;
        }

        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            Debug.WriteLine("I'm Here");
            return response;
        }
    }


}