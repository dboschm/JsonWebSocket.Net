﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.DependencyInjection;
using System.Net.WebSockets;
using System.Threading;
using System.IO;
using JsonWebSocket;

namespace ExampleServerWithHandler
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MySocketHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseWebSockets();

            app.Map("/ws", ws => ws.UseJsonWebSocketHandler<MySocketHandler>());
        }
    }
}
