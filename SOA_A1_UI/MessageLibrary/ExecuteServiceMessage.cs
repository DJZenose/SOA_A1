using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClass;

namespace MessageLibrary
{
    class ExecuteServiceMessage
    {
        public string SendExecuteServiceMessage(string teamName, string teamID, string serviceName,  int numArgs, int argPos, string argName, string argType, string argValue)
        {
            return "DRC|EXEC-SERVICE|<" + teamName + ">|<" + teamID + ">|SRV||<" + serviceName + ">||<" + numArgs + ">|||ARG|<" + argPos + ">|<" + argName + ">|<" + argType + ">||<" + argValue + ">|";

        }

        public Data ParseExecuteServiceMessage(string dataToParse)
        {
            Data dataParsed = new Data();
            int numArgs;
            char[] delimiters = new char[] { '|' };
            string[] dataUnassigned = dataToParse.Split(delimiters);

            dataParsed.teamName = dataUnassigned[2];
            dataParsed.teamID = dataUnassigned[3];
            numArgs = Convert.ToInt32(dataUnassigned[6]);

            return dataParsed;
        }
    }
}
