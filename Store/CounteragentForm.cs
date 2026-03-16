using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class CounteragentForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "counteragent";
        public CounteragentForm()
        {
            InitializeComponent();
            ParentDirectoryFormFill();
        }
        //Запролнение grid данными из таблицы 
        public override void ParentDirectoryFormFill()
        {
            dataGridViewParentDirectory.DataSource = DBQueries.LoadGridCounteragentForm();
        }
        //кнопка "Создать запись"
        public override void createRecordButton_Click(object sender, EventArgs e)
        {
            CounteragentCardForm counteragentCardForm = new CounteragentCardForm();
            counteragentCardForm.Show();
        }
        //
        public override void openButton_Click(object sender, EventArgs e)
        {
            int currenRow = (int)dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            CounteragentCardForm counteragentCardForm = new CounteragentCardForm(currenRow);
            counteragentCardForm.Show();
        }
    }
}
