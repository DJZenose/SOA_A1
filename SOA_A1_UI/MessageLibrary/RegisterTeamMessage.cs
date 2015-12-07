using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    public class RegisterTeamMessage
    {
        public string SendRegisterTeamMessage(string teamName)
        {

            return "DRC|REG-TEAM|||\n" + "INF|" + teamName + "|||";
        }

        public string ParseRegisterTeamMessage (string message)
        {
            return "";
        }

    }
}
