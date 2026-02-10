using Google.Protobuf.Compiler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Store
{
    public partial class TradeMarginCardForm : Store.ParentCardForm
    {
        private TradeMarginCardForm tradeMarginCardForm;
        public override string TableName { get; set; } = "trademargintable";
        public TradeMarginCardForm()
        {
            InitializeComponent();
            FillProductComboBox();
        }
        public TradeMarginCardForm(int id)
        {            
            InitializeComponent();
            DataTable table = LoadTestForm(id, TableName);
            string value = table.Rows[0]["percent"].ToString();
            tradeMarginTextBox.Text = value;
            bool value1 = (bool)table.Rows[0]["status"];
            statusCheckBox.Checked = value1;
            string productCB = "";
            DataTable table1 = DBQueries.LoadProduct(id, "trademargintable");
            foreach (DataRow row in table1.Rows)
            {
                string product = row["product"].ToString();
                string color = row["color"].ToString();
                string length = row["length"].ToString();
                string width = row["width"].ToString();
                string height = row["height"].ToString();
                // Формируем строку для отображения
                productCB = $"{product} {color} {length} {width} {height}";
            }
            productComboBox.Text = productCB;
        }
        protected override DataTable LoadTestForm(int a, string tableName)
        {
            int cardId = a;
            string table = TableName;
            DataTable dataTable = DBQueries.LoadParentCard(cardId, table);
            return dataTable;
        }

        //Заполнение данными productComboBox
        private void FillProductComboBox()
        {
            DataTable table = DBQueries.LoadGridProductForm();
            productComboBox.Items.Clear();
            productComboBox.Items.Add("--Выберите товар--");
            //Заполняем данными
            foreach (DataRow row in table.Rows)
            {
                string id = row["product_id"].ToString();
                string product = row["product"].ToString();
                string color = row["color"].ToString();
                string length = row["length"].ToString();
                string width = row["width"].ToString();
                string height = row["height"].ToString();


                // Формируем строку для отображения
                string displayText = $"{product} {color} {length} {width} {height}";

                // Сохраняем ID в свойстве Tag
                productComboBox.Items.Add(new
                {
                    Text = displayText,
                    Id = id
                });
                // Настраиваем отображение
                productComboBox.DisplayMember = "Text";
                productComboBox.ValueMember = "Id";
                productComboBox.SelectedIndex = 0;
            }
        }
        //Переопределение кнопки ОК
        protected override void OKButton_Click(object sender, EventArgs e)
        {
            string product = productComboBox.Text;
            string tradeMargim = tradeMarginTextBox.Text;

            string selectedProductId = "0";
            if (productComboBox.SelectedItem != null && productComboBox.SelectedIndex > 0)
            {
                var selectedItem = (dynamic)productComboBox.SelectedItem;
                selectedProductId = selectedItem.Id;
            }
            int product_id = int.Parse(selectedProductId);

            double persent = 0;
            string tm = tradeMarginTextBox.Text;

            if (Regex.IsMatch(tm, @"^[0-9]+([.,][0-9]+)?$"))
            {
                if (tm.Contains(".")) { tm = tm.Replace(".", ","); }
                persent = double.Parse(tm);
            } 
            else
            {
                MessageBox.Show("Укажите только цифры!"); return;
            }

            CardData.Add(("product_id", product_id));
            CardData.Add(("percent", persent));
            if (product_id < 1 || persent < 0)
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
