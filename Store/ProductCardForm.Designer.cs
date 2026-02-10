namespace Store
{
    partial class ProductCardForm
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
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.lenghtLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.leghtTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.heightTextBox);
            this.panel1.Controls.Add(this.widthTextBox);
            this.panel1.Controls.Add(this.leghtTextBox);
            this.panel1.Controls.Add(this.heightLabel);
            this.panel1.Controls.Add(this.widthLabel);
            this.panel1.Controls.Add(this.lenghtLabel);
            this.panel1.Controls.Add(this.colorComboBox);
            this.panel1.Controls.Add(this.colorLabel);
            this.panel1.Controls.SetChildIndex(this.nameTextBox, 0);
            this.panel1.Controls.SetChildIndex(this.name, 0);
            this.panel1.Controls.SetChildIndex(this.colorLabel, 0);
            this.panel1.Controls.SetChildIndex(this.colorComboBox, 0);
            this.panel1.Controls.SetChildIndex(this.lenghtLabel, 0);
            this.panel1.Controls.SetChildIndex(this.widthLabel, 0);
            this.panel1.Controls.SetChildIndex(this.heightLabel, 0);
            this.panel1.Controls.SetChildIndex(this.leghtTextBox, 0);
            this.panel1.Controls.SetChildIndex(this.widthTextBox, 0);
            this.panel1.Controls.SetChildIndex(this.heightTextBox, 0);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(405, 31);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(234, 60);
            this.nameTextBox.Size = new System.Drawing.Size(548, 30);
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colorLabel.Location = new System.Drawing.Point(451, 94);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(67, 25);
            this.colorLabel.TabIndex = 2;
            this.colorLabel.Text = "Цвет*";
            // 
            // colorComboBox
            // 
            this.colorComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Location = new System.Drawing.Point(334, 122);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(310, 33);
            this.colorComboBox.TabIndex = 3;
            // 
            // lenghtLabel
            // 
            this.lenghtLabel.AutoSize = true;
            this.lenghtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lenghtLabel.Location = new System.Drawing.Point(451, 158);
            this.lenghtLabel.Name = "lenghtLabel";
            this.lenghtLabel.Size = new System.Drawing.Size(81, 25);
            this.lenghtLabel.TabIndex = 4;
            this.lenghtLabel.Text = "Длина*";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.widthLabel.Location = new System.Drawing.Point(436, 219);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(96, 25);
            this.widthLabel.TabIndex = 5;
            this.widthLabel.Text = "Глубина*";
            this.widthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heightLabel.Location = new System.Drawing.Point(436, 280);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(89, 25);
            this.heightLabel.TabIndex = 6;
            this.heightLabel.Text = "Высота*";
            // 
            // leghtTextBox
            // 
            this.leghtTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leghtTextBox.Location = new System.Drawing.Point(334, 186);
            this.leghtTextBox.Name = "leghtTextBox";
            this.leghtTextBox.Size = new System.Drawing.Size(310, 30);
            this.leghtTextBox.TabIndex = 7;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.widthTextBox.Location = new System.Drawing.Point(334, 247);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(310, 30);
            this.widthTextBox.TabIndex = 8;
            // 
            // heightTextBox
            // 
            this.heightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heightTextBox.Location = new System.Drawing.Point(334, 308);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(310, 30);
            this.heightTextBox.TabIndex = 9;
            // 
            // ProductCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1083, 476);
            this.Name = "ProductCardForm";
            this.Text = "Карточка товара";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label lenghtLabel;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.TextBox leghtTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
    }
}
