using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    class QueryTeamMessage
    {
        public string SendQueryTeamMessage(string teamName, string teamID, string serviceTagName)
        {
            return "DRC|QUERY-TEAM|<" + teamName + ">|<" + teamID + ">|\nINF|<" + teamName + ">|<" + teamID + ">|<" + serviceTagName + ">|";

        }

        public string ParseQueryTeamMessage (string message)
        {
            return "";
        }
    }
}
