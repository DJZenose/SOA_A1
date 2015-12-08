/*************
*Programmers    : Connor McQuade & Brandon Erb & Dallas Thibodeau
*Professor      : Ed Barsalou
*Date           : 6/12/2015
*FILE           : PublishServiceMessage
*Description    : Class Library for Messaging
**************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using DataClass;

namespace MessageLibrary
{
    public class PublishServiceMessage
    {
        /*
        * Method        : SendExecuteServiceMessage
        * Returns       : string of request message
        * Parameters    : Stream of the class containing the needed data
        * Description   : Published a Service from the client !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        */
        public static string SendPublishServiceMessage(Stream serializedClass)
        {
            string message;

            IFormatter formatter = new BinaryFormatter();
            Data data = (Data)formatter.Deserialize(serializedClass);
            message = "DRC|PUB-SERVICE|<" + data.teamName + ">|<" + data.teamID + ">|" + "\n" +
                    "SRV|<" + data.serviceTag + ">|<" + data.serviceName + ">|<" + data.securityLevel + ">|<" + data.numArg + ">|<" + data.numResp + ">|<" + data.description + ">|" + "\n" +
                    "ARG|<" + data.argPosition[0] + ">|<" + data.argName[0] + ">|<" + data.argDataType[0] + ">|[mandatory|optional]||" + "\n" +
                    "ARG|<" + data.argPosition[1] + ">|<" + data.argName[1] + ">|<" + data.argDataType[1] + ">|[mandatory|optional]||" + "\n" +
                    "RSP|<" + data.responsePos[0] + ">|<" + data.responseName[0] + ">|<" + data.respDataType[0] + ">||" + "\n" +
                    "RSP|<" + data.responsePos[1] + ">|<" + data.responseName[1] + ">|<" + data.respDataType[1] + ">||" + "\n" +
                    "RSP|<" + data.responsePos[2] + ">|<" + data.responseName[2] + ">|<" + data.respDataType[2] + ">||" + "\n" +
                    "RSP|<" + data.responsePos[3] + ">|<" + data.responseName[3] + ">|<" + data.respDataType[3] + ">||" + "\n" +
                    "RSP|<" + data.responsePos[4] + ">|<" + data.responseName[4] + ">|<" + data.respDataType[4] + ">||" + "\n" +
                    "MCH|<" + data.publishIP + ">|<" + data.publishPort + ">|";

            return message;
        }

        /*
        * Method        : ParsePublishServiceMessage
        * Returns       : String of the reply
        * Parameters    : String of the response
        * Description   : Builds string to send to the registry
        */
        public static string ParsePublishServiceMessage(string response)
        {
            return response;
        }
    }
}
