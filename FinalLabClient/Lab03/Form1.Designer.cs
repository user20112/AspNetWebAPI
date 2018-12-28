namespace Lab03
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.footer = new System.Windows.Forms.Label();
            this.StoreList = new System.Windows.Forms.ListView();
            this.BookList = new System.Windows.Forms.ListView();
            this.StoresLabel = new System.Windows.Forms.Label();
            this.CurrentLabel = new System.Windows.Forms.Label();
            this.BooksLabel = new System.Windows.Forms.Label();
            this.ShiftLeft = new System.Windows.Forms.Button();
            this.ShiftRight = new System.Windows.Forms.Button();
            this.NewOrder = new System.Windows.Forms.Button();
            this.OrderList = new System.Windows.Forms.ListView();
            this.OrdersLabel = new System.Windows.Forms.Label();
            this.DeleteOrder = new System.Windows.Forms.Button();
            this.PaymentLabel = new System.Windows.Forms.Label();
            this.CurrentList = new System.Windows.Forms.ListView();
            this.lable1 = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.NumericUpDown();
            this.ResetData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // footer
            // 
            this.footer.AutoSize = true;
            this.footer.Location = new System.Drawing.Point(0, 513);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(0, 13);
            this.footer.TabIndex = 21;
            this.footer.Visible = false;
            // 
            // StoreList
            // 
            this.StoreList.Location = new System.Drawing.Point(12, 42);
            this.StoreList.MultiSelect = false;
            this.StoreList.Name = "StoreList";
            this.StoreList.Size = new System.Drawing.Size(155, 186);
            this.StoreList.TabIndex = 22;
            this.StoreList.UseCompatibleStateImageBehavior = false;
            // 
            // BookList
            // 
            this.BookList.Location = new System.Drawing.Point(12, 319);
            this.BookList.MultiSelect = false;
            this.BookList.Name = "BookList";
            this.BookList.Size = new System.Drawing.Size(486, 155);
            this.BookList.TabIndex = 24;
            this.BookList.UseCompatibleStateImageBehavior = false;
            this.BookList.Visible = false;
            // 
            // StoresLabel
            // 
            this.StoresLabel.AutoSize = true;
            this.StoresLabel.Location = new System.Drawing.Point(12, 26);
            this.StoresLabel.Name = "StoresLabel";
            this.StoresLabel.Size = new System.Drawing.Size(37, 13);
            this.StoresLabel.TabIndex = 26;
            this.StoresLabel.Text = "Stores";
            // 
            // CurrentLabel
            // 
            this.CurrentLabel.AutoSize = true;
            this.CurrentLabel.Location = new System.Drawing.Point(593, 300);
            this.CurrentLabel.Name = "CurrentLabel";
            this.CurrentLabel.Size = new System.Drawing.Size(70, 13);
            this.CurrentLabel.TabIndex = 27;
            this.CurrentLabel.Text = "Current Order";
            this.CurrentLabel.Visible = false;
            // 
            // BooksLabel
            // 
            this.BooksLabel.AutoSize = true;
            this.BooksLabel.Location = new System.Drawing.Point(192, 300);
            this.BooksLabel.Name = "BooksLabel";
            this.BooksLabel.Size = new System.Drawing.Size(83, 13);
            this.BooksLabel.TabIndex = 28;
            this.BooksLabel.Text = "Available Books";
            this.BooksLabel.Visible = false;
            // 
            // ShiftLeft
            // 
            this.ShiftLeft.Location = new System.Drawing.Point(523, 348);
            this.ShiftLeft.Name = "ShiftLeft";
            this.ShiftLeft.Size = new System.Drawing.Size(49, 23);
            this.ShiftLeft.TabIndex = 29;
            this.ShiftLeft.Text = "<<";
            this.ShiftLeft.UseVisualStyleBackColor = true;
            this.ShiftLeft.Visible = false;
            this.ShiftLeft.Click += new System.EventHandler(this.ShiftLeft_Click);
            // 
            // ShiftRight
            // 
            this.ShiftRight.Location = new System.Drawing.Point(523, 416);
            this.ShiftRight.Name = "ShiftRight";
            this.ShiftRight.Size = new System.Drawing.Size(49, 23);
            this.ShiftRight.TabIndex = 30;
            this.ShiftRight.Text = ">>";
            this.ShiftRight.UseVisualStyleBackColor = true;
            this.ShiftRight.Visible = false;
            this.ShiftRight.Click += new System.EventHandler(this.ShiftRight_Click);
            // 
            // NewOrder
            // 
            this.NewOrder.Location = new System.Drawing.Point(300, 42);
            this.NewOrder.Name = "NewOrder";
            this.NewOrder.Size = new System.Drawing.Size(75, 23);
            this.NewOrder.TabIndex = 31;
            this.NewOrder.Text = "New Order";
            this.NewOrder.UseVisualStyleBackColor = true;
            this.NewOrder.Visible = false;
            this.NewOrder.Click += new System.EventHandler(this.NewOrder_Click);
            // 
            // OrderList
            // 
            this.OrderList.Location = new System.Drawing.Point(173, 42);
            this.OrderList.MultiSelect = false;
            this.OrderList.Name = "OrderList";
            this.OrderList.Size = new System.Drawing.Size(121, 186);
            this.OrderList.TabIndex = 33;
            this.OrderList.UseCompatibleStateImageBehavior = false;
            this.OrderList.Visible = false;
            // 
            // OrdersLabel
            // 
            this.OrdersLabel.AutoSize = true;
            this.OrdersLabel.Location = new System.Drawing.Point(173, 23);
            this.OrdersLabel.Name = "OrdersLabel";
            this.OrdersLabel.Size = new System.Drawing.Size(38, 13);
            this.OrdersLabel.TabIndex = 34;
            this.OrdersLabel.Text = "Orders";
            this.OrdersLabel.Visible = false;
            // 
            // DeleteOrder
            // 
            this.DeleteOrder.Location = new System.Drawing.Point(301, 72);
            this.DeleteOrder.Name = "DeleteOrder";
            this.DeleteOrder.Size = new System.Drawing.Size(75, 23);
            this.DeleteOrder.TabIndex = 35;
            this.DeleteOrder.Text = "Delete Order";
            this.DeleteOrder.UseVisualStyleBackColor = true;
            this.DeleteOrder.Visible = false;
            this.DeleteOrder.Click += new System.EventHandler(this.DeleteOrder_Click);
            // 
            // PaymentLabel
            // 
            this.PaymentLabel.AutoSize = true;
            this.PaymentLabel.Location = new System.Drawing.Point(301, 101);
            this.PaymentLabel.Name = "PaymentLabel";
            this.PaymentLabel.Size = new System.Drawing.Size(183, 13);
            this.PaymentLabel.TabIndex = 39;
            this.PaymentLabel.Text = "Empty Orders will be deleted on close";
            this.PaymentLabel.Visible = false;
            // 
            // CurrentList
            // 
            this.CurrentList.Location = new System.Drawing.Point(596, 319);
            this.CurrentList.Name = "CurrentList";
            this.CurrentList.Size = new System.Drawing.Size(397, 159);
            this.CurrentList.TabIndex = 40;
            this.CurrentList.UseCompatibleStateImageBehavior = false;
            this.CurrentList.Visible = false;
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(527, 374);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(46, 13);
            this.lable1.TabIndex = 41;
            this.lable1.Text = "Quantity";
            this.lable1.Visible = false;
            // 
            // Quantity
            // 
            this.Quantity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Quantity.Location = new System.Drawing.Point(530, 390);
            this.Quantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(43, 20);
            this.Quantity.TabIndex = 42;
            this.Quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Quantity.Visible = false;
            // 
            // ResetData
            // 
            this.ResetData.Location = new System.Drawing.Point(902, 18);
            this.ResetData.Name = "ResetData";
            this.ResetData.Size = new System.Drawing.Size(91, 23);
            this.ResetData.TabIndex = 44;
            this.ResetData.Text = "ResetDatabase.";
            this.ResetData.UseVisualStyleBackColor = true;
            this.ResetData.Click += new System.EventHandler(this.ResetData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(924, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Takes a bit";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "OnInvoice",
            "Net 30",
            "Net 60"});
            this.comboBox1.Location = new System.Drawing.Point(301, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 21);
            this.comboBox1.TabIndex = 46;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "PayTerms for entire order";
            this.label3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 519);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ResetData);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.CurrentList);
            this.Controls.Add(this.PaymentLabel);
            this.Controls.Add(this.DeleteOrder);
            this.Controls.Add(this.OrdersLabel);
            this.Controls.Add(this.OrderList);
            this.Controls.Add(this.NewOrder);
            this.Controls.Add(this.ShiftRight);
            this.Controls.Add(this.ShiftLeft);
            this.Controls.Add(this.BooksLabel);
            this.Controls.Add(this.CurrentLabel);
            this.Controls.Add(this.StoresLabel);
            this.Controls.Add(this.BookList);
            this.Controls.Add(this.StoreList);
            this.Controls.Add(this.footer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PubsDB Interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label footer;
        private System.Windows.Forms.ListView StoreList;
        private System.Windows.Forms.ListView BookList;
        private System.Windows.Forms.Label StoresLabel;
        private System.Windows.Forms.Label CurrentLabel;
        private System.Windows.Forms.Label BooksLabel;
        private System.Windows.Forms.Button ShiftLeft;
        private System.Windows.Forms.Button ShiftRight;
        private System.Windows.Forms.Button NewOrder;
        private System.Windows.Forms.ListView OrderList;
        private System.Windows.Forms.Label OrdersLabel;
        private System.Windows.Forms.Button DeleteOrder;
        private System.Windows.Forms.Label PaymentLabel;
        private System.Windows.Forms.ListView CurrentList;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.NumericUpDown Quantity;
        private System.Windows.Forms.Button ResetData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
    }
}

