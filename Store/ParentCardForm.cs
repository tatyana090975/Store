using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class ParentCardForm : Form
    {
        public virtual string TableName { get; set; } = "";
        protected List<(string column, object value)> CardData { get; set; } = new List<(string column, object value)>();
        public ParentCardForm()
        {
            InitializeComponent();
        }
        //заполнение CardData
        protected virtual void FillCardData()
        {
            // Очищаем список
            CardData.Clear();

            // Добавляем основное поле (минимум 1 параметр)
            CardData.Add(("", nameTextBox.Text));

            
        }
        
        //Сохранение карточки в бд
        protected virtual void OKButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            CardData.Add(("", name));
            //string result = DBQueries.SaveCard(TableName, CardData.ToArray());


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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
    }
}
