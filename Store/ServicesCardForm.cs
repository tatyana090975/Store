using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class ServicesCardForm : Store.ParentCardForm
    {
        public override string TableName { get; set; } = "services";
        public ServicesCardForm()
        {
            name.Text = "Наименование услуги";
            InitializeComponent();
        }
        //Переопределение кнопки ОК
        protected override void OKButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string pr = priceTextBox.Text;
            if (pr.Contains(".")) {pr = pr.Replace(".", ","); }
            double price = double.Parse(pr);
                        
            CardData.Add(("services", name));
            CardData.Add(("price", price));

            if (name == "" || priceTextBox.Text == "")
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
