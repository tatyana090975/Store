using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class EmployeCardForm : Store.ParentCardForm
    {
        public override string TableName { get; set; } = "employe";
        public EmployeCardForm()
        {
            InitializeComponent();
            FillPersonComboBox();
            FillPositionComboBox();
        }
        //Заполнение данными personComboBox
        private void FillPersonComboBox()
        {
            DataTable table = DBQueries.LoadDateInComboBox("person");
            personComboBox.Items.Clear();
            personComboBox.Items.Add("--Выберите персону--");
            //Заполняем данными
            foreach (DataRow row in table.Rows)
            {
                string id = row["person_id"].ToString();
                string name = row["name"].ToString();
                string secondname = row["secondname"].ToString();
                string surname = row["surname"].ToString();

                // Формируем строку для отображения
                string displayText = $"{surname} {name} {secondname}";

                // Сохраняем ID в свойстве Tag
                personComboBox.Items.Add(new
                {
                    Text = displayText,
                    Id = id
                });
                // Настраиваем отображение
                personComboBox.DisplayMember = "Text";
                personComboBox.ValueMember = "Id";
                personComboBox.SelectedIndex = 0;
            }
        }
        //Заполнение positionComboBox
        private void FillPositionComboBox()
        {
            DataTable table = DBQueries.LoadDateInComboBox("position");
            positionComboBox.Items.Clear();
            positionComboBox.Items.Add("--Выберите должность--");
            //Заполняем данными
            foreach (DataRow row in table.Rows)
            {
                string id = row["position_id"].ToString();
                string position = row["position"].ToString();                

                // Формируем строку для отображения
                string displayText = $"{position}";

                // Сохраняем ID в свойстве Tag
                positionComboBox.Items.Add(new
                {
                    Text = displayText,
                    Id = id
                });
                // Настраиваем отображение
                positionComboBox.DisplayMember = "Text";
                positionComboBox.ValueMember = "Id";
                positionComboBox.SelectedIndex = 0;
            }
        }
        //Переопределение кнопки ОК
        protected override void OKButton_Click(object sender, EventArgs e)
        {            
            string person = personComboBox.Text;

            string selectedPersonId = "0";
            if (personComboBox.SelectedItem != null && personComboBox.SelectedIndex > 0)
            {
                var selectedItem = (dynamic)personComboBox.SelectedItem;
                selectedPersonId = selectedItem.Id;
            }
            string position = positionComboBox.Text;

            string selectedPositionId = "0";
            if (positionComboBox.SelectedItem != null && positionComboBox.SelectedIndex > 0)
            {
                var selectedItem = (dynamic)positionComboBox.SelectedItem;
                selectedPositionId = selectedItem.Id;
            }

            int person_id = int.Parse(selectedPersonId);
            int position_id = int.Parse(selectedPositionId);
            CardData.Add(("person_id", person_id));
            CardData.Add(("position_id", position_id));            

            if (person_id < 1 || position_id < 1)
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
