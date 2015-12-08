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

        /*
        * Method        : SendExecuteServiceMessage
        * Returns       : string of request message
        * Parameters    : Stream of the class containing the needed data
        * Description   : Builds string to send to the registry
        */
        public string SendExecuteServiceMessage(Stream SerialStream)
        {
            string message;
            IFormatter formatter = new BinaryFormatter();
            Data data = (Data)formatter.Deserialize(SerialStream);

            message = "DRC|EXEC-SERVICE|<" + data.teamName + ">|<" + data.teamID + ">|" + "\n" +
            "SRV||<" + data.serviceName + ">||<" + data.numArg + ">|||" + "\n" + 
            "ARG |<" + data.argPosition[0] + ">|<" + data.argName[0] + ">|<" + data.argDataType[0] + ">||<" + data.argValue1 + ">|" + "\n" +
            "ARG |<" + data.argPosition[1] + ">|<" + data.argName[1] + ">|<" + data.argDataType[1] + ">||<" + data.argValue2 + ">|";

            return message;
        }

        /*
        * Method        : ParseExecuteServiceMessage
        * Returns       : Stream of the data class
        * Parameters    : string of the registry reply
        * Description   : parses registry response
        */
        public Stream ParseExecuteServiceMessage(string dataToParse)
        {
            Data dataParsed = new Data();
            char[] delimiters = new char[] { '|' };
            double temp;
            string[] dataUnassigned = dataToParse.Split(delimiters);

            dataParsed.teamName = dataUnassigned[2];
            dataParsed.teamID = dataUnassigned[3];
            dataParsed.serviceName = dataUnassigned[5];
            dataParsed.numArg = Convert.ToInt32(dataUnassigned[6]);

            if (double.TryParse(dataUnassigned[11], out temp) == true)
            {
                dataParsed.argPosition[0] = Convert.ToInt32(dataUnassigned[8]);
                dataParsed.argName[0] = dataUnassigned[9];
                dataParsed.argValue1 = Convert.ToDouble(dataUnassigned[11]);
                dataParsed.argPosition[1] = Convert.ToInt32(dataUnassigned[13]);
                dataParsed.argName[1] = dataUnassigned[14];
                dataParsed.argValue2 = dataUnassigned[16];
            }
            else
            {
                dataParsed.argPosition[1] = Convert.ToInt32(dataUnassigned[8]);
                dataParsed.argName[1] = dataUnassigned[9];
                dataParsed.argValue2 = dataUnassigned[11];
                dataParsed.argPosition[0] = Convert.ToInt32(dataUnassigned[13]);
                dataParsed.argName[0] = dataUnassigned[14];
                dataParsed.argValue1 = Convert.ToInt32(dataUnassigned[16]);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, dataParsed);
            return stream;

        }
    }
}
