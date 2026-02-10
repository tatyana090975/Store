using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class ProductForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "product";
        public ProductForm()
        {
            InitializeComponent();
            ParentDirectoryFormFill();
        }
        //Запролнение grid данными из таблицы 
        public override void ParentDirectoryFormFill()
        {
            dataGridViewParentDirectory.DataSource = DBQueries.LoadGridProductForm();
        }
        //кнопка "Создать запись"
        public override void createRecordButton_Click(object sender, EventArgs e)
        {
            ProductCardForm productCardForm = new ProductCardForm();
            productCardForm.Show();

        }
        //Кнопка Открыть карточку
        protected override void openButton_Click(object sender, EventArgs e)
        {
            int currenRow = (int)dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            ProductCardForm productCardForm = new ProductCardForm(currenRow);
            productCardForm.Show();
        }
    }
}
