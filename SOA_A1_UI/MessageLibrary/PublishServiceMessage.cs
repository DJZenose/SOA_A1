using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    class PublishServiceMessage
    {
        public  string SendPublishServiceMessage(string teamName, string teamID, string tagName, string serviceName, string securityLevel, int numArgs, int numResponses, string description, string argPos, string argName, string argType, string respPos, string respName, string respType, string psIP, string pPort)
        {
            string message;

            message = "DRC|PUB-SERVICE|<" + teamName + ">|<" + teamID + ">|";
            message = "SRV|<" + tagName + ">|<" + serviceName + ">|<" + securityLevel + ">|<" + numArgs + ">|<" + numResponses + ">|<" + description + ">|";
            message = "ARG|<" + argPos + ">|<" + argName + ">|<" + argType + ">|[mandatory|optional]||";
            message = ". . .";
            message = "RSP|<" + respPos + ">|<" + respName + ">|<" + respType + ">||";
            message = ". . .";
            message = "MCH|<" + psIP + ">|<" + pPort + ">|";

            return message;
        }

        public string ParsePublishServiceMessage()
        {
            return "";
        }
    }
}
