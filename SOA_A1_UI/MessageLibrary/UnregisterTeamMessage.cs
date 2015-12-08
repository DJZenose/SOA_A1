using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    public class UnregisterTeamMessage
    {
        public string SendUnregisterTeamMessage(string teamName, string teamID)
        {
            return "DRC|UNREG-TEAM|<" + teamName + ">|<" + teamID + ">|";
        }

        public string ParseUnregisterTeamMessage (string message)
        {
            return "";
        }
    }
}
