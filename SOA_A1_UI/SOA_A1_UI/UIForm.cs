using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            usernamelbl.Text = "EXAMPLE";//CUSTOMER NAME HERE

            for (int i = 0; i < numberOfPurchases; i++)
            {
                ItemBox.Items.Add("ItemAt["+ i +"]");//ITEM BEING PURCHASED HERE
                ItemBox.Items.Add("ItemPriceAt[" + i + "]");//PRICE OF ITEM BEING PURCHASED HERE
                totalItemPrice += 1.25;//ITEMS PRICE BEING ADDED UP FOR TOTAL
            }
            itemTotal.Text = totalItemPrice.ToString();
        }
    }
}
