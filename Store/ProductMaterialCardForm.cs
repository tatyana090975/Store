using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class ProductMaterialCardForm : Store.ParentCardForm
    {
        public override string TableName { get; set; } = "product_material";
        public ProductMaterialCardForm()
        {
            InitializeComponent();
            FillProductComboBox();
            FillMaterialComboBox();
            FillElementComboBox();
        }
        //Заполнение данными materialComboBox
        private void FillMaterialComboBox()
        {
            DataTable table = DBQueries.LoadDateInComboBox("material");
            materialComboBox.Items.Clear();
            materialComboBox.Items.Add("--Выберите материал--");
            //Заполняем данными
            foreach (DataRow row in table.Rows)
            {
                string id = row["material_id"].ToString();
                string material = row["material"].ToString();

                // Формируем строку для отображения
                string displayText = $"{material}";

                // Сохраняем ID в свойстве Tag
                materialComboBox.Items.Add(new
                {
                    Text = displayText,
                    Id = id
                });
                // Настраиваем отображение
                materialComboBox.DisplayMember = "Text";
                materialComboBox.ValueMember = "Id";
                materialComboBox.SelectedIndex = 0;
            }
        }
        //Заполнение данными elementComboBox
        private void FillElementComboBox()
        {
            DataTable table = DBQueries.LoadDateInComboBox("element");
            elementComboBox.Items.Clear();
            elementComboBox.Items.Add("--Выберите элемент--");
            //Заполняем данными
            foreach (DataRow row in table.Rows)
            {
                string id = row["element_id"].ToString();
                string element = row["element"].ToString();

                // Формируем строку для отображения
                string displayText = $"{element}";

                // Сохраняем ID в свойстве Tag
                elementComboBox.Items.Add(new
                {
                    Text = displayText,
                    Id = id
                });
                // Настраиваем отображение
                elementComboBox.DisplayMember = "Text";
                elementComboBox.ValueMember = "Id";
                elementComboBox.SelectedIndex = 0;
            }
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
            string material = materialComboBox.Text;
            string element = elementComboBox.Text;

            string selectedProductId = "0";
            if (productComboBox.SelectedItem != null && productComboBox.SelectedIndex > 0)
            {
                var selectedItem = (dynamic)productComboBox.SelectedItem;
                selectedProductId = selectedItem.Id;
            }
            int product_id = int.Parse(selectedProductId);

            string selectedMaterialId = "0";
            if (materialComboBox.SelectedItem != null && materialComboBox.SelectedIndex > 0)
            {
                var selectedItem = (dynamic)materialComboBox.SelectedItem;
                selectedMaterialId = selectedItem.Id;
            }
            int material_id = int.Parse(selectedMaterialId);

            string selectedElementId = "0";
            if (elementComboBox.SelectedItem != null && elementComboBox.SelectedIndex > 0)
            {
                var selectedItem = (dynamic)elementComboBox.SelectedItem;
                selectedElementId = selectedItem.Id;
            }
            int element_id = int.Parse(selectedElementId);

            CardData.Add(("product_id", product_id));
            CardData.Add(("material_id", material_id));
            CardData.Add(("element_id", element_id));


            if (product_id < 1 || material_id < 1 || element_id < 1)
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
