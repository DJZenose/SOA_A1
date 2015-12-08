/*************
*Programmers    : Connor McQuade & Brandon Erb & Dallas Thibodeau
*Professor      : Ed Barsalou
*Date           : 6/12/2015
*FILE           : QueryTeamMessage.cs
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
    public class QueryTeamMessage
    {
        static char BOM = (char)11;
        static char EOS = (char)13;
        static char EOM = (char)28;

        /*
        * Method        : SendQueryTeamMessage
        * Returns       : string of register query
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public static string SendQueryTeamMessage(Data data)
        {

            string message;
            message = BOM + "DRC|QUERY-TEAM|<" + data.teamName + ">|<" + data.teamID + ">|" + EOS +
                    "INF|<" + data.teamName + ">|<" + data.teamID + ">|<" + data.serviceTag + ">|" + EOS + EOM + EOS;

            return message;
        }

        /*
        * Method        : ParseQueryTeamMessage
        * Returns       : Stream of the class containing the needed data
        * Parameters    : Stream of the class containing the needed data and a string of the message to be parsed
        * Description   : Builds string to send to the registry
        */
        public static string ParseQueryTeamMessage (string message)
        {
          

            char[] delimiterChars = { '|', '|', '|' };
            string[] words = message.Split(delimiterChars);

            if (words[1] == "OK")
            {
                message = words[1];
            }
            else
            {
                
            }
            return message;
        }
    }
}
