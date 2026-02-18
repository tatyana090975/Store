namespace Store
{
    partial class ProductMaterialCardForm
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
            this.materialLabel = new System.Windows.Forms.Label();
            this.elementLabel = new System.Windows.Forms.Label();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.materialComboBox = new System.Windows.Forms.ComboBox();
            this.elementComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.elementComboBox);
            this.panel1.Controls.Add(this.materialComboBox);
            this.panel1.Controls.Add(this.productComboBox);
            this.panel1.Controls.Add(this.elementLabel);
            this.panel1.Controls.Add(this.materialLabel);
            this.panel1.Controls.Add(this.productLabel);
            this.panel1.Controls.SetChildIndex(this.nameTextBox, 0);
            this.panel1.Controls.SetChildIndex(this.name, 0);
            this.panel1.Controls.SetChildIndex(this.productLabel, 0);
            this.panel1.Controls.SetChildIndex(this.materialLabel, 0);
            this.panel1.Controls.SetChildIndex(this.elementLabel, 0);
            this.panel1.Controls.SetChildIndex(this.productComboBox, 0);
            this.panel1.Controls.SetChildIndex(this.materialComboBox, 0);
            this.panel1.Controls.SetChildIndex(this.elementComboBox, 0);
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
            this.productLabel.Location = new System.Drawing.Point(367, 19);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(226, 25);
            this.productLabel.TabIndex = 2;
            this.productLabel.Text = "Наименование товара*";
            // 
            // materialLabel
            // 
            this.materialLabel.AutoSize = true;
            this.materialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.materialLabel.Location = new System.Drawing.Point(354, 126);
            this.materialLabel.Name = "materialLabel";
            this.materialLabel.Size = new System.Drawing.Size(266, 25);
            this.materialLabel.TabIndex = 3;
            this.materialLabel.Text = "Наименование материала*";
            // 
            // elementLabel
            // 
            this.elementLabel.AutoSize = true;
            this.elementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elementLabel.Location = new System.Drawing.Point(354, 231);
            this.elementLabel.Name = "elementLabel";
            this.elementLabel.Size = new System.Drawing.Size(257, 25);
            this.elementLabel.TabIndex = 4;
            this.elementLabel.Text = "Наименование элемента*";
            // 
            // productComboBox
            // 
            this.productComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(162, 68);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(662, 33);
            this.productComboBox.TabIndex = 5;
            // 
            // materialComboBox
            // 
            this.materialComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.materialComboBox.FormattingEnabled = true;
            this.materialComboBox.Location = new System.Drawing.Point(318, 172);
            this.materialComboBox.Name = "materialComboBox";
            this.materialComboBox.Size = new System.Drawing.Size(350, 33);
            this.materialComboBox.TabIndex = 6;
            // 
            // elementComboBox
            // 
            this.elementComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elementComboBox.FormattingEnabled = true;
            this.elementComboBox.Location = new System.Drawing.Point(318, 292);
            this.elementComboBox.Name = "elementComboBox";
            this.elementComboBox.Size = new System.Drawing.Size(350, 33);
            this.elementComboBox.TabIndex = 7;
            // 
            // ProductMaterialCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1083, 476);
            this.Name = "ProductMaterialCardForm";
            this.Text = "Товар-материал";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.Label materialLabel;
        private System.Windows.Forms.ComboBox elementComboBox;
        private System.Windows.Forms.ComboBox materialComboBox;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.Label elementLabel;
    }
}
