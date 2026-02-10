using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class PersonCardForm : Store.ParentCardForm
    {
        public override string TableName { get; set; } = "person";
        public int ID = 0;
        public PersonCardForm()
        {
            name.Text = "Имя";
            InitializeComponent();
        }
        public PersonCardForm(int id)
        {
            ID = id;
            name.Text = "Имя";
            InitializeComponent();
            DataTable table = LoadTestForm(id, TableName);
            string value = table.Rows[0]["name"].ToString();
            nameTextBox.Text = value;
            string value1 = table.Rows[0]["secondname"].ToString();
            secondnameTextBox.Text = value1;
            string value2 = table.Rows[0]["surname"].ToString();
            surnameTextBox.Text = value2;
        }

        protected override DataTable LoadTestForm(int a, string tableName)
        {
            int cardId = a;
            string table = TableName;
            DataTable dataTable = DBQueries.LoadParentCard(cardId, table);
            return dataTable;
        }
        //Переопределение кнопки ОК
        protected override void OKButton_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                string name = nameTextBox.Text;
                string secondname = secondnameTextBox.Text;
                string surname = surnameTextBox.Text;
                CardData.Add(("name", name));
                CardData.Add(("secondname", secondname));
                CardData.Add(("surname", surname));

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
                string secondname = secondnameTextBox.Text;
                string surname = surnameTextBox.Text;
                CardData.Add(("name", name));
                CardData.Add(("secondname", secondname));
                CardData.Add(("surname", surname));

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
    }
}
