/*************
*Programmers    : Connor McQuade & Brandon Erb & Dallas Thibodeau
*Professor      : Ed Barsalou
*Date           : 6/12/2015
*FILE           : QueryServiceMessag.cs
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
    public class QueryServiceMessage
    {
        static char BOM = (char)11;
        static char EOS = (char)13;
        static char EOM = (char)28;
        /*
        * Method        : SendQueryServiceMessagee
        * Returns       : string of registery query
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public static string SendQueryServiceMessage(Data data)
        {
            string message = BOM + "DRC|QUERY-SERVICE|" + data.teamName + "|" + data.teamID + "|"+ EOS +
                   "SRV|" + data.serviceTag + "||||||" + EOS + EOM + EOS;
            return message;
        }

        /*
        * Method        : SendQueryServiceMessagee
        * Returns       : string of registery query
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public static Data ParseQueryServiceMessage(string message)
        {
            IFormatter formatter1 = new BinaryFormatter();
            Data data = new Data();

            char[] delimiterChars = {'|'};
            string[] words = message.Split(delimiterChars);

            if (words[1] == "OK")
            {
                data.message = words[1];
                data.numSegments = Convert.ToInt32(words[4]);
                data.teamName = words[6];
                data.serviceName = words[7];
                data.numArg = Convert.ToInt32(words[9]);
                data.numResp = Convert.ToInt32(words[10]);
                data.description = words[11];
                //arg 1
                data.argPosition[0] = Convert.ToInt32(words[13]);
                data.argName[0] = words[14];
                data.argDataType[0] = words[15];
                //arg 2
                data.argPosition[1] = Convert.ToInt32(words[19]);
                data.argName[1] = words[20];
                data.argDataType[1] = words[21];
                //ret 1
                data.responsePos[0] = Convert.ToInt32(words[25]);
                data.responseName[0] = words[26];
                data.respDataType[0] = words[27];
                //ret 2
                data.responsePos[1] = Convert.ToInt32(words[30]);
                data.responseName[1] = words[31];
                data.respDataType[1] = words[32];
                //ret 3
                data.responsePos[2] = Convert.ToInt32(words[35]);
                data.responseName[2] = words[36];
                data.respDataType[2] = words[37];
                //ret 4
                data.responsePos[3] = Convert.ToInt32(words[40]);
                data.responseName[3] = words[41];
                data.respDataType[3] = words[42];
                //ret 5
                data.responsePos[4] = Convert.ToInt32(words[45]);
                data.responseName[4] = words[46];
                data.respDataType[4] = words[47];
                //MCH
                data.publishIP = words[50];
                data.publishPort = Convert.ToInt32(words[51]);
            }
            else
            {
                data.message = message;
            }
            return data;
        }
    }
}
