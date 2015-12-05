using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
namespace SOA_A1_UI
{
    public partial class UIForm : Form
    {
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
            List<double> itemCosts = new List<double>() {8.25, 2.99, 3.99, 5.00};
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
        }

        private void regionCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int i in regionCheck.CheckedIndices)
            {
                regionCheck.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
    }
}
