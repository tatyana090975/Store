namespace Store
{
    partial class PersonCardForm
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
            this.secondnameLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.secondnameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.surnameTextBox);
            this.panel1.Controls.Add(this.secondnameTextBox);
            this.panel1.Controls.Add(this.surnameLabel);
            this.panel1.Controls.Add(this.secondnameLabel);
            this.panel1.Controls.SetChildIndex(this.nameTextBox, 0);
            this.panel1.Controls.SetChildIndex(this.name, 0);
            this.panel1.Controls.SetChildIndex(this.secondnameLabel, 0);
            this.panel1.Controls.SetChildIndex(this.surnameLabel, 0);
            this.panel1.Controls.SetChildIndex(this.secondnameTextBox, 0);
            this.panel1.Controls.SetChildIndex(this.surnameTextBox, 0);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(425, 62);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(336, 104);
            this.nameTextBox.Size = new System.Drawing.Size(332, 30);
            // 
            // secondnameLabel
            // 
            this.secondnameLabel.AutoSize = true;
            this.secondnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondnameLabel.Location = new System.Drawing.Point(447, 153);
            this.secondnameLabel.Name = "secondnameLabel";
            this.secondnameLabel.Size = new System.Drawing.Size(104, 25);
            this.secondnameLabel.TabIndex = 2;
            this.secondnameLabel.Text = "Отчество";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.surnameLabel.Location = new System.Drawing.Point(448, 246);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(103, 25);
            this.surnameLabel.TabIndex = 3;
            this.surnameLabel.Text = "Фамилия";
            // 
            // secondnameTextBox
            // 
            this.secondnameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondnameTextBox.Location = new System.Drawing.Point(336, 194);
            this.secondnameTextBox.Name = "secondnameTextBox";
            this.secondnameTextBox.Size = new System.Drawing.Size(332, 30);
            this.secondnameTextBox.TabIndex = 4;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.surnameTextBox.Location = new System.Drawing.Point(336, 291);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(332, 30);
            this.surnameTextBox.TabIndex = 5;
            // 
            // PersonCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1083, 476);
            this.Name = "PersonCardForm";
            this.Text = "Карточка персоны";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox secondnameTextBox;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label secondnameLabel;
    }
}
