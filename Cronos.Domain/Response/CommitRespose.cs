using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Domain.Response
{
    public class CommitRespose
    {
        public string Tokien { get; set; }
        public bool Salve { get; set; }
        public List<string> Notificaceos { get; set; }
        public object Response { get; set; }
    }
}
