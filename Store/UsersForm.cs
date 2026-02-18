using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class UsersForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "users";
        public UsersForm()
        {
            InitializeComponent();            
            ParentDirectoryFormFill();
        }
        //Запролнение grid данными из таблицы 
        public override void ParentDirectoryFormFill()
        {
            dataGridViewParentDirectory.DataSource = DBQueries.LoadGridUsersForm();
        }
        //кнопка "Создать запись"
        public override void createRecordButton_Click(object sender, EventArgs e)
        {
            UsersCardForm usersCardForm = new UsersCardForm();
            usersCardForm.Show();

        }
        //Кнопка Открыть карточку
        public override void openButton_Click(object sender, EventArgs e)
        {
            int currenRow = (int)dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            UsersCardForm usersCardForm = new UsersCardForm(currenRow);
            usersCardForm.Show();
        }
    }
}
