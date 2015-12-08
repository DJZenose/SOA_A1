using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using MessageLibrary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Service
{
    // State object for reading client data asynchronously
    public class Service
    {
        public static void Main()
        {
            TcpListener server = null;
            try
            {
                Int32 port = 6600;
                NetworkInterface.GetAllNetworkInterfaces();
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[1048];
                String data = null;

                // Enter the listening loop.
                while (true)
                {

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                        string request = msg.ToString();

                    }

                    string message;
                    string response;

                    message = MessageLibrary.QueryTeamMessage()
                    response = MessageLibrary.registryConnector.connectReg(message, regIP, regPort);

                    stream = MessageLibrary.RegisterTeamMessage.ParseRegisterTeamMessage(response, stream);

                    IFormatter formatter1 = new BinaryFormatter();
                    Data retData = (Data)formatter1.Deserialize(stream);

                    if (retData.message == "OK")
                    {
                        return retData;
                    }
                    else
                    {
                        //error log
                    }

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }


            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
 
}
