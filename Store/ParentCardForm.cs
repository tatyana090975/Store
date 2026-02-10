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
    public partial class ParentCardForm : Form
    {
        public virtual string TableName { get; set; } = "";
        public int ID = 0;
        protected List<(string column, object value)> CardData { get; set; } = new List<(string column, object value)>();
        public ParentCardForm()
        {
            InitializeComponent();
        }
        
        public ParentCardForm(int id)
        {
            InitializeComponent();            
            LoadTestForm(id, TableName);

        }
        protected virtual DataTable LoadTestForm(int a, string tableName)
        {
            int cardId = a;
            string table = TableName;
            DataTable dataTable = DBQueries.LoadParentCard(cardId, table);
            return dataTable;
        }

        //заполнение CardData
        protected virtual void FillCardData()
        {
            // Очищаем список
            CardData.Clear();

            // Добавляем основное поле (минимум 1 параметр)
            CardData.Add(("", nameTextBox.Text));            
        }
        
        //Сохранение карточки в бд
        protected virtual void OKButton_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                string name = nameTextBox.Text;
                //string secondname = secondnameTextBox.Text;
                //string surname = surnameTextBox.Text;
                CardData.Add(("", name));
                //CardData.Add(("secondname", secondname));
                //CardData.Add(("surname", surname));

                if (name == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    string res = DBQueries.SaveCard(TableName, CardData.ToArray());
                    MessageBox.Show(res);
                    this.Close();
                }
            }
            else
            {
                string name = nameTextBox.Text;
                //string secondname = secondnameTextBox.Text;
                //string surname = surnameTextBox.Text;
                CardData.Add(("", name));
                //CardData.Add(("secondname", secondname));
                //CardData.Add(("surname", surname));

                if (name == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    string res = DBQueries.UpdateCard(TableName, ID, CardData.ToArray());
                    MessageBox.Show(res);
                    this.Close();
                }
            }

        }       

        //Кнопка Отмена
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
    }
}
