using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class OwnershipForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "ownership";
        public OwnershipForm()
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
            OwnershipCardForm ownershipCardForm = new OwnershipCardForm();
            ownershipCardForm.Show();
        }
        //Кнопка Открыть карточку
        public override void openButton_Click(object sender, EventArgs e)
        {
            int currenRow = (int)dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            OwnershipCardForm ownershipCardForm = new OwnershipCardForm(currenRow);
            ownershipCardForm.Show();
        }
    }
}
