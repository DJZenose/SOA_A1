using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClass
{
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
        public int[] responsePos = new int [5];
        public string[] responseName = new string[5];
        public string[] resDataType = new string[5];
        public string publishIP;
        public int publishPort;

        public Data()
        {

        }
       
    }
}
