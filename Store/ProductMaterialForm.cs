using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class ProductMaterialForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "product_material";
        public ProductMaterialForm()
        {
            InitializeComponent();
            ParentDirectoryFormFill();
        }
        //Запролнение grid данными из таблицы 
        public override void ParentDirectoryFormFill()
        {
            dataGridViewParentDirectory.DataSource = DBQueries.LoadGridProductMaterialForm();
        }
        //кнопка "Создать запись"
        public override void createRecordButton_Click(object sender, EventArgs e)
        {
            ProductMaterialCardForm productMaterialCardForm = new ProductMaterialCardForm();
            productMaterialCardForm.Show();

        }
        //Кнопка "Открыть Запись"
        public override void openButton_Click(object sender, EventArgs e)
        {
            
            int currenRow = (int)dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            ProductMaterialCardForm productMaterialCardForm = new ProductMaterialCardForm(currenRow);
            productMaterialCardForm.Show();
            
        }
    }
}
