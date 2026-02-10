using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class DeliveryCardForm : Store.ParentCardForm
    {
        public override string TableName { get; set; } = "delivery";
        public DeliveryCardForm()
        {
            name.Text = "Адрес доставки";
            InitializeComponent();
        }
        public DeliveryCardForm(int id)
        {
            name.Text = "Адрес доставки";
            InitializeComponent();
            DataTable table = LoadTestForm(id, TableName);
            string value = table.Rows[0]["delivery"].ToString();
            nameTextBox.Text = value;
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
            }
        }

    }
}
