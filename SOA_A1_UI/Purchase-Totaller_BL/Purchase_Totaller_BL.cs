using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase_Totaller_BL
{
    public class Totaller
    {
        public static double[] getTotal(string regionArg, double totalUnmodified)
        {
            int regionNum = 0;
            double[] finalValues = new double[5] {0,0,0,0,0};
                                        //NL/NS/NB/PE////QC////ON//MB///SK///AB//BC/YT/NT/NU
            double[] PST = new double[] { 0, 0, 0, 0.1, 0.095, 0, 0.07, 0.05, 0, 0, 0, 0, 0};
            double[] HST = new double[] { 0.13, 0.15, 0.13, 0, 0, 0.13, 0, 0, 0, 0.12, 0, 0, 0};
            double[] GST = new double[] { 0, 0, 0, 0.05, 0.05, 0, 0.05, 0.05, 0.05, 0, 0.05, 0.05, 0.05};


            if ((regionArg == "NL" || regionArg == "NS" || regionArg == "NB" || regionArg == "PE" || regionArg == "QC" ||
                regionArg == "ON" || regionArg == "MB" || regionArg == "SK" || regionArg == "AB" || regionArg == "BC" ||
                regionArg == "YT" || regionArg == "NT" || regionArg == "NU" ) && totalUnmodified > 0)
            {
                switch (regionArg)
                {
                    case "NL":
                        regionNum = 0;
                        break;
                    case "NS":
                        regionNum = 1;
                        break;
                    case "NB":
                        regionNum = 2;
                        break;
                    case "PE":
                        regionNum = 3;
                        break;
                    case "QC":
                        regionNum = 4;
                        break;
                    case "OB":
                        regionNum = 5;
                        break;
                    case "MB":
                        regionNum = 6;
                        break;
                    case "SK":
                        regionNum = 7;
                        break;
                    case "AB":
                        regionNum = 8;
                        break;
                    case "BC":
                        regionNum = 9;
                        break;
                    case "YT":
                        regionNum = 10;
                        break;
                    case "NT":
                        regionNum = 11;
                        break;
                    case "NU":
                        regionNum = 12;
                        break;
                    default:
                        break;
                }
                finalValues[0] = totalUnmodified;
                finalValues[1] = totalUnmodified * (PST[regionNum]);
                finalValues[2] = totalUnmodified * (HST[regionNum]);
                finalValues[3] = totalUnmodified * (GST[regionNum]);
                finalValues[4] = totalUnmodified + finalValues[1] + finalValues[2] + finalValues[3];
            }
            else if (totalUnmodified <= 0)
            {
                Exception ex = new Exception("Invalid input. Total unmodified must be greater than 0.");
                throw ex;
            }
            else
            {
                Exception ex = new Exception("Invalid input. Region code does not exist.");
                throw ex;
            }
            return finalValues;
        }
    }
}
