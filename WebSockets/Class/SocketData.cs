using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebSockets.ws.Class
{
    public class SocketData<TData> : Notifiable, INotifiable
        where TData : class
    {
        public string Origin { get; set; }
        public string Operacao { get; set; }
        public string Token { get; set; }
        public TData Data { get; set; }
        public string ContentyType { get; set; }
        public string Status { get; set; }
        public string DataEnvio { get; set; }
        public string DataResposta { get; set; }
    }
}
