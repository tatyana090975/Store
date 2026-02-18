using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class MaterialForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "material";
        public MaterialForm()
        {
            InitializeComponent();
            ParentDirectoryFormFill();
        }
        //Запролнение grid данными из таблицы 
        public override void ParentDirectoryFormFill()
        {
            dataGridViewParentDirectory.DataSource = DBQueries.LoadGridInForm(TableName);
        }
        //кнопка "Создать запись"
        public override void createRecordButton_Click(object sender, EventArgs e)
        {
            MaterialCardForm materialCardForm = new MaterialCardForm();
            materialCardForm.Show();

        }
        //Кнопка Открыть карточку
        public override void openButton_Click(object sender, EventArgs e)
        {
            int currenRow = (int)dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            MaterialCardForm materialCardForm = new MaterialCardForm(currenRow);
            materialCardForm.Show();
        }
    }
}
