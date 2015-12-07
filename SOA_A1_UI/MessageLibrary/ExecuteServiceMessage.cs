using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    class ExecuteServiceMessage
    {
        public string SendExecuteServiceMessage(string teamName, string teamID, string serviceName,  int numArgs, int argPos, string argName, string argType, string argValue)
        {
            return "DRC|EXEC-SERVICE|<" + teamName + ">|<" + teamID + ">|SRV||<" + serviceName + ">||<" + numArgs + ">|||ARG|<" + argPos + ">|<" + argName + ">|<" + argType + ">||<" + argValue + ">|";

        }

        public string ParseExecuteServiceMessage()
        {
            return "";
        }
    }
}
