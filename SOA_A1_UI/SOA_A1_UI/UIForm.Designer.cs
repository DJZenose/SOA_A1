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
            this.ItemTotallbl.Location = new System.Drawing.Point(164, 325);
            this.ItemTotallbl.Name = "ItemTotallbl";
            this.ItemTotallbl.Size = new System.Drawing.Size(59, 13);
            this.ItemTotallbl.TabIndex = 2;
            this.ItemTotallbl.Text = "Items Total";
            // 
            // itemTotal
            // 
            this.itemTotal.AutoSize = true;
            this.itemTotal.Location = new System.Drawing.Point(296, 325);
            this.itemTotal.Name = "itemTotal";
            this.itemTotal.Size = new System.Drawing.Size(28, 13);
            this.itemTotal.TabIndex = 3;
            this.itemTotal.Text = "0.00";
            // 
            // pstTotal
            // 
            this.pstTotal.AutoSize = true;
            this.pstTotal.Location = new System.Drawing.Point(296, 348);
            this.pstTotal.Name = "pstTotal";
            this.pstTotal.Size = new System.Drawing.Size(28, 13);
            this.pstTotal.TabIndex = 5;
            this.pstTotal.Text = "0.00";
            // 
            // PST
            // 
            this.PST.AutoSize = true;
            this.PST.Location = new System.Drawing.Point(164, 348);
            this.PST.Name = "PST";
            this.PST.Size = new System.Drawing.Size(31, 13);
            this.PST.TabIndex = 4;
            this.PST.Text = "PST:";
            // 
            // hstTotal
            // 
            this.hstTotal.AutoSize = true;
            this.hstTotal.Location = new System.Drawing.Point(296, 371);
            this.hstTotal.Name = "hstTotal";
            this.hstTotal.Size = new System.Drawing.Size(28, 13);
            this.hstTotal.TabIndex = 7;
            this.hstTotal.Text = "0.00";
            // 
            // HST
            // 
            this.HST.AutoSize = true;
            this.HST.Location = new System.Drawing.Point(164, 371);
            this.HST.Name = "HST";
            this.HST.Size = new System.Drawing.Size(32, 13);
            this.HST.TabIndex = 6;
            this.HST.Text = "HST:";
            // 
            // gstTotal
            // 
            this.gstTotal.AutoSize = true;
            this.gstTotal.Location = new System.Drawing.Point(296, 392);
            this.gstTotal.Name = "gstTotal";
            this.gstTotal.Size = new System.Drawing.Size(28, 13);
            this.gstTotal.TabIndex = 9;
            this.gstTotal.Text = "0.00";
            // 
            // GST
            // 
            this.GST.AutoSize = true;
            this.GST.Location = new System.Drawing.Point(164, 392);
            this.GST.Name = "GST";
            this.GST.Size = new System.Drawing.Size(32, 13);
            this.GST.TabIndex = 8;
            this.GST.Text = "GST:";
            // 
            // totalPrice
            // 
            this.totalPrice.AutoSize = true;
            this.totalPrice.Location = new System.Drawing.Point(296, 414);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(28, 13);
            this.totalPrice.TabIndex = 11;
            this.totalPrice.Text = "0.00";
            // 
            // TotalPricelbl
            // 
            this.TotalPricelbl.AutoSize = true;
            this.TotalPricelbl.Location = new System.Drawing.Point(164, 414);
            this.TotalPricelbl.Name = "TotalPricelbl";
            this.TotalPricelbl.Size = new System.Drawing.Size(58, 13);
            this.TotalPricelbl.TabIndex = 10;
            this.TotalPricelbl.Text = "Total Price";
            // 
            // ItemPrices
            // 
            this.ItemPrices.FormattingEnabled = true;
            this.ItemPrices.Items.AddRange(new object[] {
            "8.25",
            "4.50",
            "2.99",
            "10.99"});
            this.ItemPrices.Location = new System.Drawing.Point(36, 12);
            this.ItemPrices.Name = "ItemPrices";
            this.ItemPrices.Size = new System.Drawing.Size(36, 17);
            this.ItemPrices.TabIndex = 13;
            this.ItemPrices.Visible = false;
            // 
            // GrabTotalBtn
            // 
            this.GrabTotalBtn.Location = new System.Drawing.Point(163, 299);
            this.GrabTotalBtn.Name = "GrabTotalBtn";
            this.GrabTotalBtn.Size = new System.Drawing.Size(161, 23);
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
            this.ItemBox.Location = new System.Drawing.Point(12, 12);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(105, 19);
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
            this.regionCheck.Location = new System.Drawing.Point(185, 94);
            this.regionCheck.Name = "regionCheck";
            this.regionCheck.Size = new System.Drawing.Size(121, 199);
            this.regionCheck.TabIndex = 18;
            this.regionCheck.SelectedIndexChanged += new System.EventHandler(this.regionCheck_SelectedIndexChanged);
            // 
            // unRegisterbtn
            // 
            this.unRegisterbtn.Location = new System.Drawing.Point(168, 35);
            this.unRegisterbtn.Name = "unRegisterbtn";
            this.unRegisterbtn.Size = new System.Drawing.Size(161, 23);
            this.unRegisterbtn.TabIndex = 19;
            this.unRegisterbtn.Text = "UN-Register Team";
            this.unRegisterbtn.UseVisualStyleBackColor = true;
            this.unRegisterbtn.Click += new System.EventHandler(this.unRegisterbtn_Click);
            // 
            // IDValidLabel
            // 
            this.IDValidLabel.AutoSize = true;
            this.IDValidLabel.Location = new System.Drawing.Point(61, 12);
            this.IDValidLabel.Name = "IDValidLabel";
            this.IDValidLabel.Size = new System.Drawing.Size(37, 13);
            this.IDValidLabel.TabIndex = 20;
            this.IDValidLabel.Text = "NO ID";
            this.IDValidLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Price Total";
            // 
            // Pricetxt
            // 
            this.Pricetxt.Location = new System.Drawing.Point(229, 66);
            this.Pricetxt.Name = "Pricetxt";
            this.Pricetxt.Size = new System.Drawing.Size(100, 20);
            this.Pricetxt.TabIndex = 22;
            // 
            // Registerbtn
            // 
            this.Registerbtn.Location = new System.Drawing.Point(168, 12);
            this.Registerbtn.Name = "Registerbtn";
            this.Registerbtn.Size = new System.Drawing.Size(161, 23);
            this.Registerbtn.TabIndex = 23;
            this.Registerbtn.Text = "Register Team";
            this.Registerbtn.UseVisualStyleBackColor = true;
            this.Registerbtn.Click += new System.EventHandler(this.Registerbtn_Click);
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 454);
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

