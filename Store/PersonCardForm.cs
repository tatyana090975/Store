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
        public PersonCardForm()
        {
            name.Text = "Имя";
            InitializeComponent();
        }
        //Переопределение кнопки ОК
        protected override void OKButton_Click(object sender, EventArgs e)
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
    }
}
