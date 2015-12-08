using System;
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
using System.Configuration;
using System.Collections.Specialized;

namespace SOA_A1_UI
{
    public partial class UIForm : Form
    {
        private string serviceIP = ConfigurationManager.AppSettings.Get("ConfigIP");
        private string servicePort = ConfigurationManager.AppSettings.Get("ConfigPort");
        private Socket m_socWorker;
        private const int minimum = 0, firstIndex = 0;
        public Data dataLocal = new Data();
        Logging log = new Logging();
        public UIForm()
        {
            InitializeComponent();

            dataLocal.teamName = ConfigurationManager.AppSettings.Get("TeamName");
            dataLocal.serviceTag = "GIORP-TOTAL";
            dataLocal.publishIP = serviceIP;
            dataLocal.publishPort = Convert.ToInt32(servicePort);
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

            cmdConnect();
            cmdSendData();
            cmdReceiveData();
            cmdClose();
                /*
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
            }*/
        }
        private void regionCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int i in regionCheck.CheckedIndices)
            {
                regionCheck.SetItemCheckState(i, CheckState.Unchecked);
            }
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

        // The response from the remote device.
        private static String response = String.Empty;
        private static Stream responseStream;

        private void StartClient(string messageToSend, string command)
        {
            // Connect to a remote device.
            try
            {
                
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            RegisterTeam();
        }

        private void unRegisterbtn_Click(object sender, EventArgs e)
        {
            UnregisterTeam();
        }

        private void cmdConnect()
        {
            try
            {
                TcpClient regSock = new TcpClient(serviceIP, Convert.ToInt32(servicePort));
                regSock.Connect(serviceIP, Convert.ToInt32(servicePort));

            }
            catch (System.Net.Sockets.SocketException se)
            {
                log.logger(se.Message);
                MessageBox.Show(se.Message);
            }
        }

        private void cmdSendData()
        {
            try
            {
                //Data objData = IDValidLabel.Text;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes("WOAH DID IT WORK?");
                m_socWorker.Send(byData);
            }
            catch (System.Net.Sockets.SocketException se)
            {
                log.logger(se.Message);
                MessageBox.Show(se.Message);
            }
        }

        private void cmdReceiveData()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int iRx = m_socWorker.Receive(buffer);
                char[] chars = new char[iRx];

                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);
                IDValidLabel.Text = szData;
            }
            catch (System.Net.Sockets.SocketException se)
            {
                log.logger(se.Message);
                MessageBox.Show(se.Message);
            }
        }

        private void cmdClose()
        {
            log.logger("Closed Socket");
            m_socWorker.Close();
        }
    }
}