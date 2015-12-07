using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MessageLibrary
{
    class PublishServiceMessage
    {
        public  string SendPublishServiceMessage(Stream serializedClass)
        {
            string message;

            message = "DRC|PUB-SERVICE|<" + teamName + ">|<" + teamID + ">|" + "\n" +
                    "SRV|<" + tagName + ">|<" + serviceName + ">|<" + securityLevel + ">|<" + numArgs + ">|<" + numResponses + ">|<" + description + ">|" + "\n" +
                    "ARG|<" + argPos + ">|<" + argName + ">|<" + argType + ">|[mandatory|optional]||" + "\n" +
                    "ARG|<" + argPos + ">|<" + argName + ">|<" + argType + ">|[mandatory|optional]||" + "\n" +
                    "RSP|<" + respPos + ">|<" + respName + ">|<" + respType + ">||" + "\n" +
                    "RSP|<" + respPos + ">|<" + respName + ">|<" + respType + ">||" + "\n" +
                    "RSP|<" + respPos + ">|<" + respName + ">|<" + respType + ">||" + "\n" +
                    "RSP|<" + respPos + ">|<" + respName + ">|<" + respType + ">||" + "\n" +
                    "RSP|<" + respPos + ">|<" + respName + ">|<" + respType + ">||" + "\n" +
                    "MCH|<" + psIP + ">|<" + pPort + ">|";

            return message;
        }

        public string ParsePublishServiceMessage()
        {
            return "";
        }
    }
}
