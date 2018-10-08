using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1",6789))
                {
                    using (Stream s = client.GetStream())
                    {

                            
                        
                            StreamWriter writer = new StreamWriter(s) { AutoFlush = true };
                            Console.WriteLine("Client ready to send bytes of data to server...");
                        while (true)
                        {
                            Console.WriteLine("Write your message here or type 'bye' to disconnect the client");
                            string clientMessage = Console.ReadLine();
                            writer.WriteLine(clientMessage);

                            StreamReader reader = new StreamReader(s);
                            string readMessageFromServer = reader.ReadLine();

                            if (readMessageFromServer != null)
                            {
                                Console.WriteLine("Client recieved Message from Server:" + readMessageFromServer);
                            }
                            else
                            {
                                Console.WriteLine("Client recieved null message from Server ");
                            }
                        }
                    }


                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            

        }
    }
}
