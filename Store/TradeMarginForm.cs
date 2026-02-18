using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class TradeMarginForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "trademargintable";
        public TradeMarginForm()
        {
            InitializeComponent();
            ParentDirectoryFormFill();
            this.openButton.Visible = false;
        }
        
        //Запролнение grid данными из таблицы 
        public override void ParentDirectoryFormFill()
        {
            dataGridViewParentDirectory.DataSource = DBQueries.LoadGridTradeMarginForm();
        }
        //кнопка "Создать запись"
        public override void createRecordButton_Click(object sender, EventArgs e)
        {
            TradeMarginCardForm tradeMarginCardForm = new TradeMarginCardForm();
            tradeMarginCardForm.Show();
        }
        //Кнопка "Открыть запись"
        public override void openButton_Click(object sender, EventArgs e)
        {
            int currenRow = (int)dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            TradeMarginCardForm tradeMarginCardForm = new TradeMarginCardForm(currenRow);
            tradeMarginCardForm.Show();
        }
    }
}
