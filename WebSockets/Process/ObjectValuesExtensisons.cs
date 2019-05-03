using System;
using System.Collections.Generic;
using System.Text;
using WebSockets.ws.Class;

namespace WebSockets.ws.Process
{
    public static class ObjectValuesExtensisons
    {
        /// <summary>
        /// Copiar um objeto SocketData para outro com um nova propriedade data
        /// </summary>
        /// <typeparam name="TCopy"></typeparam>
        /// <typeparam name="TData"></typeparam>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static SocketData<TCopy> Copy<TCopy , TData>(this SocketData<TData> socket) 
            where TCopy : class 
            where TData : class
        {
            SocketData<TCopy> resposta = new SocketData<TCopy>();

            resposta.Token = socket.Token;
            resposta.Status = socket.Status;
            resposta.Origin = socket.Origin;
            resposta.DataEnvio = socket.DataEnvio;
            resposta.DataResposta = DateTime.Now.ToString();
            resposta.Operacao = socket.Operacao;
            resposta.ContentyType = socket.ContentyType;


            return resposta;
        }
    }
}
