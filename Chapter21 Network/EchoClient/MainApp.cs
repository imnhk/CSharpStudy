using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace EchoClient
{
    class MainApp
    {
        static void Main(string[] args)
        {
            if(args.Length < 4)
            {
                Console.WriteLine($"Usage: {Process.GetCurrentProcess().ProcessName} <Bind IP> <Bind Port> <Server IP> <Message>");
                return;
            }

            string bindIp = args[0];
            int bindPort = Convert.ToInt32(args[1]);
            string serverIp = args[2];
            const int serverPort = 5425;
            string message = args[3];

            try
            {
                IPEndPoint clientAddress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

                Console.WriteLine($"Client: {clientAddress.ToString()}, Server: {serverAddress.ToString()}");

                TcpClient client = new TcpClient(clientAddress);
                client.Connect(serverAddress);

                byte[] data = System.Text.Encoding.Default.GetBytes(message);

                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"Send: {message}");

                data = new byte[256];

                string responseData = "";

                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.Default.GetString(data, 0, bytes);
                Console.WriteLine($"Receive: {responseData}");

                stream.Close();
                client.Close();
            }
            catch(SocketException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Closing client...");
        }
    }
}
