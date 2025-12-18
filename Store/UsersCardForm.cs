using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class UsersCardForm : Store.ParentCardForm
    {
        public override string TableName { get; set; } = "users";
        public UsersCardForm()
        {
            name.Text = "Логин*";
            InitializeComponent();
            FillPersonComboBox();
        }
        //Заполнение данными personComboBox
        private void FillPersonComboBox()
        {
            DataTable table = DBQueries.LoadDateInComboBox("person");
            personComboBox.Items.Clear();
            personComboBox.Items.Add("--Выберите персону--");
            //Заполняем данными
            foreach (DataRow row in table.Rows)
            {
                string id = row["person_id"].ToString();
                string name = row["name"].ToString();
                string secondname = row["secondname"].ToString();
                string surname = row["surname"].ToString();

                // Формируем строку для отображения
                string displayText = $"{surname} {name} {secondname}";

                // Сохраняем ID в свойстве Tag
                personComboBox.Items.Add(new
                {
                    Text = displayText,
                    Id = id
                });
                // Настраиваем отображение
                personComboBox.DisplayMember = "Text";
                personComboBox.ValueMember = "Id";
                personComboBox.SelectedIndex = 0;
            }
        }        
        
        //Переопределение кнопки ОК
        protected override void OKButton_Click(object sender, EventArgs e)
        {
            string login = nameTextBox.Text;
            string password = passwordTextBox.Text;
            string person = personComboBox.Text;

            string selectedPersonId = "0";
            if (personComboBox.SelectedItem != null && personComboBox.SelectedIndex > 0)
            {
                var selectedItem = (dynamic)personComboBox.SelectedItem;
                selectedPersonId = selectedItem.Id;
            }

            int users_id = int.Parse(selectedPersonId);
            CardData.Add(("users_id", users_id));
            CardData.Add(("login", login));
            CardData.Add(("password", password));
            

            if (login == "" || password == "" || users_id < 1)
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

    }
}
