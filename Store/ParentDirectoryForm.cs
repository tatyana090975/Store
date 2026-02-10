using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class ParentDirectoryForm : Form
    {
        int id = 0;
        public virtual string TableName { get; set; } = "";
        public ParentDirectoryForm()
        {
            InitializeComponent();            
        }

        //Запролнение grid данными из таблицы 
        public virtual void ParentDirectoryFormFill()
        {
            dataGridViewParentDirectory.DataSource = DBQueries.LoadGridInForm(TableName);
        }
        
        //Кнопка "Создать запись"
        public virtual void createRecordButton_Click(object sender, EventArgs e)
        {
            ParentCardForm parentCardForm = new ParentCardForm();
            parentCardForm.Show();

        }
        //Кнопка "Обновить"
        public void buttonRefresh_Click(object sender, EventArgs e)
        {
            ParentDirectoryFormFill();
        }
        //Кнопка "Выход"
        public void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Кнопка "Удалить запись"        
        protected virtual void deleteRecordButton_Click(object sender, EventArgs e)
        {
            int currentRow = (int)dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            int rowIndex = dataGridViewParentDirectory.CurrentRow.Index;
            string res = "";
            //удаление записи из базы данных
            res = DBQueries.DeleteRow(TableName, currentRow);
            if (res == "Запись успешно удалена.")
            {
                dataGridViewParentDirectory.Rows.Remove(dataGridViewParentDirectory.Rows[rowIndex]);
                MessageBox.Show(res);
            }
            else
            {
                MessageBox.Show(res);
            }
        }
        //Кнопка Открыть карточку
        protected virtual void openButton_Click(object sender, EventArgs e)
        {
            var idd = dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            int currenRow = (int)idd;
            ParentCardForm parentCardForm = new ParentCardForm(currenRow);
            parentCardForm.Show();
        }
        
    }
}
