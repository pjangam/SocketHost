using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntryAsync(Dns.GetHostName()).GetAwaiter().GetResult();
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8991);

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Tcp);

            listener.Bind(localEndPoint);
            listener.Listen(100);

            int bytesRead;
            byte[] buffer = null;
            while ((bytesRead = listener.Receive(buffer)) > 0)
            {
                // process bytesRead from buffer
                var data = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(data);
            }
        }
    }
}
