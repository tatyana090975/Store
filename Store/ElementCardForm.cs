using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class ElementCardForm : Store.ParentCardForm
    {
        public override string TableName { get; set; } = "element";
        public int ID = 0;  
        public ElementCardForm()
        {
            name.Text = "Наименование элемента";
            InitializeComponent();
        }
        public ElementCardForm(int id)
        {
            ID = id;
            name.Text = "Наименование элемента";
            InitializeComponent();
            DataTable table = LoadTestForm(id, TableName);
            string value = table.Rows[0]["element"].ToString();
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
            if (ID == 0)
            {
                string name = nameTextBox.Text;
                CardData.Add(("element", name));

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
                CardData.Add(("element", name));

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
