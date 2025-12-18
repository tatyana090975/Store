using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class PositionCardForm : Store.ParentCardForm
    {
        public override string TableName { get; set; } = "position";
        public PositionCardForm()
        {
            name.Text = "Наименование должности";
            InitializeComponent();            
        }
        protected override void OKButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            CardData.Add(("position", name));

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
