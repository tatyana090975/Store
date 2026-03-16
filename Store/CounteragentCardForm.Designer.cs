namespace Store
{
    partial class CounteragentCardForm
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
            this.contactComboBox = new System.Windows.Forms.ComboBox();
            this.ContactLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.phoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ownershipComboBox = new System.Windows.Forms.ComboBox();
            this.OwnershipLabel = new System.Windows.Forms.Label();
            this.ITNLabel = new System.Windows.Forms.Label();
            this.ITNTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.contactComboBox);
            this.panel1.Controls.Add(this.ContactLabel);
            this.panel1.Controls.Add(this.PhoneLabel);
            this.panel1.Controls.Add(this.phoneMaskedTextBox);
            this.panel1.Controls.Add(this.AddressLabel);
            this.panel1.Controls.Add(this.addressTextBox);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Controls.Add(this.ownershipComboBox);
            this.panel1.Controls.Add(this.OwnershipLabel);
            this.panel1.Controls.Add(this.ITNLabel);
            this.panel1.Controls.Add(this.ITNTextBox);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 544);
            this.panel1.TabIndex = 0;
            // 
            // contactComboBox
            // 
            this.contactComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contactComboBox.FormattingEnabled = true;
            this.contactComboBox.Location = new System.Drawing.Point(228, 338);
            this.contactComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contactComboBox.Name = "contactComboBox";
            this.contactComboBox.Size = new System.Drawing.Size(616, 28);
            this.contactComboBox.TabIndex = 11;
            // 
            // ContactLabel
            // 
            this.ContactLabel.AutoSize = true;
            this.ContactLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContactLabel.Location = new System.Drawing.Point(40, 341);
            this.ContactLabel.Name = "ContactLabel";
            this.ContactLabel.Size = new System.Drawing.Size(154, 20);
            this.ContactLabel.TabIndex = 10;
            this.ContactLabel.Text = "Контактное лицо";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneLabel.Location = new System.Drawing.Point(43, 283);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(85, 20);
            this.PhoneLabel.TabIndex = 9;
            this.PhoneLabel.Text = "Телефон";
            this.PhoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PhoneLabel.UseWaitCursor = true;
            // 
            // phoneMaskedTextBox
            // 
            this.phoneMaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneMaskedTextBox.HideSelection = false;
            this.phoneMaskedTextBox.Location = new System.Drawing.Point(219, 281);
            this.phoneMaskedTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phoneMaskedTextBox.Mask = "+7(000)-000-0000";
            this.phoneMaskedTextBox.Name = "phoneMaskedTextBox";
            this.phoneMaskedTextBox.Size = new System.Drawing.Size(195, 27);
            this.phoneMaskedTextBox.TabIndex = 8;
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddressLabel.Location = new System.Drawing.Point(488, 155);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(62, 20);
            this.AddressLabel.TabIndex = 7;
            this.AddressLabel.Text = "Адрес";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addressTextBox.Location = new System.Drawing.Point(44, 178);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(1017, 73);
            this.addressTextBox.TabIndex = 6;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(44, 105);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(1017, 27);
            this.nameTextBox.TabIndex = 5;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(445, 82);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(134, 20);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "Наименование";
            // 
            // ownershipComboBox
            // 
            this.ownershipComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ownershipComboBox.FormattingEnabled = true;
            this.ownershipComboBox.Location = new System.Drawing.Point(44, 37);
            this.ownershipComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ownershipComboBox.Name = "ownershipComboBox";
            this.ownershipComboBox.Size = new System.Drawing.Size(621, 28);
            this.ownershipComboBox.TabIndex = 3;
            // 
            // OwnershipLabel
            // 
            this.OwnershipLabel.AutoSize = true;
            this.OwnershipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OwnershipLabel.Location = new System.Drawing.Point(224, 14);
            this.OwnershipLabel.Name = "OwnershipLabel";
            this.OwnershipLabel.Size = new System.Drawing.Size(199, 20);
            this.OwnershipLabel.TabIndex = 2;
            this.OwnershipLabel.Text = "Форма собственности";
            // 
            // ITNLabel
            // 
            this.ITNLabel.AutoSize = true;
            this.ITNLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ITNLabel.Location = new System.Drawing.Point(707, 46);
            this.ITNLabel.Name = "ITNLabel";
            this.ITNLabel.Size = new System.Drawing.Size(46, 20);
            this.ITNLabel.TabIndex = 1;
            this.ITNLabel.Text = "ИНН";
            this.ITNLabel.UseMnemonic = false;
            // 
            // ITNTextBox
            // 
            this.ITNTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ITNTextBox.Location = new System.Drawing.Point(780, 37);
            this.ITNTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ITNTextBox.Name = "ITNTextBox";
            this.ITNTextBox.Size = new System.Drawing.Size(281, 27);
            this.ITNTextBox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.OKButton);
            this.panel2.Controls.Add(this.CloseButton);
            this.panel2.Location = new System.Drawing.Point(695, 434);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 97);
            this.panel2.TabIndex = 1;
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OKButton.Location = new System.Drawing.Point(219, 28);
            this.OKButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(161, 46);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "ОК";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(37, 28);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(161, 46);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "Отмена";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1125, 544);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "Контрагент";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ITNTextBox;
        private System.Windows.Forms.Label ITNLabel;
        private System.Windows.Forms.Label OwnershipLabel;
        private System.Windows.Forms.ComboBox ownershipComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.TextBox addressTextBox;
        public System.Windows.Forms.MaskedTextBox phoneMaskedTextBox;
        private System.Windows.Forms.ComboBox contactComboBox;
        private System.Windows.Forms.Label ContactLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button OKButton;
    }
}