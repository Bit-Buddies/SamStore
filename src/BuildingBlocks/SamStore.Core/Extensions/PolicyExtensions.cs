using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.Extensions
{
    public static class PolicyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> WaitAndTryAgain()
        {
            AsyncRetryPolicy<HttpResponseMessage> retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(new[] 
                { 
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
                });

            return retryPolicy;
        }
    }
}
