﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Security.AccessControl;
using System.IO;
using System.Security.Principal;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using DataClass;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SOA_A1_UI
{
    public partial class UIForm : Form
    {
        private string serviceIP = "192.168.1.1";
        private Socket m_socWorker;
        private const int minimum = 0, firstIndex = 0;
        private Data dataLocal = new Data();
        public UIForm()
        {
            InitializeComponent();
            dataLocal.teamName = "Team Condabran";
            dataLocal.serviceTag = "totalPurchase";
            PublishService();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
        }

        private void GrabTotalBtn_Click(object sender, EventArgs e)
        {
            double totalItemPrice = 0;
            string regionCode = "";
            List<double> itemCosts = new List<double>() { 8.25, 2.99, 3.99, 5.00 };

            if (regionCheck.CheckedItems.Count != minimum)
            {
                regionCode = regionCheck.CheckedItems[firstIndex].ToString();
            }

            for (int i = 0; i < ItemBox.Items.Count; i++)
            {
                //check to see if the current index is checked
                if (ItemBox.GetItemChecked(i) == true)
                {
                    //add the price of the checked item to the item total
                    totalItemPrice += itemCosts[i];
                }
            }
            //display the users total purchase (might change this to an onclick event)
            itemTotal.Text = totalItemPrice.ToString();

            Call_PurchaseTotaller(totalItemPrice, regionCode);
        }

        private void Call_PurchaseTotaller(double totalItemPrice, string regionCode)
        {


            try
            {
                //check to see that the itemprice is valid & the postal code is valid
                if (totalItemPrice >= 0 && regionCode != "")
                {
                    //call the service here with the needed variables in the right order
                    StartClient();
                }
                else
                {
                    //JUST A TEST TO TRY LOGGING //CURRENTLY SUCCESSFULL
                    throw new Exception("Input Error: Invalid Region");
                }
            }
            catch (Exception ex)
            {
                //use logerror to send the error message to the log file
                logError(ex.Message);
            }
        }
        private void regionCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int i in regionCheck.CheckedIndices)
            {
                regionCheck.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        //LOGS AN ERROR TO THE LOG FILE
        private void logError(string errorMessage)
        {
            //Grab the path of the App_data folder to store the log in
            var path = System.IO.Path.GetFullPath("../../App_Data/");
            //if the folder we need doesnt exist create it
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            //get access to the folder that was created and make sure it was successfull
            if (GrantAccess(path) == true)
            {
                //if the access to the folder was successfull, write the error to the log file
                System.IO.File.AppendAllText(path + "logFile.txt", DateTime.Now + ", SOA Client, C.McQuade-B.Erb-D.Thibodeau: " + errorMessage + Environment.NewLine);
            }

        }

        /*
        * Method        : GrantAccess
        * Returns       : a success or fail
        * Parameters    : a path to the folder to grant access too
        * Description   : aquire access to the folder given in the file path
        */

        private bool GrantAccess(string fullPath)
        {
            //grab the directory information
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            //access the directories security for modification
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            //add new permissions for the application to properly log
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                                                            FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                                                            PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            //apply those permissions to the directory
            dInfo.SetAccessControl(dSecurity);
            return true;
        }

        private void ExecuteService()
        {
            string message;

            //create and call the class to make a query service message
            MessageLibrary.ExecuteServiceMessage MessageCreate = new MessageLibrary.ExecuteServiceMessage();

            //serialize the current data object
            Stream stream = serialize();
            //grab the message created
            message = MessageCreate.SendExecuteServiceMessage(stream);
        }
        private void QueryTeamService()
        {
            string message;

            //create and call the class to make a query service message
            MessageLibrary.QueryTeamMessage MessageCreate = new MessageLibrary.QueryTeamMessage();

            //serialize the current data object
            Stream stream = serialize();
            //grab the message created
            message = MessageCreate.SendQueryTeamMessage(stream);

            StartClient(message, "QT");
        }
        //Query Service
        private void QueryService()
        {
            string message;

            //create and call the class to make a query service message
            MessageLibrary.QueryServiceMessage MessageCreate = new MessageLibrary.QueryServiceMessage();

            //serialize the current data object
            Stream stream = serialize();
            //grab the message created
            message = MessageCreate.SendQueryServiceMessage(stream);
            
            //send the message to the client and signal the type of message
            StartClient(message, "QS");
            stream.Close();
        }

        //Register Team
        private void RegisterTeam()
        {
            string message;
            MessageLibrary.RegisterTeamMessage MessageCreate = new MessageLibrary.RegisterTeamMessage();

            //serialize the current data object
            Stream stream = serialize();
            //grab the message created
            message = MessageCreate.SendRegisterTeamMessage(stream);

            //send the message
            StartClient(message, "RT");
            stream.Close();
        }
        //Unregister Team
        private void UnregisterTeam()
        {
            string message;

            MessageLibrary.UnregisterTeamMessage MessageCreate = new MessageLibrary.UnregisterTeamMessage();

            //serialize the current data object
            Stream stream = serialize();
            //grab the message created
            message = MessageCreate.SendUnregisterTeamMessage(stream);

            //send a message with the team name and our current id to unregister us
            StartClient(message, "UR");
            stream.Close();
        }

        private void PublishService()
        {
            string message;
            //create the message handler for the publish service
            MessageLibrary.PublishServiceMessage MessageCreate = new MessageLibrary.PublishServiceMessage();

            //serialize the current data object
            Stream stream = serialize();
            //grab the message created
            message = MessageCreate.SendPublishServiceMessage(stream);

            //initiate and perform the publishService
            StartClient(message, "PS");
            stream.Close();
        }

        private Stream serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new System.IO.MemoryStream();
            formatter.Serialize(stream, dataLocal);
            return stream;
        }
        // State object for receiving data from remote device.
        public class StateObject
        {
            // Client socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 256;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
        }
    // The port number for the remote device.
        private const int port = 11000;

        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.
        private static String response = String.Empty;
        private static Stream responseStream;

        private void StartClient(string messageToSend, string command)
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // The name of the 
                // remote device is "host.contoso.com".
                IPHostEntry ipHostInfo = Dns.Resolve("192.156.111.70");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                // Send test data to the remote device.
                Send(client, messageToSend);
                sendDone.WaitOne();

                // Receive the response from the remote device.
                Receive(client);
                receiveDone.WaitOne();

                // Write the response to the console.
                Console.WriteLine("Response received : {0}", response);
                
                IFormatter formatter = new BinaryFormatter();
                responseStream = new System.IO.MemoryStream();
                Data obj = (Data)formatter.Deserialize(responseStream);
                if (obj.message == "OK")
                {
                    switch (command)
                    {
                        case "QS":// case in which QueryService is called
                            //return the 
                            break;
                        case "QT":// case in which the QueryTeamService is called
                            break;
                        case "RT": // case in which RegisterTeam is called
                            //set the new teamID and inform the user about the ID being valid
                            dataLocal.teamID = obj.teamID;
                            IDValidLabel.Text = obj.message;
                            break;
                        case "UR": //case in which UnRegisterTeam is called
                            //no return nessesary
                            break;
                        case "PS":// case in which the PublishService is called
                            //no return nessesary
                            break;
                        case "ES"://case in which the ExecuteService is called
                            break;
                        default:
                            break;
                    }
                }
                
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                //close the stream for the response from the server so we do not consume too many resources
                responseStream.Close();
                // Release the socket.
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Signal that all bytes have been received.
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            RegisterTeam();
        }

        private void unRegisterbtn_Click(object sender, EventArgs e)
        {
            UnregisterTeam();
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}