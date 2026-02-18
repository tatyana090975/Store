namespace Store
{
    partial class TradeMarginCardForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.productLabel = new System.Windows.Forms.Label();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tradeMarginTextBox = new System.Windows.Forms.TextBox();
            this.statusCheckBox = new System.Windows.Forms.CheckBox();
            this.cardCloseLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cardCloseLabel);
            this.panel1.Controls.Add(this.statusCheckBox);
            this.panel1.Controls.Add(this.tradeMarginTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.productComboBox);
            this.panel1.Controls.Add(this.productLabel);
            this.panel1.Controls.SetChildIndex(this.nameTextBox, 0);
            this.panel1.Controls.SetChildIndex(this.name, 0);
            this.panel1.Controls.SetChildIndex(this.productLabel, 0);
            this.panel1.Controls.SetChildIndex(this.productComboBox, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.tradeMarginTextBox, 0);
            this.panel1.Controls.SetChildIndex(this.statusCheckBox, 0);
            this.panel1.Controls.SetChildIndex(this.cardCloseLabel, 0);
            // 
            // name
            // 
            this.name.Visible = false;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Visible = false;
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productLabel.Location = new System.Drawing.Point(365, 60);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(226, 25);
            this.productLabel.TabIndex = 2;
            this.productLabel.Text = "Наименование товара*";
            // 
            // productComboBox
            // 
            this.productComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(148, 105);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(720, 33);
            this.productComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(396, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Тоговая наценка*";
            // 
            // tradeMarginTextBox
            // 
            this.tradeMarginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tradeMarginTextBox.Location = new System.Drawing.Point(412, 227);
            this.tradeMarginTextBox.Name = "tradeMarginTextBox";
            this.tradeMarginTextBox.Size = new System.Drawing.Size(148, 30);
            this.tradeMarginTextBox.TabIndex = 5;
            // 
            // statusCheckBox
            // 
            this.statusCheckBox.AutoSize = true;
            this.statusCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusCheckBox.Location = new System.Drawing.Point(597, 315);
            this.statusCheckBox.Name = "statusCheckBox";
            this.statusCheckBox.Size = new System.Drawing.Size(18, 17);
            this.statusCheckBox.TabIndex = 6;
            this.statusCheckBox.UseVisualStyleBackColor = true;
            // 
            // cardCloseLabel
            // 
            this.cardCloseLabel.AutoSize = true;
            this.cardCloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cardCloseLabel.Location = new System.Drawing.Point(310, 310);
            this.cardCloseLabel.Name = "cardCloseLabel";
            this.cardCloseLabel.Size = new System.Drawing.Size(232, 25);
            this.cardCloseLabel.TabIndex = 7;
            this.cardCloseLabel.Text = "Карточка действующая";
            // 
            // TradeMarginCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1083, 476);
            this.Name = "TradeMarginCardForm";
            this.Text = "Торговая наценка";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cardCloseLabel;
        private System.Windows.Forms.CheckBox statusCheckBox;
        private System.Windows.Forms.TextBox tradeMarginTextBox;
    }
}
