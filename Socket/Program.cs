using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Sockets
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any,11000);
            listener.Start();
            Console.WriteLine("Waiting for connection");
            Socket socket = listener.AcceptSocket();
            Console.WriteLine("Connected");
            NetworkStream networkStream = new NetworkStream(socket);
            StreamReader reader = new StreamReader(networkStream);
            StreamWriter writer = new StreamWriter(networkStream);
            writer.AutoFlush = true;
            writer.WriteLine("You are connected");

            bool run = true;
            while (run)
            {
                string command = reader.ReadLine();

                switch (command.ToUpper())
                {
                    case "DIR":
                        string text = reader.ReadLine();
                        if (text == "a")
                        {
                            writer.WriteLine("It exists");
                        }
                        else
                        {
                            writer.WriteLine("It does not exist");
                        }
                        break;
                    case "EXIT":
                        run = false;
                        break;
                    default:
                        break;
                }
            }
            networkStream.Close();
            networkStream.Dispose();
        }

        


        
    }
}
