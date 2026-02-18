using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class PositionForm : Store.ParentDirectoryForm
    {
        public override string TableName { get; set; } = "position";
        public PositionForm()
        {
            InitializeComponent();
            ParentDirectoryFormFill();
        }
        //Запролнение grid данными из таблицы 
        public override void ParentDirectoryFormFill()
        {
            dataGridViewParentDirectory.DataSource = DBQueries.LoadGridInForm(TableName);
        }
        //кнопка "Создать запись"
        public override void createRecordButton_Click(object sender, EventArgs e)
        {
            PositionCardForm positionCardForm = new PositionCardForm();
            positionCardForm.Show();

        }
        //Кнопка Открыть карточку
        public override void openButton_Click(object sender, EventArgs e)
        {
            int currenRow = (int)dataGridViewParentDirectory.CurrentRow.Cells[0].Value;
            PositionCardForm positionCardForm = new PositionCardForm(currenRow);
            positionCardForm.Show();
        }
    }
}
