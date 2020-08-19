using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    public class TCPClient
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 18027;

        static ASCIIEncoding encoding = new ASCIIEncoding();

        public static void Start()
        {
            try
            {
                TcpClient client = new TcpClient();

                client.Connect("127.0.0.1", PORT_NUMBER);
                Stream stream = client.GetStream();

                Console.WriteLine("Connect to Server");
                Console.WriteLine("Send a message to Server");

                string str = Console.ReadLine();

                byte[] data = encoding.GetBytes(str);

                stream.Write(data, 0, data.Length);

                data = new byte[BUFFER_SIZE];
                stream.Read(data, 0, BUFFER_SIZE);

                string messageFromServer = encoding.GetString(data);
                Console.WriteLine(messageFromServer);

                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
