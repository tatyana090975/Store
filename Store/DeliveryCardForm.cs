using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Store
{
    public partial class DeliveryCardForm : Store.ParentCardForm
    {
        public override string TableName { get; set; } = "delivery";
        int ID = 0;
        public DeliveryCardForm()
        {
            name.Text = "Адрес доставки";
            //phoneTextBox. = "+7 (999) 000-00-00";
            InitializeComponent();
        }
        public DeliveryCardForm(int id)
        {
            ID = id;
            name.Text = "Адрес доставки";
            InitializeComponent();
            DataTable table = LoadTestForm(id, TableName);
            string value = table.Rows[0]["address"].ToString();
            nameTextBox.Text = value;
            string value1 = table.Rows[0]["phone"].ToString();
            maskedTextBox.Text = value1;
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
            string name = nameTextBox.Text;
            string phone = maskedTextBox.Text;
            //Очистка маски телефона от лишних символов
            phone = Regex.Replace(phone, @"[^\d]", "");

            if (ID == 0)
            {
                CardData.Add(("address", name));
                CardData.Add(("phone", phone));
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
                CardData.Add(("address", name));
                CardData.Add(("phone", phone));
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
            /*
            string name = nameTextBox.Text;
            string phone = phoneTextBox.Text;
            CardData.Add(("address", name));
            CardData.Add(("phone", phone));
            if (name == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                string res = DBQueries.SaveCard(TableName, CardData.ToArray());
                MessageBox.Show(res);
                this.Close();
            }*/
        }

    }
}
