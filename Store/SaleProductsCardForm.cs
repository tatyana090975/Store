using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class SaleProductsCardForm : Form
    {
        public string TableName { get; set; } = "saleproducts";
        public int ID = 0;
        protected List<(string column, object value)> CardData { get; set; } = new List<(string column, object value)>();
        protected List<(string column, object value)> CardData1 { get; set; } = new List<(string column, object value)>();
        protected List<(string column, object value)> CardData2 { get; set; } = new List<(string column, object value)>();

        private List<Tuple<int, int>> SaleProdTable { get; set; } = new List<Tuple<int, int>>();
        int idSup = 0;
        public SaleProductsCardForm()
        {
            InitializeComponent(); 
            FillCounteragentComboBox();
            FillProductComboWithIds();
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // Подписка на событие добавления строк
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;

            // Также полезно подписаться на изменение значений
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.RowsRemoved += DataGridView1_RowsRemoved;
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
       
        //Кнопка "Отмена"
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Кнопка "ОК"
        private void OKButton_Click(object sender, EventArgs e)
        {
            string counteragent = counteragentComboBox.Text;            
            DateTime currentDate = dateTimePicker1.Value.Date;
            string address = addressTextBox.Text;
            string phone = phoneMaskedTextBox.Text;

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
                CardData.Add(("date", currentDate));
                CardData2.Add(("addess", address));
                CardData2.Add(("phone",  phone));
                SaveDataGridViewToList();

                if (counteragentId < 1)
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    string res = DBQueries.SaveCard(TableName, CardData.ToArray());
                    
                    string res1 = "";
                    string ids = "";
                    DataTable tb = DBQueries.GetLastId(TableName);
                    ids = tb.Rows[0]["MAX(`saleproducts_id`)"].ToString();
                    idSup = int.Parse(ids);
                    CardData2.Add(("delivery_id", idSup));
                    string res2 = DBQueries.SaveCard("delivery", CardData2.ToArray());
                    //Сохранение данных из таблицы построчно
                    foreach (Tuple<int, int> tup in SaleProdTable)
                    {
                        CardData1.Clear();
                        CardData1.Add(("saleproducts_id", ids));
                        CardData1.Add(("product_id", tup.Item1));
                        CardData1.Add(("quantity", tup.Item2));                        
                        res1 = DBQueries.SaveCard("saleprodtable", CardData1.ToArray());
                    }
                    MessageBox.Show(res1);
                    this.Close();
                }

            }
            else
            {
                CardData.Add(("counteragent_id", counteragentId));
                CardData.Add(("date", currentDate));
                CardData2.Add(("addess", address));
                CardData2.Add(("phone", phone));
                SaveDataGridViewToList();

                if (counteragentId < 1)
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
                    ids = tb.Rows[0]["MAX(`saleproducts_id`)"].ToString();
                    idSup = int.Parse(ids);
                    CardData2.Add(("delivery_id", idSup));
                    string res2 = DBQueries.UpdateCard("delivery", ID, CardData2.ToArray());
                    //Получить все строки с одинаковым supplierproducts_id
                    DataTable gridTable = DBQueries.ReturnGridForm(idSup);

                    //Сохранение данных из таблицы построчно
                    for (int i = 0; i < gridTable.Rows.Count; i++)
                    {
                        int idp = 0;
                        idp = (int)gridTable.Rows[i]["supprodtable_id"];
                        Tuple<int, int> tup = SaleProdTable[i];
                        CardData1.Clear();
                        //CardData1.Add(("supprodtable_id", idp));
                        CardData1.Add(("saleproducts_id", idSup));
                        CardData1.Add(("product_id", tup.Item1));
                        CardData1.Add(("quantity", tup.Item2));
                        
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
                        // Добавляем кортеж в список
                        SaleProdTable.Add(new Tuple<int, int>(value1, value2));
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
        //Кнопка "Новый контрагент"
        private void newCounteragentButton_Click(object sender, EventArgs e)
        {
            CounteragentCardForm form = new CounteragentCardForm();
            form.ShowDialog();
            FillCounteragentComboBox();
        }

        
    }
}
