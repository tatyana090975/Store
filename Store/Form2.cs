using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{    
    public partial class Form2 : Form
    {
        public string TableName { get; set; } = "counteragent";
        public int ID = 0;
        protected List<(string column, object value)> CardData { get; set; } = new List<(string column, object value)>();
        public Form2()
        {
            InitializeComponent();
            FillOwnershipComboBox();
            FillContactComboBox();
        }
        public Form2(int id)
        {
            ID = id;
            string ownership = "";
            string contact = "";
            InitializeComponent();
            FillOwnershipComboBox();
            FillContactComboBox();

            DataTable table = LoadTestForm(id, TableName);
            string value = table.Rows[0]["name"].ToString();
            nameTextBox.Text = value;
            string value1 = table.Rows[0]["address"].ToString();
            addressTextBox.Text = value1;
            string value2 = table.Rows[0]["phone"].ToString();
            phoneMaskedTextBox.Text = value2;
            string value3 = table.Rows[0]["itn"].ToString();
            ITNTextBox.Text = value3;

            int ido = (int)table.Rows[0]["ownership_id"];
            int idc = (int)table.Rows[0]["person_id"];

            DataTable table2 = DBQueries.LoadParentCard(idc, "person");
            foreach (DataRow row in table2.Rows)
            {
                string idc1 = row["person_id"].ToString();
                string name1 = row["name"].ToString();
                string name2 = row["secondname"].ToString();
                string name3 = row["surname"].ToString();


                //Формируем строку для отображения
                contact = $"{name3} {name1} {name2}";
            }
            contactComboBox.Text = contact;

            DataTable table1 = DBQueries.LoadParentCard(ido, "ownership");
            foreach (DataRow row in table1.Rows)
            {
                string ido1 = row["ownership_id"].ToString();
                string ownership1 = row["ownership"].ToString();

                //Формируем строку для отображения
                ownership = $"{ownership1}";
            }
            ownershipComboBox.Text = ownership;
            
        }
        protected virtual DataTable LoadTestForm(int a, string tableName)
        {
            int cardId = a;
            string table = TableName;
            DataTable dataTable = DBQueries.LoadParentCard(cardId, table);
            return dataTable;
        }
        //Заполнение данными ownershipComboBox
        private void FillOwnershipComboBox()
        {
            DataTable table = DBQueries.LoadDateInComboBox("ownership");
            ownershipComboBox.Items.Clear();
            ownershipComboBox.Items.Add("--Выберите форму собственности--");
            //Заполняем данными
            foreach (DataRow row in table.Rows)
            {
                string id = row["ownership_id"].ToString();
                string ownership = row["ownership"].ToString();

                // Формируем строку для отображения
                string displayText = $"{ownership}";

                // Сохраняем ID в свойстве Tag
                ownershipComboBox.Items.Add(new
                {
                    Text = displayText,
                    Id = id
                });
                // Настраиваем отображение
                ownershipComboBox.DisplayMember = "Text";
                ownershipComboBox.ValueMember = "Id";
                ownershipComboBox.SelectedIndex = 0;
            }
        }
        
        //Заполнение данными contactComboBox
        private void FillContactComboBox()
        {
            DataTable table = DBQueries.LoadDateInComboBox("person");
            contactComboBox.Items.Clear();
            contactComboBox.Items.Add("--Выберите персону--");
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
                contactComboBox.Items.Add(new
                {
                    Text = displayText,
                    Id = id
                });
                // Настраиваем отображение
                contactComboBox.DisplayMember = "Text";
                contactComboBox.ValueMember = "Id";
                contactComboBox.SelectedIndex = 0;
            }
        }
        //заполнение CardData
        protected virtual void FillCardData()
        {
            // Очищаем список
            CardData.Clear();

            // Добавляем основное поле (минимум 1 параметр)
            CardData.Add(("", nameTextBox.Text));
        }

        //Переопределение кнопки ОК
        protected void OKButton_Click(object sender, EventArgs e)
        {
            string ownership = ownershipComboBox.Text;
            string itn = ITNTextBox.Text;
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string phone = phoneMaskedTextBox.Text;
            string contact = contactComboBox.Text;

            if (Regex.IsMatch(itn, @"^\d+$") == false)
            {
                MessageBox.Show("ИНН должен содержать только цифры!");
                return;
            }

            if (itn.Length != 10)
            {
                if (itn.Length != 12)
                {
                    MessageBox.Show("ИНН может содержать только 10 или 12 цифр!");
                    return;
                }                    
            }

                string selectedOwnershipId = "0";
            if (ownershipComboBox.SelectedItem != null && ownershipComboBox.SelectedIndex > 0)
            {
                var selectedItem = (dynamic)ownershipComboBox.SelectedItem;
                selectedOwnershipId = selectedItem.Id;
            }
            int ownershipId = int.Parse(selectedOwnershipId);

            string selectedPersonId = "0";
            if (contactComboBox.SelectedItem != null && contactComboBox.SelectedIndex > 0)
            {
                var selectedItem = (dynamic)contactComboBox.SelectedItem;
                selectedPersonId = selectedItem.Id;
            }
            int personId = int.Parse(selectedPersonId);
            //Очистка маски телефона от лишних символов
            phone = Regex.Replace(phone, @"[^\d]", "");

            if (ID == 0)
            {
                CardData.Add(("ownership_id", ownershipId));
                CardData.Add(("name", name));
                CardData.Add(("address", address));
                CardData.Add(("phone", phone));
                CardData.Add(("person_id", personId));
                CardData.Add(("ITN", itn));
                if (ownershipId < 1 || name == "" || address == "" || phone == "" || itn == "" || personId < 1)
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
                CardData.Add(("ownership_id", ownershipId));
                CardData.Add(("name", name));
                CardData.Add(("address", address));
                CardData.Add(("phone", phone));
                CardData.Add(("person_id", personId));
                CardData.Add(("ITN", itn));
                if (ownershipId < 1 || name == "" || address == "" || phone == "" || itn == "" || personId < 1)
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
        //Кнопка "Отмена"
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
