using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("localhost", 12000);
            NetworkStream stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream);
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadLine();
            Console.WriteLine(text);
            writer.WriteLine("DIR");
            writer.WriteLine("a");
            writer.Flush();
            string reply = reader.ReadLine();
            Console.ReadKey();
            stream.Close();


                 
        }
    }
}
