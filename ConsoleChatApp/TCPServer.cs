using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChatApp
{
    public class TCPServer
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 18027;

        static ASCIIEncoding encoding = new ASCIIEncoding();

        public static void Start()
        {
            try
            {
                IPAddress address = IPAddress.Parse("127.0.0.1");

                TcpListener listener = new TcpListener(address, PORT_NUMBER);

                listener.Start();
                Console.WriteLine("Server started on " + listener.LocalEndpoint + ":" + PORT_NUMBER);
                Console.WriteLine("Waiting for a connection...");

                Socket socket = listener.AcceptSocket();
                Console.WriteLine("New connection: " + socket.RemoteEndPoint);

                byte[] data = new byte[BUFFER_SIZE];
                socket.Receive(data);

                string str = encoding.GetString(data);

                socket.Send(encoding.GetBytes("Message from Server: " + str));

                socket.Close();
                listener.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
