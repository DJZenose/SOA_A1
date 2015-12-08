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
        private string PublishService( string publishIP, Int32 publishPort, string regIP, Int32 regPort, string teamName, string teamID)
        {
            string message;
            string response;

            Data publishData = new Data();
            publishData.teamName = teamName;
            publishData.teamID = teamID;
            publishData.serviceTag = "GIORP-TOTAL";
            publishData.serviceName = "GiorpService";
            publishData.numArg = 2;
            publishData.numResp = 5;
            publishData.description = "Purchase Totaler";
            publishData.argPosition[0] = 1;
            publishData.argPosition[1] = 2;
            publishData.argName[0] = "region"; //see stupid registry
            publishData.argName[1] = "totals";
            publishData.argDataType[0] = "string";
            publishData.argDataType[0] = "double";
            publishData.responsePos[0] = 1;
            publishData.responsePos[1] = 2;
            publishData.responsePos[2] = 3;
            publishData.responsePos[3] = 4;
            publishData.responsePos[4] = 5;
            publishData.responseName[0] = "SUB";
            publishData.responseName[1] = "PST";
            publishData.responseName[2] = "HST";
            publishData.responseName[3] = "GST";
            publishData.responseName[4] = "TPA";
            publishData.respDataType[0] = "double";
            publishData.respDataType[1] = "double";
            publishData.respDataType[2] = "double";
            publishData.respDataType[3] = "double";
            publishData.respDataType[4] = "double";
            publishData.publishIP = publishIP;
            publishData.publishPort = publishPort;
            publishData.securityLevel = 1;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, publishData);

            message = MessageLibrary.PublishServiceMessage.SendPublishServiceMessage(stream);

            response = MessageLibrary.registryConnector.connectReg(message, regIP, regPort);

            return response;//logggggggg
        }

        //Register Team
        private Data RegisterTeam(Data data, string regIP, Int32 regPort)
        {
            string message;
            string response;

            IFormatter formatter2 = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter2.Serialize(stream, data);

            message = MessageLibrary.RegisterTeamMessage.SendRegisterTeamMessage(stream);
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

            return retData;

        }

        //Unregister Team
        private Data UnregisterTeam(Data data, string regIP, Int32 regPort)
        {
            string message;
            string response;

            IFormatter formatter2 = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter2.Serialize(stream, data);

            message = MessageLibrary.UnregisterTeamMessage.SendUnregisterTeamMessage(stream);
            response = MessageLibrary.registryConnector.connectReg(message, regIP, regPort);

            stream = MessageLibrary.UnregisterTeamMessage.ParseUnregisterTeamMessage(response, stream);

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

            return retData;

        }
    }
}
