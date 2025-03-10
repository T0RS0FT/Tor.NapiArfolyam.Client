﻿using Microsoft.Extensions.DependencyInjection;

namespace Tor.NapiArfolyam.Client.DependencyInjection
{
    public static class NapiArfolyamServiceCollectionExtensions
    {
        public static void AddNapiArfolyam(this IServiceCollection services)
        {
            services.AddScoped<INapiArfolyamClient, NapiArfolyamClient>();
            services.AddHttpClient<INapiArfolyamClient, NapiArfolyamClient>();
        }
    }
}
