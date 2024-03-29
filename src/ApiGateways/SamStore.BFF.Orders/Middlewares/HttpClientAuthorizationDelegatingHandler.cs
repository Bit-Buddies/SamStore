﻿using Microsoft.Extensions.Primitives;
using SamStore.WebAPI.Core.Context;
using System.Net.Http.Headers;

namespace SamStore.BFF.Orders.Middlewares
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IHttpContextHandler _contextUser;

        public HttpClientAuthorizationDelegatingHandler(IHttpContextHandler contextUser)
        {
            _contextUser = contextUser;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            StringValues authorizationHeader = _contextUser.GetHttpContext().Request.Headers["Authorization"];

            if (!string.IsNullOrWhiteSpace(authorizationHeader))
                request.Headers.Add("Authorization", new List<string>() { authorizationHeader });

            string accessToken = authorizationHeader.ToString().Replace("Bearer ", string.Empty);

            if (!string.IsNullOrWhiteSpace(accessToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
