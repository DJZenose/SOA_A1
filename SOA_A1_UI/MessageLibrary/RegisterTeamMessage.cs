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
        /*
        * Method        : SendRegisterTeamMessage
        * Returns       : string of register result
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public string SendRegisterTeamMessage(Stream serialClass)
        {
            IFormatter formatter = new BinaryFormatter();
            Data data = (Data)formatter.Deserialize(serialClass);
            string message = "DRC|REG-TEAM|||\n" + "INF|" + data.teamName + "|||";
            return message;

        }

        /*
        * Method        : ParseRegisterTeamMessage
        * Returns       : string of request message
        * Parameters    : the response from the registry
        * Description   : parses response
        */
        public Stream ParseRegisterTeamMessage (string message, Stream serialClass)
        {
            IFormatter formatter1 = new BinaryFormatter();
            Data data = (Data)formatter1.Deserialize(serialClass);

            char[] delimiterChars = { '|', '|', '|' };
            string[] words = message.Split(delimiterChars);

            data.message = words[1];

            if (words[1] == "OK")
            {
                data.teamID = words[2];
                data.message = words[1];
            }
            else
            {
                data.message = words[1];
            }

            IFormatter formatter2 = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter2.Serialize(stream, data);
            return stream;
        }

    }
}
