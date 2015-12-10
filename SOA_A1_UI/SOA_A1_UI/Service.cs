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
        Logging log = new Logging();
        public string PublishService( string regIP, Int32 regPort, string teamName, string teamID)
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
            publishData.argDataType[1] = "double";
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
            publishData.publishIP = regIP;
            publishData.publishPort = regPort;
            publishData.securityLevel = 1;

            message = MessageLibrary.PublishServiceMessage.SendPublishServiceMessage(publishData);

            response = MessageLibrary.registryConnector.connectReg(message, regIP, regPort);

            publishData = MessageLibrary.PublishServiceMessage.ParsePublishServiceMessage(response);

            log.logger(publishData.message);
            return response;
        }

        //Register Team
        public Data RegisterTeam(Data data, string regIP, Int32 regPort)
        {
            string message;
            string response;

            message = MessageLibrary.RegisterTeamMessage.SendRegisterTeamMessage(data);
            response = MessageLibrary.registryConnector.connectReg(message, regIP, regPort);

            Data retData = MessageLibrary.RegisterTeamMessage.ParseRegisterTeamMessage(response);

            if (retData.message == "OK")
            {
                log.logger(retData.message);
                return retData;
            }
            else
            {
                log.logger(retData.message);
                //error log
            }

            return retData;

        }

        //Unregister Team
        public Data UnregisterTeam(Data data, string regIP, Int32 regPort)
        {
            string message;
            string response;

            message = MessageLibrary.UnregisterTeamMessage.SendUnregisterTeamMessage(data);
            response = MessageLibrary.registryConnector.connectReg(message, regIP, regPort);

            Data retData = MessageLibrary.UnregisterTeamMessage.ParseUnregisterTeamMessage(response);

            if (retData.message == "OK")
            {
                log.logger(retData.message);
                return retData;
            }
            else
            {
                log.logger(retData.message);
                //error log
            }

            return retData;
        }

        public Data QueryService(Data data, string regIP, Int32 regPort)
        {
            string message;
            string response;

            message = MessageLibrary.QueryServiceMessage.SendQueryServiceMessage(data);
            response = MessageLibrary.registryConnector.connectReg(message, regIP, regPort);

            Data retData = MessageLibrary.QueryServiceMessage.ParseQueryServiceMessage(data,response);

            if (retData.message == "OK")
            {
                ExecuteService(retData, retData.publishIP, retData.publishPort);
                log.logger(retData.message);
                return retData;
            }
            else
            {
                log.logger(retData.message);
                //error log
            }


            return retData;

        }

        public Data ExecuteService(Data data, string regIP, Int32 regPort)
        {
            string message;
            string response;

            message = MessageLibrary.ExecuteServiceMessage.SendExecuteServiceMessage(data);
            response = MessageLibrary.registryConnector.connectReg(message, data.publishIP, data.publishPort);

            Data retData = MessageLibrary.ExecuteServiceMessage.ParseExecuteServiceMessage(response);
            
            if (retData.message == "OK")
            {
                log.logger(retData.message);
                return retData;
            }
            else
            {
                log.logger(retData.message);
                //error log
            }

            return retData;
        }
    }
}
