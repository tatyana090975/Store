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
        int productId = 0;
        int materialId = 0;
        int elementId = 0;
        int colorId = 0;
        public ProductMaterialCardForm()
        {
            InitializeComponent();
            FillProductComboBox();
            FillMaterialComboBox();
            FillElementComboBox();
        }
        public ProductMaterialCardForm(int id)
        {
            this.ID = id;
            string product = "";
            string material = "";
            string element = "";
            string color = "";
            InitializeComponent();
            FillProductComboBox();
            FillMaterialComboBox();
            FillElementComboBox();
            DataTable table = LoadTestForm(id, TableName);
            foreach (DataRow row in table.Rows)
            {
                productId = (int)row["product_id"];
                materialId = (int)row["material_id"];
                elementId = (int)row["element_id"];
            }
            //Находим товар
            DataTable table3 = DBQueries.LoadParentCard(productId, "product");
            foreach (DataRow row in table3.Rows)
            {
                colorId = (int)row["color_id"];
            }
            DataTable table4 = DBQueries.LoadParentCard(colorId, "color");
            foreach (DataRow row1 in table4.Rows)
            {
                string idp = row1["color_id"].ToString();
                string name = row1["color"].ToString();
                color = $"{name}";
            }

            foreach (DataRow row in table3.Rows)
            {
                string idp = row["product_id"].ToString();
                string name = row["product"].ToString();
                string length = row["length"].ToString();
                string width = row["width"].ToString();
                string height = row["height"].ToString();
                product = $"{name} {color} {length} {width} {height}";
            }
            productComboBox.Text = product;
            //Находим материал
            DataTable table1 = DBQueries.LoadParentCard(materialId, "material");
            foreach (DataRow row in table1.Rows)
            {
                string idp = row["material_id"].ToString();
                string name = row["material"].ToString();
                material = $"{name}";
            }
            materialComboBox.Text = material;
            //Находим элемент
            DataTable table2 = DBQueries.LoadParentCard(elementId, "element");
            foreach (DataRow row in table2.Rows)
            {
                string idp = row["element_id"].ToString();
                string name = row["element"].ToString();
                element = $"{name}";
            }
            elementComboBox.Text = element;
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

            if (ID == 0)
            {
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
            else
            {
                CardData.Add(("product_id", product_id));
                CardData.Add(("material_id", material_id));
                CardData.Add(("element_id", element_id));


                if (product_id < 1 || material_id < 1 || element_id < 1)
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
