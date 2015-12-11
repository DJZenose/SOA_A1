namespace SOA_A1_UI
{
    partial class UIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemTotallbl = new System.Windows.Forms.Label();
            this.itemTotal = new System.Windows.Forms.Label();
            this.pstTotal = new System.Windows.Forms.Label();
            this.PST = new System.Windows.Forms.Label();
            this.hstTotal = new System.Windows.Forms.Label();
            this.HST = new System.Windows.Forms.Label();
            this.gstTotal = new System.Windows.Forms.Label();
            this.GST = new System.Windows.Forms.Label();
            this.totalPrice = new System.Windows.Forms.Label();
            this.TotalPricelbl = new System.Windows.Forms.Label();
            this.ItemPrices = new System.Windows.Forms.ListBox();
            this.GrabTotalBtn = new System.Windows.Forms.Button();
            this.ItemBox = new System.Windows.Forms.CheckedListBox();
            this.regionCheck = new System.Windows.Forms.CheckedListBox();
            this.unRegisterbtn = new System.Windows.Forms.Button();
            this.IDValidLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Pricetxt = new System.Windows.Forms.TextBox();
            this.Registerbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ItemTotallbl
            // 
            this.ItemTotallbl.AutoSize = true;
            this.ItemTotallbl.Location = new System.Drawing.Point(219, 400);
            this.ItemTotallbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ItemTotallbl.Name = "ItemTotallbl";
            this.ItemTotallbl.Size = new System.Drawing.Size(77, 17);
            this.ItemTotallbl.TabIndex = 2;
            this.ItemTotallbl.Text = "Items Total";
            // 
            // itemTotal
            // 
            this.itemTotal.AutoSize = true;
            this.itemTotal.Location = new System.Drawing.Point(395, 400);
            this.itemTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itemTotal.Name = "itemTotal";
            this.itemTotal.Size = new System.Drawing.Size(36, 17);
            this.itemTotal.TabIndex = 3;
            this.itemTotal.Text = "0.00";
            // 
            // pstTotal
            // 
            this.pstTotal.AutoSize = true;
            this.pstTotal.Location = new System.Drawing.Point(395, 428);
            this.pstTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pstTotal.Name = "pstTotal";
            this.pstTotal.Size = new System.Drawing.Size(36, 17);
            this.pstTotal.TabIndex = 5;
            this.pstTotal.Text = "0.00";
            // 
            // PST
            // 
            this.PST.AutoSize = true;
            this.PST.Location = new System.Drawing.Point(219, 428);
            this.PST.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PST.Name = "PST";
            this.PST.Size = new System.Drawing.Size(39, 17);
            this.PST.TabIndex = 4;
            this.PST.Text = "PST:";
            // 
            // hstTotal
            // 
            this.hstTotal.AutoSize = true;
            this.hstTotal.Location = new System.Drawing.Point(395, 457);
            this.hstTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hstTotal.Name = "hstTotal";
            this.hstTotal.Size = new System.Drawing.Size(36, 17);
            this.hstTotal.TabIndex = 7;
            this.hstTotal.Text = "0.00";
            // 
            // HST
            // 
            this.HST.AutoSize = true;
            this.HST.Location = new System.Drawing.Point(219, 457);
            this.HST.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HST.Name = "HST";
            this.HST.Size = new System.Drawing.Size(40, 17);
            this.HST.TabIndex = 6;
            this.HST.Text = "HST:";
            // 
            // gstTotal
            // 
            this.gstTotal.AutoSize = true;
            this.gstTotal.Location = new System.Drawing.Point(395, 482);
            this.gstTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gstTotal.Name = "gstTotal";
            this.gstTotal.Size = new System.Drawing.Size(36, 17);
            this.gstTotal.TabIndex = 9;
            this.gstTotal.Text = "0.00";
            // 
            // GST
            // 
            this.GST.AutoSize = true;
            this.GST.Location = new System.Drawing.Point(219, 482);
            this.GST.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GST.Name = "GST";
            this.GST.Size = new System.Drawing.Size(41, 17);
            this.GST.TabIndex = 8;
            this.GST.Text = "GST:";
            // 
            // totalPrice
            // 
            this.totalPrice.AutoSize = true;
            this.totalPrice.Location = new System.Drawing.Point(395, 510);
            this.totalPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(36, 17);
            this.totalPrice.TabIndex = 11;
            this.totalPrice.Text = "0.00";
            // 
            // TotalPricelbl
            // 
            this.TotalPricelbl.AutoSize = true;
            this.TotalPricelbl.Location = new System.Drawing.Point(219, 510);
            this.TotalPricelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotalPricelbl.Name = "TotalPricelbl";
            this.TotalPricelbl.Size = new System.Drawing.Size(76, 17);
            this.TotalPricelbl.TabIndex = 10;
            this.TotalPricelbl.Text = "Total Price";
            // 
            // ItemPrices
            // 
            this.ItemPrices.FormattingEnabled = true;
            this.ItemPrices.ItemHeight = 16;
            this.ItemPrices.Items.AddRange(new object[] {
            "8.25",
            "4.50",
            "2.99",
            "10.99"});
            this.ItemPrices.Location = new System.Drawing.Point(48, 15);
            this.ItemPrices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ItemPrices.Name = "ItemPrices";
            this.ItemPrices.Size = new System.Drawing.Size(47, 20);
            this.ItemPrices.TabIndex = 13;
            this.ItemPrices.Visible = false;
            // 
            // GrabTotalBtn
            // 
            this.GrabTotalBtn.Location = new System.Drawing.Point(217, 368);
            this.GrabTotalBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GrabTotalBtn.Name = "GrabTotalBtn";
            this.GrabTotalBtn.Size = new System.Drawing.Size(215, 28);
            this.GrabTotalBtn.TabIndex = 14;
            this.GrabTotalBtn.Text = "Grab Total";
            this.GrabTotalBtn.UseVisualStyleBackColor = true;
            this.GrabTotalBtn.Click += new System.EventHandler(this.GrabTotalBtn_Click);
            // 
            // ItemBox
            // 
            this.ItemBox.FormattingEnabled = true;
            this.ItemBox.Items.AddRange(new object[] {
            "GIORP",
            "ITEM 2",
            "ITEM 3",
            "ITEM 4"});
            this.ItemBox.Location = new System.Drawing.Point(16, 15);
            this.ItemBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(139, 21);
            this.ItemBox.TabIndex = 15;
            this.ItemBox.Tag = "";
            this.ItemBox.Visible = false;
            // 
            // regionCheck
            // 
            this.regionCheck.FormattingEnabled = true;
            this.regionCheck.Items.AddRange(new object[] {
            "NL",
            "NS",
            "NB",
            "PE",
            "QC",
            "ON",
            "MB",
            "SK",
            "AB",
            "BC",
            "YT",
            "NT",
            "NU"});
            this.regionCheck.Location = new System.Drawing.Point(247, 116);
            this.regionCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.regionCheck.Name = "regionCheck";
            this.regionCheck.Size = new System.Drawing.Size(160, 242);
            this.regionCheck.TabIndex = 18;
            this.regionCheck.SelectedIndexChanged += new System.EventHandler(this.regionCheck_SelectedIndexChanged);
            // 
            // unRegisterbtn
            // 
            this.unRegisterbtn.Location = new System.Drawing.Point(224, 43);
            this.unRegisterbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.unRegisterbtn.Name = "unRegisterbtn";
            this.unRegisterbtn.Size = new System.Drawing.Size(215, 28);
            this.unRegisterbtn.TabIndex = 19;
            this.unRegisterbtn.Text = "UN-Register Team";
            this.unRegisterbtn.UseVisualStyleBackColor = true;
            this.unRegisterbtn.Click += new System.EventHandler(this.unRegisterbtn_Click);
            // 
            // IDValidLabel
            // 
            this.IDValidLabel.AutoSize = true;
            this.IDValidLabel.Location = new System.Drawing.Point(81, 15);
            this.IDValidLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDValidLabel.Name = "IDValidLabel";
            this.IDValidLabel.Size = new System.Drawing.Size(46, 17);
            this.IDValidLabel.TabIndex = 20;
            this.IDValidLabel.Text = "NO ID";
            this.IDValidLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Price Total";
            // 
            // Pricetxt
            // 
            this.Pricetxt.Location = new System.Drawing.Point(305, 81);
            this.Pricetxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pricetxt.Name = "Pricetxt";
            this.Pricetxt.Size = new System.Drawing.Size(132, 22);
            this.Pricetxt.TabIndex = 22;
            // 
            // Registerbtn
            // 
            this.Registerbtn.Location = new System.Drawing.Point(224, 15);
            this.Registerbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Registerbtn.Name = "Registerbtn";
            this.Registerbtn.Size = new System.Drawing.Size(215, 28);
            this.Registerbtn.TabIndex = 23;
            this.Registerbtn.Text = "Register Team";
            this.Registerbtn.UseVisualStyleBackColor = true;
            this.Registerbtn.Click += new System.EventHandler(this.Registerbtn_Click);
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 559);
            this.Controls.Add(this.Registerbtn);
            this.Controls.Add(this.Pricetxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDValidLabel);
            this.Controls.Add(this.unRegisterbtn);
            this.Controls.Add(this.regionCheck);
            this.Controls.Add(this.ItemBox);
            this.Controls.Add(this.GrabTotalBtn);
            this.Controls.Add(this.ItemPrices);
            this.Controls.Add(this.totalPrice);
            this.Controls.Add(this.TotalPricelbl);
            this.Controls.Add(this.gstTotal);
            this.Controls.Add(this.GST);
            this.Controls.Add(this.hstTotal);
            this.Controls.Add(this.HST);
            this.Controls.Add(this.pstTotal);
            this.Controls.Add(this.PST);
            this.Controls.Add(this.itemTotal);
            this.Controls.Add(this.ItemTotallbl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UIForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ItemTotallbl;
        private System.Windows.Forms.Label itemTotal;
        private System.Windows.Forms.Label pstTotal;
        private System.Windows.Forms.Label PST;
        private System.Windows.Forms.Label hstTotal;
        private System.Windows.Forms.Label HST;
        private System.Windows.Forms.Label gstTotal;
        private System.Windows.Forms.Label GST;
        private System.Windows.Forms.Label totalPrice;
        private System.Windows.Forms.Label TotalPricelbl;
        private System.Windows.Forms.ListBox ItemPrices;
        private System.Windows.Forms.Button GrabTotalBtn;
        private System.Windows.Forms.CheckedListBox ItemBox;
        private System.Windows.Forms.CheckedListBox regionCheck;
        private System.Windows.Forms.Button unRegisterbtn;
        private System.Windows.Forms.Label IDValidLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Pricetxt;
        private System.Windows.Forms.Button Registerbtn;
    }
}

