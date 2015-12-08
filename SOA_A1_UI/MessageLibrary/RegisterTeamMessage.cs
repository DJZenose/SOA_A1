/*************
*Programmers    : Connor McQuade & Brandon Erb & Dallas Thibodeau
*Professor      : Ed Barsalou
*Date           : 6/12/2015
*FILE           : RegisterTeamMessage.cs
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
    public class RegisterTeamMessage
    {
        static char BOM = (char)11;
        static char EOS = (char)13;
        static char EOM = (char)28;
        /*
        * Method        : SendRegisterTeamMessage
        * Returns       : string of register result
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public static string SendRegisterTeamMessage(Data data)
        {
            string message = BOM + "DRC|REG-TEAM|||" + EOS +
                        "INF|" + data.teamName + "|||" + EOS + EOM + EOS;
            return message;

        }

        /*
        * Method        : ParseRegisterTeamMessage
        * Returns       : string of request message
        * Parameters    : the response from the registry
        * Description   : parses response
        */
        public static Data ParseRegisterTeamMessage (string message)
        {
            Data data = new Data();
            char[] delimiterChars = { '|'};
            string[] words = message.Split(delimiterChars);

            if (words[1] == "OK")
            {
                data.teamID = words[2];
                data.message = words[1];
            }
            else
            {
                data.message = message;
            }

            return data;
        }

    }
}
