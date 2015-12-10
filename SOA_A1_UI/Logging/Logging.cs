/*************
*Programmers    : Connor McQuade & Brandon Erb & Dallas Thibodeau
*Professor      : Ed Barsalou
*Date           : 6/12/2015
*FILE           : Logging.cs
*Description    : code for logging information. can be called upon with a reference
**************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Logging
    {
        /*
        * Method        : logger
        * Returns       : none
        * Parameters    : none
        * Description   : takes in a message (not nessesarily an error) and formats it for
                        : the log file. it also makes sure the logging location is available
                        : and if it is not, creates it and grabs permission by using the Grant Access
                        : method.
        */
        public void logger(string errorMessage)
        {
            //Grab the path of the App_data folder to store the log in
            var path = System.IO.Path.GetFullPath("../../App_Data/");
            //if the folder we need doesnt exist create it
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            //get access to the folder that was created and make sure it was successfull
            if (GrantAccess(path) == true)
            {
                //if the access to the folder was successfull, write the error to the log file
                System.IO.File.AppendAllText(path + "logFile.txt", DateTime.Now + ", SOA Client, C.McQuade-B.Erb-D.Thibodeau: " + errorMessage + Environment.NewLine);
            }

        }

        /*
        * Method        : GrantAccess
        * Returns       : a success or fail
        * Parameters    : a path to the folder to grant access too
        * Description   : aquire access to the folder given in the file path
        */

        private bool GrantAccess(string fullPath)
        {
            //grab the directory information
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            //access the directories security for modification
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            //add new permissions for the application to properly log
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                                                            FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                                                            PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            //apply those permissions to the directory
            dInfo.SetAccessControl(dSecurity);
            return true;
        }
    }
}
