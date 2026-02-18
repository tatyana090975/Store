namespace Store
{
    partial class DeliveryCardForm
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
            this.phoneLabel = new System.Windows.Forms.Label();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.maskedTextBox);
            this.panel1.Controls.Add(this.phoneLabel);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Controls.SetChildIndex(this.nameTextBox, 0);
            this.panel1.Controls.SetChildIndex(this.name, 0);
            this.panel1.Controls.SetChildIndex(this.phoneLabel, 0);
            this.panel1.Controls.SetChildIndex(this.maskedTextBox, 0);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(425, 109);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(182, 138);
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Size = new System.Drawing.Size(690, 79);
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneLabel.Location = new System.Drawing.Point(445, 237);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(99, 25);
            this.phoneLabel.TabIndex = 2;
            this.phoneLabel.Text = "Телефон";
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Location = new System.Drawing.Point(335, 278);
            this.maskedTextBox.Mask = "+7 (999) 000-0000";
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(334, 27);
            this.maskedTextBox.TabIndex = 4;
            // 
            // DeliveryCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1083, 476);
            this.Name = "DeliveryCardForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
    }
}
