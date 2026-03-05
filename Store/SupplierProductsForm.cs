using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class SupplierProductsForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "supplierproducts";
        public SupplierProductsForm()
        {
            InitializeComponent();
            ParentDirectoryFormFill();
        }
        //Запролнение grid данными из таблицы 
        public override void ParentDirectoryFormFill()
        {
            dataGridViewParentDirectory.DataSource = DBQueries.LoadGridSupplierProductsForm(TableName);
        }

        //Кнопка "Создать запись"
        public override void createRecordButton_Click(object sender, EventArgs e)
        {
            SupplierProductsCardForm supplierProductsCardForm = new SupplierProductsCardForm();
            supplierProductsCardForm.Show();

        }
        //Кнопка Открыть карточку
        public override void openButton_Click(object sender, EventArgs e)
        {
            var idd = dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            int currenRow = (int)idd;
            SupplierProductsCardForm supplierProductsCardForm = new SupplierProductsCardForm(currenRow);
            supplierProductsCardForm.Show();
        }
    }
}
