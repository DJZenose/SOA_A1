using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    class QueryServiceMessage
    {
        public string SendQueryServiceMessage(string teamName, string teamID, string tagName)
        {
            return "DRC|QUERY-SERVICE|<" + teamName + ">|<" + teamID + ">|SRV|<" + tagName + ">||||||";
        }

        public string ParseQueryServiceMessage()
        {
            return "";
        }
    }
}
