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
        public string SendExecuteServiceMessage(Stream SerialStream)
        {
            string message;
            IFormatter formatter = new BinaryFormatter();
            Data data = (Data)formatter.Deserialize(SerialStream);

            message = "DRC|EXEC-SERVICE|<" + data.teamName + ">|<" + teamID + ">|SRV||<" + serviceName + ">||<" + numArgs + ">|||ARG|<" + argPos + ">|<" + argName + ">|<" + argType + ">||<" + argValue + ">|";
            return message;
        }

        public Data ParseExecuteServiceMessage(string dataToParse)
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


            return dataParsed;
        }
    }
}
