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

        /*
        * Method        : SendQueryTeamMessage
        * Returns       : string of register query
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public static string SendQueryTeamMessage(Stream serialClass)
        {
            IFormatter formatter = new BinaryFormatter();
            Data data = (Data)formatter.Deserialize(serialClass);

            string message;
            message = "DRC|QUERY-TEAM|<" + data.teamName + ">|<" + data.teamID + ">|\n" +
                    "INF|<" + data.teamName + ">|<" + data.teamID + ">|<" + data.serviceTag + ">|";

            return message;
        }

        /*
        * Method        : ParseQueryTeamMessage
        * Returns       : Stream of the class containing the needed data
        * Parameters    : Stream of the class containing the needed data and a string of the message to be parsed
        * Description   : Builds string to send to the registry
        */
        public static Stream ParseQueryTeamMessage (string message, Stream serialClass)
        {
            IFormatter formatter1 = new BinaryFormatter();
            Data data = (Data)formatter1.Deserialize(serialClass);

            char[] delimiterChars = { '|', '|', '|' };
            string[] words = message.Split(delimiterChars);

            if (words[1] == "OK")
            {
                data.message = words[1];
            }
            else
            {
                data.message = message;
            }

            IFormatter formatter2 = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter2.Serialize(stream, data);
            return stream;
        }
    }
}
