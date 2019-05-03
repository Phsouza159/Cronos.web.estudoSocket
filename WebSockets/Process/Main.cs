using Cronos.Domain.Entidades;
using Cronos.Domain.Response;
using Cronos.Domain.Servico;
using Cronos.Infra.Contexto;
using Cronos.Infra.Fabrica;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSockets.ws.Class;
using WebSockets.ws.Interfaces;
using WebSockets.ws.Servico;
using Mensagem = WebSockets.ws.Class.Mensagem;

namespace WebSockets.ws.Process
{
    public static class Main
    {
        public static IWebSocketServico WebSocketServico { get; set; }

        public static async Task Echo(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                WebSocketServico = new _WebSocketServico(Context.Instancia("Data Source=127.0.0.1;Initial Catalog=cronos.db;User ID=root;Password="));
                string mystring = string.Empty;

                var ArraySegment = new ArraySegment<byte>(buffer, 0, result.Count);

                SocketData<Mensagem> socketData = TratarInput<Mensagem>(ArraySegment);


                if (socketData.Operacao.Equals("SEND"))
                {
                    SocketData<Mensagem> resposta = TratarOutput<Mensagem>(socketData);
                    mystring = TratamentoMensagem.SerializarObjeto(resposta);
                }
                else if (socketData.Operacao.Contains("REQUEST"))
                {
                    SocketData<MensagemListResponse> resposta = TratarOutput<MensagemListResponse>(socketData.Copy<MensagemListResponse, Mensagem>());
                    mystring = TratamentoMensagem.SerializarObjeto(resposta);
                }

                ArraySegment<byte> arrayResponse = TratamentoMensagem.StringToArray(mystring);

                await webSocket.SendAsync(arrayResponse, result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        private static SocketData<TData> TratarInput<TData>(ArraySegment<byte> input) where TData : class
        {
            byte[] filtro = TratamentoMensagem.FiltrarArray(input);
            string mensagem = TratamentoMensagem.ArrayToString(filtro);
            SocketData<TData> socket = TratamentoMensagem.RecuperarObjeto<TData>(mensagem);

            socket.DataResposta = DateTime.Now.ToString();

            return socket;
        }

        private static SocketData<TData> TratarOutput<TData>(SocketData<TData> socketData) where TData : class
        {

            return null;
        }

        private static SocketData<Mensagem> TratarOutput<TData>(SocketData<Mensagem> socketData)
        {
            if (socketData.Operacao.Equals("SEND"))
            {
                SendMensagem<Mensagem>(socketData);
                socketData.Origin = "Server";
                return socketData;
            }

            return null;
        }

        private static SocketData<MensagemListResponse> TratarOutput<TData>(SocketData<MensagemListResponse> socketData)
        {
            Usuario usuario = WebSocketServico.autentificacaoServico.RecuperarPeloTokien(socketData.Token);
            socketData.Data = new MensagemListResponse();
            socketData.Origin = "Server";

            if (socketData.Operacao.Equals("REQUEST"))
            {
                socketData.Data.List = WebSocketServico.mensagemServico.RecuperarMensagemUsuarioNaoLidas(usuario);
                if(socketData.Data.List.Count > 0)
                    WebSocketServico.mensagemServico.GravarMensagemComoLida(socketData.Data.List, true);
            }
            else if (socketData.Operacao.Equals("REQUEST-ALL"))
            {
                socketData.Data.List = WebSocketServico.mensagemServico.RecuperarMensagensUsuario(usuario);
            }
            socketData.Data.List.ForEach(e => { e.UsuarioFrom = null; e.UsuarioTo = null; });
            return socketData;
        }

        private static bool SendMensagem<TData>(SocketData<TData> socketData) where TData : Mensagem
        {
            Usuario usuario = WebSocketServico.autentificacaoServico.RecuperarPeloTokien(socketData.Token);
            Cronos.Domain.Entidades.Mensagem mensagem = new Cronos.Domain.Entidades.Mensagem();

            mensagem.IdTo = usuario.Id;
            mensagem.DataEnvio = DateTime.Now;
            mensagem.Texto = socketData.Data.Texto;
            mensagem.Situacao = true;
            mensagem.DataInclusao = DateTime.Now;

            return WebSocketServico.mensagemServico.Send(mensagem, true);
        }
    }

}
