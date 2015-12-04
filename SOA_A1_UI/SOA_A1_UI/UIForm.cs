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
            double numberOfPurchases = 1, totalItemPrice = 0;
            //grab the name of the customer and their purchases

            //insert those details into the

           // usernamelbl.Text = "EXAMPLE";//CUSTOMER NAME HERE

            for (int i = 0; i < numberOfPurchases; i++)
            {
                //ItemB.Items.Add("ItemAt["+ i +"]");//ITEM BEING PURCHASED HERE
                //ItemB.Items.Add("ItemPriceAt[" + i + "]");//PRICE OF ITEM BEING PURCHASED HERE
                totalItemPrice += 1.25;//ITEMS PRICE BEING ADDED UP FOR TOTAL
            }
            itemTotal.Text = totalItemPrice.ToString();

        }

        private void GrabTotalBtn_Click(object sender, EventArgs e)
        {
            double totalItemPrice = 0;
            for (int i = 0; i < ItemBox.Items.Count; i++)
            {
                //check to see if the current index is checked
                ItemBox.GetItemChecked(i);

                //add the price of the checked item to the item total
                totalItemPrice += Convert.ToDouble(ItemPrices.Items.IndexOf(i).ToString());
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
