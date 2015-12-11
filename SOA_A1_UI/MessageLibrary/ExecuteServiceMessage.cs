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
        public static string SendExecuteServiceMessage(Data data)
        {
            string message = BOM + "DRC|EXEC-SERVICE|" + data.teamName + "|" + data.teamID + "|" + EOS +
            "SRV||" + data.serviceName + "||" + data.numArg + "|||" + EOS +
            "ARG|" + data.argPosition[0] + "|" + data.argName[0] + "|" + data.argDataType[0] + "||" + data.argValue1 + "|" + EOS +
            "ARG|" + data.argPosition[1] + "|" + data.argName[1] + "|" + data.argDataType[1] + "||" + data.argValue2 + "|" + EOS + EOM + EOS;

            return message;
        }

        /*
        * Method        : ParseExecuteServiceMessage
        * Returns       : Stream of the data class
        * Parameters    : string of the registry reply
        * Description   : parses registry response
        */
        public static Data ParseExecuteServiceMessage(string dataToParse)
        {
            Data dataParsed = new Data();
            char[] delimiters = new char[] { '|' };
            double temp;
            string[] dataUnassigned = dataToParse.Split(delimiters);
            
            dataParsed.teamName = dataUnassigned[2];
            dataParsed.teamID = dataUnassigned[3];
            dataParsed.serviceName = dataUnassigned[6];
            dataParsed.numArg = Convert.ToInt32(dataUnassigned[8]);

            if (double.TryParse(dataUnassigned[11], out temp) == true)
            {
                dataParsed.argPosition[0] = Convert.ToInt32(dataUnassigned[12]);
                dataParsed.argName[0] = dataUnassigned[13];
                dataParsed.argValue1 = Convert.ToDouble(dataUnassigned[16]);
                dataParsed.argPosition[1] = Convert.ToInt32(dataUnassigned[18]);
                dataParsed.argName[1] = dataUnassigned[19];
                dataParsed.argValue2 = dataUnassigned[22];
            }
            else
            {
                dataParsed.argPosition[0] = Convert.ToInt32(dataUnassigned[12]);
                dataParsed.argName[0] = dataUnassigned[13];
                dataParsed.argValue1 = Convert.ToDouble(dataUnassigned[16]);
                dataParsed.argPosition[1] = Convert.ToInt32(dataUnassigned[18]);
                dataParsed.argName[1] = dataUnassigned[19];
                dataParsed.argValue2 = dataUnassigned[22];
            }
                
            return dataParsed;
        }

        /*
        * Method        : createReturnMessages
        * Returns       : the response
        * Parameters    : results
        * Description   : creates response
        */
        public static Data createReturnMessage(double[] returnVals)
        {
            Data data = new Data();
            
            data.message = BOM + "PUB|OK|||5|" + EOS +
                    "RSP|1|SUB|double|" + returnVals[0] + "|" + EOS +
                    "RSP|2|PST|double|" + returnVals[1] + "|" + EOS +
                    "RSP|3|HST|double|" + returnVals[2] + "|" + EOS +
                    "RSP|4|GST|double|" + returnVals[3] + "|" + EOS +
                    "RSP|5|TPA|double|" + returnVals[4] + "|" + EOS;
            data.log = data.message;
            return data;
        }

        public static Data parseReturnMessage(string message)
        {

            Data dataParsed = new Data();
            char[] delimiters = new char[] { '|' };
            string[] dataUnassigned = message.Split(delimiters);

            dataParsed.message = dataUnassigned[1];
            dataParsed.numArg = Convert.ToInt32(dataUnassigned[4]);
            dataParsed.respValue[0] = (double)Convert.ToDecimal(dataUnassigned[9]);
            dataParsed.respValue[1] = (double)Convert.ToDecimal(dataUnassigned[14]);
            dataParsed.respValue[2] = (double)Convert.ToDecimal(dataUnassigned[19]);
            dataParsed.respValue[3] = (double)Convert.ToDecimal(dataUnassigned[24]);
            dataParsed.respValue[4] = Convert.ToDouble(dataUnassigned[29]);

            //dataParsed.message = 

            return dataParsed;
        }

    }
}
