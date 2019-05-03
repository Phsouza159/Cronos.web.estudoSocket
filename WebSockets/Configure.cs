using Cronos.Infra.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Internal;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebSockets.ws.Interfaces;
using WebSockets.ws.Process;

namespace WebSockets.ws
{
    public static class Configure
    {

        public static void WebSocketsConfigureStartup(this IApplicationBuilder app)
        {
            var webSocketOptions = new WebSocketOptions() {
                KeepAliveInterval = TimeSpan.FromSeconds(120)
                , ReceiveBufferSize = 4 * 1024
            };

            app.UseWebSockets(webSocketOptions);

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/ws")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();

                        await Main.Echo(context, webSocket);
                    }
                    else { context.Response.StatusCode = 200; }
                }
                else
                {
                    await next();
                }
            });
        }
    }
}
