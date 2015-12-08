/*************
*Programmers    : Connor McQuade & Brandon Erb & Dallas Thibodeau
*Professor      : Ed Barsalou
*Date           : 6/12/2015
*FILE           : UnregisterTeamMessage.cs
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
    
    public class UnregisterTeamMessage
    {
        static char BOM = (char)11;
        static char EOS = (char)13;
        static char EOM = (char)28;
        /*
        * Method        : SendUnregisterTeamMessage
        * Returns       : string of request
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public static string SendUnregisterTeamMessage(Data data)
        {
            return BOM + "DRC|UNREG-TEAM|<" + data.teamName + ">|<" + data.teamID + ">|" + EOS + EOM + EOS;
        }

        /*
        * Method        : ParseUnregisterTeamMessage
        * Returns       : Stream of the class containing the needed data
        * Parameters    : The response message and the serialized class
        * Description   : Parses response
        */
        public static Data ParseUnregisterTeamMessage (string message)
        {
            Data data = new Data();

            char[] delimiterChars = {'|'};
            string[] words = message.Split(delimiterChars);

            if (words[1] == "OK")
            {
                data.message = words[1];
                data.log = message;
            }
            else
            {
                data.log = message;
            }

            return data;
        }
    }
}
