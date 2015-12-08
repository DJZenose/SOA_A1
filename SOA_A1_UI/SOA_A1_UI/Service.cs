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
    class Service
    {
        private void PublishService()
        {
            string message;
            Data publishData = new Data();
            publishData.teamName = "ConDaBran";
            publishData.serviceTag = "GIORP-TOTAL";
            publishData.serviceName = "GiorpService";
            publishData.numArg = 2;
            publishData.numResp = 5;
            publishData.description = "Purchase Totaler";

           
        }

        //Register Team
        private void RegisterTeam()
        {
            string message;

            //serialize the current data object
            Stream stream = serialize();
            //grab the message created
            message = MessageLibrary.RegisterTeamMessage.SendRegisterTeamMessage(stream);

            //send the message
            StartClient(message, "RT");
            stream.Close();
        }
        //Unregister Team
        private void UnregisterTeam()
        {
            string message;


            //serialize the current data object
            Stream stream = serialize();
            //grab the message created
            message = MessageLibrary.UnregisterTeamMessage.SendUnregisterTeamMessage(stream);

            //send a message with the team name and our current id to unregister us
            StartClient(message, "UR");
            stream.Close();
        }
    }
}
