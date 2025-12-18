namespace Store
{
    partial class EmployeCardForm
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
            this.personLabel = new System.Windows.Forms.Label();
            this.personComboBox = new System.Windows.Forms.ComboBox();
            this.positionLabel = new System.Windows.Forms.Label();
            this.positionComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.positionComboBox);
            this.panel1.Controls.Add(this.positionLabel);
            this.panel1.Controls.Add(this.personComboBox);
            this.panel1.Controls.Add(this.personLabel);
            this.panel1.Controls.SetChildIndex(this.nameTextBox, 0);
            this.panel1.Controls.SetChildIndex(this.name, 0);
            this.panel1.Controls.SetChildIndex(this.personLabel, 0);
            this.panel1.Controls.SetChildIndex(this.personComboBox, 0);
            this.panel1.Controls.SetChildIndex(this.positionLabel, 0);
            this.panel1.Controls.SetChildIndex(this.positionComboBox, 0);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(370, 49);
            this.name.Visible = false;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(179, 92);
            this.nameTextBox.Visible = false;
            // 
            // personLabel
            // 
            this.personLabel.AutoSize = true;
            this.personLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.personLabel.Location = new System.Drawing.Point(467, 49);
            this.personLabel.Name = "personLabel";
            this.personLabel.Size = new System.Drawing.Size(98, 25);
            this.personLabel.TabIndex = 2;
            this.personLabel.Text = "Персона*";
            // 
            // personComboBox
            // 
            this.personComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.personComboBox.FormattingEnabled = true;
            this.personComboBox.Location = new System.Drawing.Point(216, 92);
            this.personComboBox.Name = "personComboBox";
            this.personComboBox.Size = new System.Drawing.Size(611, 33);
            this.personComboBox.TabIndex = 3;
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.positionLabel.Location = new System.Drawing.Point(456, 178);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(131, 25);
            this.positionLabel.TabIndex = 4;
            this.positionLabel.Text = "Должность*";
            // 
            // positionComboBox
            // 
            this.positionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.positionComboBox.FormattingEnabled = true;
            this.positionComboBox.Location = new System.Drawing.Point(216, 224);
            this.positionComboBox.Name = "positionComboBox";
            this.positionComboBox.Size = new System.Drawing.Size(611, 33);
            this.positionComboBox.TabIndex = 5;
            // 
            // EmployeCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1083, 476);
            this.Name = "EmployeCardForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label personLabel;
        private System.Windows.Forms.ComboBox positionComboBox;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.ComboBox personComboBox;
    }
}
