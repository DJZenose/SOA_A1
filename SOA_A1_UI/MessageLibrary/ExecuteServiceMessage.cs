/*************
*Programmers    : Connor McQuade & Brandon Erb & Dallas Thibodeau
*Professor      : Ed Barsalou
*Date           : 6/12/2015
*FILE           : ExecuteServiceMessage
*Description    : Class Library for ExecuteServiceMessage
**************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClass;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MessageLibrary
{
    public class ExecuteServiceMessage
    {
       static char BOM = (char)11;
       static char EOS = (char)13;
       static char EOM = (char)28;

        /*
        * Method        : SendExecuteServiceMessage
        * Returns       : string of request message
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public static string SendExecuteServiceMessage(Stream SerialStream)
        {
            string message;
            IFormatter formatter = new BinaryFormatter();
            Data data = (Data)formatter.Deserialize(SerialStream);

            message = BOM + "DRC|EXEC-SERVICE|<" + data.teamName + ">|<" + data.teamID + ">|" + EOS +
            "SRV||<" + data.serviceName + ">||<" + data.numArg + ">|||" + EOS + 
            "ARG |<" + data.argPosition[8] + ">|<" + data.argName[0] + ">|<" + data.argDataType[0] + ">||<" + data.argValue1 + ">|" + EOS +
            "ARG |<" + data.argPosition[13] + ">|<" + data.argName[1] + ">|<" + data.argDataType[1] + ">||<" + data.argValue2 + ">|" + EOS + EOM + EOS;

            return message;
        }

        /*
        * Method        : ParseExecuteServiceMessage
        * Returns       : Stream of the data class
        * Parameters    : string of the registry reply
        * Description   : parses registry response
        */
        public static Stream ParseExecuteServiceMessage(string dataToParse)
        {
            Data dataParsed = new Data();

            char[] delimiterChars = { '|' };
            string[] words = dataToParse.Split(delimiterChars);

            dataParsed.numSegments = Convert.ToInt32(words[4]);

            

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, dataParsed);
            return stream;
        }

        /*
        * Method        : createReturnMessages
        * Returns       : the response
        * Parameters    : results
        * Description   : creates response
        */
        public static string createReturnMessage(double[] returnVals)
        {
            string message;

            message = BOM + "PUB | OK |||< 5 >|" + EOS +
                    "RSP |<1>|<SUB>|<double>|" + returnVals[0] + "|" + EOS +
                    "RSP |<2>|<PST>|<double>|" + returnVals[1] + "|" + EOS +
                    "RSP |<3>|<HST>|<double>|" + returnVals[2] + "|" + EOS +
                    "RSP |<4>|<GST>|<double>|" + returnVals[3] + "|" + EOS +
                    "RSP |<5>|<TPA>|<double>|" + returnVals[4] + "|" + EOS;

            return message;
        }
    }
}
