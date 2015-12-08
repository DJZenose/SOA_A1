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
        /*
        * Method        : SendUnregisterTeamMessage
        * Returns       : string of request
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public string SendUnregisterTeamMessage(Stream serialClass)
        {
            IFormatter formatter1 = new BinaryFormatter();
            Data data = (Data)formatter1.Deserialize(serialClass);
            return "DRC|UNREG-TEAM|<" + data.teamName + ">|<" + data.teamID + ">|";
        }

        /*
        * Method        : ParseUnregisterTeamMessage
        * Returns       : Stream of the class containing the needed data
        * Parameters    : The response message and the serialized class
        * Description   : Parses response
        */
        public Stream ParseUnregisterTeamMessage (string message, Stream serialClass)
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
