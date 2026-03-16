using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Store
{
    public partial class SupplierProductsCardForm : Form
    {
        public string TableName { get; set; } = "supplierproducts";
        public int ID = 0;
        protected List<(string column, object value)> CardData { get; set; } = new List<(string column, object value)>();
        protected List<(string column, object value)> CardData1 { get; set; } = new List<(string column, object value)>();
        private List<Tuple<int, int, double>> SupProdTable { get; set; } = new List<Tuple<int, int, double>>();
        int idSup = 0;
        public SupplierProductsCardForm()
        {
            InitializeComponent();
            Column1.Visible = false;
            returnButton.Visible = false;
            FillCounteragentComboBox();
            FillProductComboWithIds();            
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // Подписка на событие добавления строк
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;

            // Также полезно подписаться на изменение значений
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.RowsRemoved += DataGridView1_RowsRemoved;
        }

        public SupplierProductsCardForm(int id)
        {
            ID = id;            
            string counteragent = "";
            InitializeComponent();
            FillCounteragentComboBox();
            FillProductComboWithIds();
            Column1.Visible = true;
            returnButton.Visible = true;
            //dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

            DataTable table = LoadTestForm(id, TableName);
            string value = table.Rows[0]["date"].ToString();
            dateTimePicker1.Text = value;
            string value1 = table.Rows[0]["inpnum"].ToString();
            inpNumberTextBox.Text = value1;
            string value2 = table.Rows[0]["inpdate"].ToString();
            dateTimePicker2.Text = value2;
            int idc = (int)table.Rows[0]["counteragent_id"];

            DataTable table1 = DBQueries.LoadParentCard(idc, "counteragent");
            foreach (DataRow row in table1.Rows)
            {
                string id1 = row["counteragent_id"].ToString();
                string counteragent1 = row["name"].ToString();
                string itn = row["ITN"].ToString();
                // Формируем строку для отображения
                counteragent = $"{counteragent1} {itn}";
            }
            counteragentComboBox.Text = counteragent;
            //Заполнение грида карточки позициями
            DataTable table2 = DBQueries.LoadGridSupplierProductsCardForm(ID);
            
            // Отключаем автоматическое создание столбцов
            dataGridView1.AutoGenerateColumns = false;

            // Настраиваем привязку существующих столбцов к полям из table2
            // Делайте это один раз, например, в конструкторе формы или при инициализации
            dataGridView1.Columns["Column1"].DataPropertyName = "empty_column";
            dataGridView1.Columns["Column2"].DataPropertyName = "product_id";
            dataGridView1.Columns["Column3"].DataPropertyName = "quantity"; 
            dataGridView1.Columns["Column4"].DataPropertyName = "price";
            dataGridView1.Columns["Column5"].DataPropertyName = "sum";

            // Устанавливаем DataSource
            dataGridView1.DataSource = table2;
            
        }

        protected DataTable LoadTestForm(int a, string tableName)
        {
            int cardId = a;
            string table = TableName;
            DataTable dataTable = DBQueries.LoadParentCard(cardId, table);
            return dataTable;
        }
        //Заполнение данными counteragentComboBox
        private void FillCounteragentComboBox()
        {
            DataTable table = DBQueries.LoadDateInComboBox("counteragent");
            counteragentComboBox.Items.Clear();
            counteragentComboBox.Items.Add("--Выберите контрагента--");
            //Заполняем данными
            foreach (DataRow row in table.Rows)
            {
                string id = row["counteragent_id"].ToString();
                string name = row["name"].ToString();
                string itn = row["ITN"].ToString();

                // Формируем строку для отображения
                string displayText = $"{name} {itn}";

                // Сохраняем ID в свойстве Tag
                counteragentComboBox.Items.Add(new
                {
                    Text = displayText,
                    Id = id
                });
                // Настраиваем отображение
                counteragentComboBox.DisplayMember = "Text";
                counteragentComboBox.ValueMember = "Id";
                counteragentComboBox.SelectedIndex = 0;
            }
        }
        //Заполнение данными стобца Column2 грида
        private void FillProductComboWithIds()
        {
            DataGridViewComboBoxColumn Column2 = dataGridView1.Columns["Column2"] as DataGridViewComboBoxColumn;

            if (Column2 == null) return;

            // Создаем DataTable для хранения ID и текста
            DataTable source = new DataTable();
            source.Columns.Add("Id", typeof(int));
            source.Columns.Add("DisplayText", typeof(string));

            // Добавляем пустой элемент
            source.Rows.Add(0, "--Выберите товар--");

            // Загружаем товары
            DataTable products = DBQueries.LoadGridProductForm();
            foreach (DataRow row in products.Rows)
            {
                source.Rows.Add(
                    Convert.ToInt32(row["product_id"]),
                    $"{row["product"]} {row["color"]} {row["length"]}x{row["width"]}x{row["height"]}"
                );
            }

            // Привязываем данные к колонке
            Column2.DataSource = source;
            Column2.DisplayMember = "DisplayText";
            Column2.ValueMember = "Id";
        }
        //Проверка на целое число Column3 и на double(2) Column4
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Указываем имя столбца или индекс
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column3")
            {
                // Проверяем, что значение не пустое
                string inputValue = e.FormattedValue.ToString().Trim();

                if (string.IsNullOrEmpty(inputValue))
                    return; // Пустое значение разрешаем (или можно запретить)

                // Проверяем, является ли целым числом
                if (!int.TryParse(inputValue, out int result))
                {
                    MessageBox.Show("Введите целое число!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true; // Отменяем изменение
                }
            }
            //второй столбец цена
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column4")
            {
                // Проверяем, что это нужная колонка (Column4)
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Column4")
                {
                    string inputValue = e.FormattedValue.ToString().Trim();

                    // Пропускаем пустые значения (если нужно)
                    if (string.IsNullOrEmpty(inputValue))
                        return;

                    // Проверка на число с плавающей точкой
                    if (decimal.TryParse(inputValue, out decimal result))
                    {
                        // Проверяем количество знаков после запятой
                        if (HasMoreThanTwoDecimalPlaces(inputValue))
                        {
                            MessageBox.Show("Число должно содержать не более 2 знаков после запятой!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное число!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
            }
        }
        // Метод для проверки количества знаков после запятой
        private bool HasMoreThanTwoDecimalPlaces(string value)
        {
            int decimalIndex = value.IndexOf('.');
            if (decimalIndex == -1)
                decimalIndex = value.IndexOf(',');

            if (decimalIndex == -1)
                return false; // Нет десятичной части

            return value.Length - decimalIndex - 1 > 2;
        }
        //Сумма в Column5
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что это колонки с количеством (Column2) или стоимостью (Column4)
            if (e.RowIndex >= 0 &&
                (e.ColumnIndex == dataGridView1.Columns["Column3"].Index ||
                 e.ColumnIndex == dataGridView1.Columns["Column4"].Index))
            {
                CalculateSumForRow(e.RowIndex);
            }
        }

        private void CalculateSumForRow(int rowIndex)
        {
            // Проверка индекса строки
            if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count)
                return;

            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            // Проверка на новую строку
            if (row.IsNewRow) return;

            // Проверка существования ячеек
            if (row.Cells["Column3"] == null || row.Cells["Column4"] == null || row.Cells["Column5"] == null)
                return;

            decimal quantity = 0;
            decimal price = 0;

            // Безопасное получение значения количества
            if (row.Cells["Column3"].Value != null && row.Cells["Column3"].Value != DBNull.Value)
            {
                decimal.TryParse(row.Cells["Column3"].Value.ToString(), out quantity);
            }

            // Безопасное получение значения цены
            if (row.Cells["Column4"].Value != null && row.Cells["Column4"].Value != DBNull.Value)
            {
                decimal.TryParse(row.Cells["Column4"].Value.ToString(), out price);
            }

            // Вычисляем сумму
            decimal sum = quantity * price;

            // Устанавливаем значение в Column5
            row.Cells["Column5"].Value = sum;

            // Форматируем отображение
            row.Cells["Column5"].Style.Format = "F2";
            row.Cells["Column5"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        //Кнопка "Новый товар"
        private void newProdButton_Click(object sender, EventArgs e)
        {
            ProductCardForm form = new ProductCardForm();
            form.ShowDialog();
            FillProductComboWithIds();
        }
        //Кнопка "Отмена"
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Кнопка "ОК"
        private void OKButton_Click(object sender, EventArgs e)
        {
            string counteragent = counteragentComboBox.Text;
            string inpNum = inpNumberTextBox.Text;
            DateTime currentDate = dateTimePicker1.Value.Date;
            DateTime inpDate = dateTimePicker2.Value.Date;

            string selectedCounteragentId = "0";
            if (counteragentComboBox.SelectedItem != null && counteragentComboBox.SelectedIndex > 0)
            {
                var selectedItem = (dynamic)counteragentComboBox.SelectedItem;
                selectedCounteragentId = selectedItem.Id;
            }
            int counteragentId = int.Parse(selectedCounteragentId);

            if (ID == 0)
            {
                CardData.Add(("counteragent_id", counteragentId));
                CardData.Add(("inpnum", inpNum));
                CardData.Add(("inpdate", inpDate));
                CardData.Add(("date", currentDate));
                SaveDataGridViewToList();

                if (counteragentId < 1 || inpNum == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    string res = DBQueries.SaveCard(TableName, CardData.ToArray());
                    string res1 = "";
                    string ids = "";
                    DataTable tb = DBQueries.GetLastId(TableName);                    
                    ids = tb.Rows[0]["MAX(`supplierproducts_id`)"].ToString();
                    idSup = int.Parse(ids);
                    //Сохранение данных из таблицы построчно
                    foreach (Tuple<int, int, double> tup in SupProdTable)
                    {
                        CardData1.Clear();
                        CardData1.Add(("supplierproducts_id", ids));
                        CardData1.Add(("product_id", tup.Item1));
                        CardData1.Add(("quantity", tup.Item2));
                        CardData1.Add(("price", tup.Item3));
                        res1 = DBQueries.SaveCard("supprodtable", CardData1.ToArray());
                    }
                    MessageBox.Show(res1);
                    this.Close();
                }

            }
            else
            {
                CardData.Add(("counteragent_id", counteragentId));
                CardData.Add(("inpnum", inpNum));
                CardData.Add(("inpdate", inpDate));
                CardData.Add(("date", currentDate));
                SaveDataGridViewToList();

                if (counteragentId < 1 || inpNum == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    //Шапка карточки
                    string res = DBQueries.UpdateCard(TableName, ID, CardData.ToArray());
                    string res1 = "";
                    string ids = "";
                    DataTable tb = DBQueries.GetLastId(TableName);
                    ids = tb.Rows[0]["MAX(`supplierproducts_id`)"].ToString();
                    idSup = int.Parse(ids);
                    //Получить все строки с одинаковым supplierproducts_id
                    DataTable gridTable = DBQueries.ReturnGridForm(idSup);

                    //Сохранение данных из таблицы построчно
                    for (int i = 0; i < gridTable.Rows.Count; i++)
                    {
                        int idp = 0;
                        idp = (int)gridTable.Rows[i]["supprodtable_id"];
                        Tuple<int, int, double> tup = SupProdTable[i];
                        CardData1.Clear();
                        //CardData1.Add(("supprodtable_id", idp));
                        CardData1.Add(("supplierproducts_id", idSup));
                        CardData1.Add(("product_id", tup.Item1));
                        CardData1.Add(("quantity", tup.Item2));
                        CardData1.Add(("price", tup.Item3));
                        res1 = DBQueries.UpdateGridCard("supprodtable", idp, CardData1.ToArray());
                        
                    }

                    
                    MessageBox.Show(res1);
                    this.Close();
                }
            }  
        }
        private void SaveDataGridViewToList()
        {
            // Очищаем список перед заполнением
            //SupProdTable.Clear();

            // Проходим по всем строкам DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Пропускаем новую пустую строку
                if (row.IsNewRow) continue;

                // Проверяем, что все ячейки не пустые
                if (row.Cells["Column2"].Value != null &&
                    row.Cells["Column3"].Value != null &&
                    row.Cells["Column4"].Value != null)
                {
                    try
                    {
                        int value1 = Convert.ToInt32(row.Cells["Column2"].Value);
                        int value2 = Convert.ToInt32(row.Cells["Column3"].Value);
                        double value3 = Convert.ToDouble(row.Cells["Column4"].Value);

                        // Добавляем кортеж в список
                        SupProdTable.Add(new Tuple<int, int, double>(value1, value2, value3));
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show($"Ошибка преобразования в строке {row.Index + 1}: {ex.Message}");
                    }
                }
            }

            // Результат
            //MessageBox.Show($"Сохранено {SupProdTable.Count} записей");
        }
        private void CalculateSum()
        {
            decimal sum = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Пропускаем пустые строки и новую строку для ввода
                if (!row.IsNewRow && row.Cells["Column5"].Value != null)
                {
                    sum += Convert.ToDecimal(row.Cells["Column5"].Value);
                }
            }

            sumTextBox.Text = sum.ToString("N2"); // Формат с 2 знаками после запятой
        }
        // Событие при добавлении строк
        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Небольшая задержка, чтобы строка успела инициализироваться
            CalculateSum();
            
        }

        // Событие при удалении строк
        private void DataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateSum();
        }

        // Событие при изменении значений в ячейках
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Базовые проверки индексов
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (e.RowIndex >= dataGridView1.Rows.Count ||
                    e.ColumnIndex >= dataGridView1.Columns.Count)
                    return;

                // ПОЛУЧАЕМ колонки с проверкой на null
                DataGridViewColumn column3 = dataGridView1.Columns["Column3"];
                DataGridViewColumn column4 = dataGridView1.Columns["Column4"];

                // Если колонки еще не созданы - выходим
                if (column3 == null || column4 == null)
                    return;

                // Проверяем, что это нужные колонки
                if (e.ColumnIndex == column4.Index || e.ColumnIndex == column3.Index)
                {
                    // Дополнительная проверка: существует ли строка
                    if (e.RowIndex < dataGridView1.Rows.Count)
                    {
                        // Вызываем метод расчета для конкретной строки
                        CalculateSumForRow(e.RowIndex);
                        // Пересчитываем общую сумму
                        CalculateSum();
                    }
                }
            }
            catch (Exception ex)
            {
                // Логируем ошибку, но не показываем пользователю
                System.Diagnostics.Debug.WriteLine($"Ошибка в CellValueChanged: {ex.Message}");
            }
        }
    }
    
}

