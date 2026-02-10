using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class ProductCardForm : Store.ParentCardForm
    {
        public override string TableName { get; set; } = "product";
        public ProductCardForm()
        {
            name.Text = "Наименование товара";
            InitializeComponent();
            FillColorComboBox();
        }
        public ProductCardForm(int id)
        {
            ID = id;
            name.Text = "Наименование товара";
            InitializeComponent();
            DataTable table = LoadTestForm(id, TableName);
            string value = table.Rows[0]["product"].ToString();
            nameTextBox.Text = value;
            string value1 = table.Rows[0]["length"].ToString();
            leghtTextBox.Text = value1;
            string value2 = table.Rows[0]["width"].ToString();
            widthTextBox.Text = value2;
            string value3 = table.Rows[0]["height"].ToString();
            heightTextBox.Text = value3;
            
            DataTable table1 = DBQueries.LoadParentCard(id, "color");
            foreach (DataRow row in table1.Rows)
            {
                string id1 = row["color_id"].ToString();
                string color = row["color"].ToString();


                // Формируем строку для отображения
                string displayText = $"{color}";

                // Сохраняем ID в свойстве Tag
                colorComboBox.Items.Add(new
                {
                    Text = displayText,
                    Id = id1
                });
                // Настраиваем отображение
                colorComboBox.DisplayMember = "Text";
                colorComboBox.ValueMember = "Id";
                colorComboBox.SelectedIndex = 0;                
            }            
        }
        protected override DataTable LoadTestForm(int a, string tableName)
        {
            int cardId = a;
            string table = TableName;
            DataTable dataTable = DBQueries.LoadParentCard(cardId, table);
            return dataTable;
        }
        //Заполнение данными personComboBox
        private void FillColorComboBox()
        {
            DataTable table = DBQueries.LoadDateInComboBox("color");
            colorComboBox.Items.Clear();
            colorComboBox.Items.Add("--Выберите цвет--");
            //Заполняем данными
            foreach (DataRow row in table.Rows)
            {
                string id = row["color_id"].ToString();
                string color = row["color"].ToString();
                

                // Формируем строку для отображения
                string displayText = $"{color}";

                // Сохраняем ID в свойстве Tag
                colorComboBox.Items.Add(new
                {
                    Text = displayText,
                    Id = id
                });
                // Настраиваем отображение
                colorComboBox.DisplayMember = "Text";
                colorComboBox.ValueMember = "Id";
                colorComboBox.SelectedIndex = 0;
            }
        }
        //Переопределение кнопки ОК
        protected override void OKButton_Click(object sender, EventArgs e)
        {

            if (ID == 0)
            {
                string name = nameTextBox.Text;
                string color = colorComboBox.Text;
                string lenght = leghtTextBox.Text;
                string width = widthTextBox.Text;
                string height = heightTextBox.Text;

                string selectedColorId = "0";
                if (colorComboBox.SelectedItem != null && colorComboBox.SelectedIndex > 0)
                {
                    var selectedItem = (dynamic)colorComboBox.SelectedItem;
                    selectedColorId = selectedItem.Id;
                }

                int color_id = int.Parse(selectedColorId);
                int lenghtInt = 0;
                int widthInt = 0;
                int heightInt = 0;
                if (lenght.All(char.IsDigit)) { lenghtInt = int.Parse(lenght); }
                else { MessageBox.Show("Размеры указываются только цифрами!"); return; }
                if (width.All(char.IsDigit)) { widthInt = int.Parse(width); }
                else { MessageBox.Show("Размеры указываются только цифрами!"); return; }
                if (height.All(char.IsDigit)) { heightInt = int.Parse(height); }
                else { MessageBox.Show("Размеры указываются только цифрами!"); return; }

                CardData.Add(("product", name));
                CardData.Add(("color_id", color_id));
                CardData.Add(("length", lenghtInt));
                CardData.Add(("width", widthInt));
                CardData.Add(("height", heightInt));


                if (name == "" || color_id < 1 || lenghtInt < 0 || widthInt < 0 || heightInt < 0)
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
                string color = colorComboBox.Text;
                string lenght = leghtTextBox.Text;
                string width = widthTextBox.Text;
                string height = heightTextBox.Text;

                string selectedColorId = "0";
                if (colorComboBox.SelectedItem != null)
                {
                    var selectedItem = (dynamic)colorComboBox.SelectedItem;
                    selectedColorId = selectedItem.Id;
                }

                int color_id = int.Parse(selectedColorId);
                int lenghtInt = 0;
                int widthInt = 0;
                int heightInt = 0;
                if (lenght.All(char.IsDigit)) { lenghtInt = int.Parse(lenght); }
                else { MessageBox.Show("Размеры указываются только цифрами!"); return; }
                if (width.All(char.IsDigit)) { widthInt = int.Parse(width); }
                else { MessageBox.Show("Размеры указываются только цифрами!"); return; }
                if (height.All(char.IsDigit)) { heightInt = int.Parse(height); }
                else { MessageBox.Show("Размеры указываются только цифрами!"); return; }

                CardData.Add(("product", name));
                CardData.Add(("color_id", color_id));
                CardData.Add(("length", lenghtInt));
                CardData.Add(("width", widthInt));
                CardData.Add(("height", heightInt));


                if (name == "" || color_id < 1 || lenghtInt < 0 || widthInt < 0 || heightInt < 0)
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
