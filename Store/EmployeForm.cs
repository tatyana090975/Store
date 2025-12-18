using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class EmployeForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "employe";
        public EmployeForm()
        {
            InitializeComponent();
            ParentDirectoryFormFill();
        }
        //Запролнение grid данными из таблицы 
        public override void ParentDirectoryFormFill()
        {
            dataGridViewParentDirectory.DataSource = DBQueries.LoadGridEmployeForm();
        }
        //кнопка "Создать запись"
        public override void createRecordButton_Click(object sender, EventArgs e)
        {
            EmployeCardForm employeCardForm = new EmployeCardForm();
            employeCardForm.Show();

        }
    }
}
