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
        public static string SendRegisterTeamMessage(Stream serialClass)
        {
            IFormatter formatter = new BinaryFormatter();
            serialClass.Position = 0;
            Data data = (Data)formatter.Deserialize(serialClass);
            string message = BOM + "DRC|REG-TEAM|||" + EOS + 
                        "INF|" + data.teamName + "|" + data.publishPort + "|" + EOS + EOM + EOS;
            return message;

        }

        /*
        * Method        : ParseRegisterTeamMessage
        * Returns       : string of request message
        * Parameters    : the response from the registry
        * Description   : parses response
        */
        public static Stream ParseRegisterTeamMessage (string message, Stream serialClass)
        {
            IFormatter formatter1 = new BinaryFormatter();
            Data data = (Data)formatter1.Deserialize(serialClass);

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

            IFormatter formatter2 = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter2.Serialize(stream, data);
            return stream;
        }

    }
}
