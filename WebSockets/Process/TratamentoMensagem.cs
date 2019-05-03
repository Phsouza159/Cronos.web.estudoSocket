using Newtonsoft.Json;
using System;
using System.Text;
using WebSockets.ws.Class;

namespace WebSockets.ws.Process
{
    public static class TratamentoMensagem
    {
        public static byte[] FiltrarArray(ArraySegment<byte> segment)
        {
            byte[] newArray = new byte[segment.Count];

            Array.Copy(segment.Array, newArray, segment.Count);

            return newArray;
        }

        public static String ArrayToString(byte[] segment)
        {
            return Encoding.ASCII.GetString(segment);
        }

        public static ArraySegment<byte> StringToArray(string segment)
        {
           byte[] arrya = Encoding.ASCII.GetBytes(segment);

           return new ArraySegment<byte>(arrya, 0, arrya.Length);
        }

        public static SocketData<TData> RecuperarObjeto<TData>(string stringify) where TData : class
        {
            SocketData<TData> socketData = JsonConvert.DeserializeObject<SocketData<TData>>(stringify);

            return socketData;
        }

        public static string SerializarObjeto(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
