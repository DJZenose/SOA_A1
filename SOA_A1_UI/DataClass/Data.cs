using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClass
{
    [Serializable]
    public class Data
    {
        public double total;
        public string regionCode;
        public string teamName;
        public string teamID;
        public string serviceTag;
        public string serviceName;
        public int securityLevel;
        public int numArg;
        public int numResp;
        public string description;
        public int[] argPosition = new int[2];
        public string[] argName = new string[2];
        public string[] argDataType = new string[2];
        public double argValue1;
        public string argValue2;
        public int[] responsePos = new int [5];
        public string[] responseName = new string[5];
        public string[] respDataType = new string[5];
        public double[] respValue = new double[5];
        public string publishIP;
        public int publishPort;
        public string message;
        public string log;
        public int numSegments;
        public Data()
        {
            serviceTag = "GIORP-TOTAL";
            serviceName = "GiorpService";
            numArg = 2;
            numResp = 5;
            description = "Purchase Totaler";
            argPosition[0] = 1;
            argPosition[1] = 2;
            argName[0] = "totals"; //see stupid registry
            argName[1] = "region"; 
            argDataType[0] = "double";
            argDataType[1] = "string";
            responsePos[0] = 1;
            responsePos[1] = 2;
            responsePos[2] = 3;
            responsePos[3] = 4;
            responsePos[4] = 5;
            responseName[0] = "SUB";
            responseName[1] = "PST";
            responseName[2] = "HST";
            responseName[3] = "GST";
            responseName[4] = "TPA";
            respDataType[0] = "double";
            respDataType[1] = "double";
            respDataType[2] = "double";
            respDataType[3] = "double";
            respDataType[4] = "double";
            securityLevel = 1;
        }
       
    }
}
