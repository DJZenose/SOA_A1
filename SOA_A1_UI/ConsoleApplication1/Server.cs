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
using DataClass;

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
                string data = null;

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
                    stream.Read(bytes, 0, bytes.Length);
                    
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                        string request = msg.ToString();


                    //Format Request
                    Data service = new Data();
                    service.serviceTag = "GIORP-TOTALER";

                    char[] delimiterChars = { '|' };
                    string[] words = request.Split(delimiterChars);

                    service.teamName = words[2];
                    service.teamID = words[3];
                    service.serviceName = words[5];
                    service.numArg = Convert.ToInt32(words[7]);
                    //arg 1
                    service.argPosition[0] = Convert.ToInt32(words[12]);
                    service.argName[0] = words[14];
                    service.argDataType[0] = words[15];
                    service.argValue1 = Convert.ToDouble(words[17]);
                    //arg 2
                    service.argPosition[1] = Convert.ToInt32(words[19]);
                    service.argName[1] = words[20];
                    service.argDataType[1] = words[21];
                    service.argValue2 = words[23];

                    string message = MessageLibrary.QueryTeamMessage.SendQueryTeamMessage(service);
                    
                    string response = MessageLibrary.registryConnector.connectReg(message, "10.113.21.20", 3000);
                    string ret;
                    if ( response == "OK")
                    {
                       double[] results = new double[5];
                       results = Purchase_Totaller_BL.Totaller.getTotal(service.argValue2, service.argValue1);
                       msg = Encoding.ASCII.GetBytes(MessageLibrary.ExecuteServiceMessage.createReturnMessage(results));
                    }
                    else
                    {
                        msg = Encoding.ASCII.GetBytes(ret);
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
