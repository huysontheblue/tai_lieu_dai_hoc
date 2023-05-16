using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace cau3_client
{
    class bai1
    {
        private const int PORT_NUMBER = 9999;

        public static void Main()
        {

            try
            {
                TcpClient client = new TcpClient();

                // 1. connect
                client.Connect("127.0.0.1", PORT_NUMBER);
                Stream stream = client.GetStream();

                Console.WriteLine("Connected to Y2Server.");
                while (true)
                {
                    Console.Write("Nhap Ten Cua Ban: ");

                    string str = Console.ReadLine();
                    var reader = new StreamReader(stream);
                    StreamWriter writer = new StreamWriter(stream);
                    writer.AutoFlush = true;

                    // 2. send
                    writer.WriteLine(str);

                    // 3. receive
                    str = reader.ReadLine();
                    Console.WriteLine(str);
                    if (str.ToUpper() == "BYE")
                        break;
                }
                // 4. close
                stream.Close();
                client.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }

            Console.Read();
        }
    }

}