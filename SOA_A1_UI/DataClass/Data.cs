using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClass
{
    public class Data
    {
        double total;
        string regionCode;
        string teamName;
        string teamID;
        string serviceTag;
        string serviceName;
        int securityLevel;
        int numArg;
        int numResp;
        string description;
        int[] argPosition = new int[2];
        string[] argName = new string[2];
        string[] argDataType = new string[2];       
        int[] responsePos = new int [5];
        string[] responseName = new string[5];
        string[] resDataType = new string[5];
        string publishIP;
        int publishPort;

        public Data()
        {

        }
       
    }
}
