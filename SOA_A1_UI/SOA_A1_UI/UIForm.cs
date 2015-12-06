using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Security.AccessControl;
using System.IO;
using System.Security.Principal;

namespace SOA_A1_UI
{
    public partial class UIForm : Form
    {
        private const int minimum = 0, firstIndex = 0;
        public UIForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
        }

        private void GrabTotalBtn_Click(object sender, EventArgs e)
        {
            double totalItemPrice = 0;
            string regionCode = "";
            List<double> itemCosts = new List<double>() {8.25, 2.99, 3.99, 5.00};

            if (regionCheck.CheckedItems.Count != minimum)
            {
                regionCode = regionCheck.CheckedItems[firstIndex].ToString();
            }
            
            for (int i = 0; i < ItemBox.Items.Count; i++)
            {
                //check to see if the current index is checked
                if (ItemBox.GetItemChecked(i) == true)
                {
                    //add the price of the checked item to the item total
                    totalItemPrice += itemCosts[i];
                }
            }
            //display the users total purchase (might change this to an onclick event)
            itemTotal.Text = totalItemPrice.ToString();

            Call_PurchaseTotaller(totalItemPrice, regionCode);
        }

        private void Call_PurchaseTotaller(double totalItemPrice, string regionCode)
        {
            

            try
            {
                //check to see that the itemprice is valid & the postal code is valid
                if (totalItemPrice >= 0 && regionCode != "")
                {
                    //call the service here with the needed variables in the right order
                }
                else
                {
                    //JUST A TEST TO TRY LOGGING //CURRENTLY SUCCESSFULL
                    throw new Exception("TEST");
                }
            }
            catch (Exception ex)
            {
                //use logerror to send the error message to the log file
                logError(ex.Message);
            }
        }
        private void regionCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int i in regionCheck.CheckedIndices)
            {
                regionCheck.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void logError(string errorMessage)
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
                System.IO.File.AppendAllText(path + "logFile.txt", DateTime.Now + ": " + errorMessage + Environment.NewLine);
            }
            
        }

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
