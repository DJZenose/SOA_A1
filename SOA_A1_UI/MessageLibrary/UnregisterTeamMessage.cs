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
        * Method        : SendRegisterTeamMessage
        * Returns       : string of register result
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public string SendUnregisterTeamMessage(string teamName, string teamID)
        {
            return "DRC|UNREG-TEAM|<" + teamName + ">|<" + teamID + ">|";
        }

        /*
        * Method        : SendRegisterTeamMessage
        * Returns       : string of register result
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public Stream ParseUnregisterTeamMessage (string message)
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
