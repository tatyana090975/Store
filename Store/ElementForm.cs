using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class ElementForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "element";
        public ElementForm()
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
            ElementCardForm elementCardForm = new ElementCardForm();
            elementCardForm.Show();
        }
        //Кнопка Открыть карточку
        public override void openButton_Click(object sender, EventArgs e)
        {
            int currenRow = (int)dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            ElementCardForm elementCardForm = new ElementCardForm(currenRow);
            elementCardForm.Show();
        }
    }
}
