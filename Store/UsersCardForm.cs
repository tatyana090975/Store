using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
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
        private int formId;
        public override string TableName { get; set; } = "users";
        public int ID = 0;
        public UsersCardForm()
        {
            name.Text = "Логин*";
            InitializeComponent();
            FillPersonComboBox();
        }
        //Конструктор с ID
        public UsersCardForm(int id)
        {
            ID = id;
            //formId = id;
            string person = "";
            name.Text = "Логин*";
            InitializeComponent();
            DataTable table = LoadTestForm(id, TableName);
            string value = table.Rows[0]["login"].ToString();
            nameTextBox.Text = value;
            string value1 = table.Rows[0]["password"].ToString();
            passwordTextBox.Text = value1;
            DataTable table1 = DBQueries.LoadParentCard(ID, "person");
            foreach (DataRow row in table1.Rows)
            {
                string idp = row["person_id"].ToString();
                string name = row["name"].ToString();
                string secondname = row["secondname"].ToString();
                string surname = row["surname"].ToString();

                // Формируем строку для отображения
                person = $"{surname} {name} {secondname}";
            }
            personComboBox.Text = person;
        }
        //Проверка id на недопустимые значения
        private void SetSelectedPerson(string personId)
        {
            if (string.IsNullOrEmpty(personId) || personId == "0")
            {
                personComboBox.SelectedIndex = 0;
                return;
            }            
        }
        //Загрузка данных выбранной карточки в DataTable
        protected override DataTable LoadTestForm(int a, string tableName)
        {
            int cardId = a;
            string table = TableName;
            DataTable dataTable = DBQueries.LoadParentCard(cardId, table);
            return dataTable;
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
          
            if (ID == 0)
            {
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
            else
            {                
                CardData.Add(("users_id", ID));
                CardData.Add(("login", login));
                CardData.Add(("password", password));

                if (login == "" || password == "" || ID < 1)
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
