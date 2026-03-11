namespace Store
{
    partial class SupplierProductsCardForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.returnButton = new System.Windows.Forms.Button();
            this.newProdButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.inpDateLabel = new System.Windows.Forms.Label();
            this.supProdLabel = new System.Windows.Forms.Label();
            this.counteragentComboBox = new System.Windows.Forms.ComboBox();
            this.inpNumberTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.CounteragentLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.returnButton);
            this.panel1.Controls.Add(this.newProdButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.inpDateLabel);
            this.panel1.Controls.Add(this.supProdLabel);
            this.panel1.Controls.Add(this.counteragentComboBox);
            this.panel1.Controls.Add(this.inpNumberTextBox);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.CounteragentLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 146);
            this.panel1.TabIndex = 0;
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(577, 98);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(169, 30);
            this.returnButton.TabIndex = 10;
            this.returnButton.Text = "Выбрать возврат";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Visible = false;
            // 
            // newProdButton
            // 
            this.newProdButton.Location = new System.Drawing.Point(395, 99);
            this.newProdButton.Name = "newProdButton";
            this.newProdButton.Size = new System.Drawing.Size(157, 29);
            this.newProdButton.TabIndex = 9;
            this.newProdButton.Text = "Новый товар";
            this.newProdButton.UseVisualStyleBackColor = true;
            this.newProdButton.Click += new System.EventHandler(this.newProdButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(752, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Вх. номер прихода";
            // 
            // inpDateLabel
            // 
            this.inpDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inpDateLabel.AutoSize = true;
            this.inpDateLabel.Location = new System.Drawing.Point(558, 105);
            this.inpDateLabel.Name = "inpDateLabel";
            this.inpDateLabel.Size = new System.Drawing.Size(155, 20);
            this.inpDateLabel.TabIndex = 7;
            this.inpDateLabel.Text = "Вх. дата прихода";
            // 
            // supProdLabel
            // 
            this.supProdLabel.AutoSize = true;
            this.supProdLabel.Location = new System.Drawing.Point(32, 107);
            this.supProdLabel.Name = "supProdLabel";
            this.supProdLabel.Size = new System.Drawing.Size(127, 20);
            this.supProdLabel.TabIndex = 6;
            this.supProdLabel.Text = "Дата прихода";
            // 
            // counteragentComboBox
            // 
            this.counteragentComboBox.FormattingEnabled = true;
            this.counteragentComboBox.Location = new System.Drawing.Point(32, 50);
            this.counteragentComboBox.Name = "counteragentComboBox";
            this.counteragentComboBox.Size = new System.Drawing.Size(681, 28);
            this.counteragentComboBox.TabIndex = 5;
            // 
            // inpNumberTextBox
            // 
            this.inpNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.inpNumberTextBox.Location = new System.Drawing.Point(752, 50);
            this.inpNumberTextBox.Name = "inpNumberTextBox";
            this.inpNumberTextBox.Size = new System.Drawing.Size(100, 27);
            this.inpNumberTextBox.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Location = new System.Drawing.Point(752, 98);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(180, 100);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // CounteragentLabel
            // 
            this.CounteragentLabel.AutoSize = true;
            this.CounteragentLabel.Location = new System.Drawing.Point(124, 15);
            this.CounteragentLabel.Name = "CounteragentLabel";
            this.CounteragentLabel.Size = new System.Drawing.Size(108, 20);
            this.CounteragentLabel.TabIndex = 0;
            this.CounteragentLabel.Text = "Контрагент";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(0, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 333);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1000, 333);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Controls.Add(this.OKButton);
            this.panel3.Location = new System.Drawing.Point(609, 491);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 68);
            this.panel3.TabIndex = 2;
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(29, 14);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(149, 36);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Отмена";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OKButton.Location = new System.Drawing.Point(216, 14);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(149, 36);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "-*-";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Product";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.HeaderText = "Quantity";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 205;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "Price";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 206;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.HeaderText = "Sum";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 205;
            // 
            // SupplierProductsCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SupplierProductsCardForm";
            this.Text = "Приход товара";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CounteragentLabel;
        private System.Windows.Forms.TextBox inpNumberTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox counteragentComboBox;
        private System.Windows.Forms.Label inpDateLabel;
        private System.Windows.Forms.Label supProdLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button newProdButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}