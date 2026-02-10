using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class OwnershipCardForm : Store.ParentCardForm
    {
        public override string TableName { get; set; } = "ownership";
        public int ID = 0;
        public OwnershipCardForm()
        {
            name.Text = "Наименование формы собственности";
            InitializeComponent();
        }
        public OwnershipCardForm(int id)
        {
            ID = id;
            name.Text = "Наименование формы собственности";
            InitializeComponent();
            DataTable table = LoadTestForm(id, TableName);
            string value = table.Rows[0]["ownership"].ToString();
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
            if (ID == 0)
            {
                CardData.Add(("ownership", name));

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
                CardData.Add(("ownership", name));

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
