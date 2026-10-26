using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class SaleForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "saleproducts";
        public SaleForm()
        {
            InitializeComponent();
            ParentDirectoryFormFill();
        }
        
        //Запролнение grid данными из таблицы 
        public override void ParentDirectoryFormFill()
        {
            dataGridViewParentDirectory.DataSource = DBQueries.LoadGridInSaleProducts(TableName);
        }
        //кнопка "Создать запись"
        public override void createRecordButton_Click(object sender, EventArgs e)
        {
            SaleProductsCardForm saleProductsCardForm = new SaleProductsCardForm();
            saleProductsCardForm.Show();

        }
        //Кнопка Открыть карточку
        public override void openButton_Click(object sender, EventArgs e)
        {
            int currenRow = (int)dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            SaleProductsCardForm saleProductsCardForm = new SaleProductsCardForm(currenRow);
            saleProductsCardForm.Show();
        }
    }


}
