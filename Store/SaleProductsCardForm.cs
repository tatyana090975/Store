using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        protected List<(string column, object value)> CardData3 { get; set; } = new List<(string column, object value)>();

        private List<Tuple<int, int>> SaleProdTable { get; set; } = new List<Tuple<int, int>>();
        private List<Tuple<int>> SaleServicesTable { get; set; } = new List<Tuple<int>>();
        int idSup = 0;
        public SaleProductsCardForm()
        {
            InitializeComponent(); 
            FillCounteragentComboBox();
            FillProductComboWithIds();
            FillServicesComboWithIds();
            
            // Подписка на события для первого DataGridView
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.RowsRemoved += DataGridView1_RowsRemoved;

            // Подписка на события для второго DataGridView
            dataGridView2.CellValueChanged += DataGridView2_CellValueChanged;
            dataGridView2.RowsAdded += DataGridView2_RowsAdded;
            dataGridView2.RowsRemoved += DataGridView2_RowsRemoved;
        }
        public SaleProductsCardForm(int id)
        {
            ID = id;
            string counteragent = "";
            InitializeComponent();
            FillCounteragentComboBox();
            FillProductComboWithIds();
            FillServicesComboWithIds();

            // Подписка на события для первого DataGridView
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.RowsRemoved += DataGridView1_RowsRemoved;

            // Подписка на события для второго DataGridView
            dataGridView2.CellValueChanged += DataGridView2_CellValueChanged;
            dataGridView2.RowsAdded += DataGridView2_RowsAdded;
            dataGridView2.RowsRemoved += DataGridView2_RowsRemoved;

            //Загрузка данных о контрагенте
            DataTable table = LoadTestForm(id, TableName);//верно
            string value = table.Rows[0]["date"].ToString();//+
            dateTimePicker1.Text = value;//+
            dateTimePicker1.Enabled = false;
            //поле "контрагент"
            int idc = (int)table.Rows[0]["counteragent_id"];//+

            DataTable table1 = DBQueries.LoadParentCard(idc, "counteragent");//+
            foreach (DataRow row in table1.Rows)//+
            {
                string id1 = row["counteragent_id"].ToString();//+
                string counteragent1 = row["name"].ToString();//+
                string itn = row["ITN"].ToString();//+
                // Формируем строку для отображения
                counteragent = $"{counteragent1} {itn}";
            }
            counteragentComboBox.Text = counteragent;
            counteragentComboBox.Enabled = false;
            //загрузка данных о доставке
            DataTable table3 = DBQueries.GetDelivery(ID);//+
            string value1 = table3.Rows[0]["address"].ToString();//+
            addressTextBox.Text = value1;//+
            addressTextBox.ReadOnly = true;
            string value2 = table3.Rows[0]["phone"].ToString();//+
            phoneMaskedTextBox.Text = value2;//+
            phoneMaskedTextBox.ReadOnly = true;
            //Заполнение грида товаров карточки позициями
            DataTable table2 = DBQueries.LoadGridSaleProductsCardForm(ID);

            // Отключаем автоматическое создание столбцов
            dataGridView1.AutoGenerateColumns = false;
            // Настраиваем привязку столбцов (делаем один раз)
            dataGridView1.Columns["Column2"].DataPropertyName = "product_id";
            dataGridView1.Columns["Column3"].DataPropertyName = "quantity";
            dataGridView1.Columns["Column4"].DataPropertyName = "price";
            dataGridView1.Columns["Column5"].DataPropertyName = "sum";
            // Устанавливаем DataSource
            dataGridView1.DataSource = table2;
            dataGridView1.ReadOnly = true;
            //Заполнение грида услуг карточки позициями
            DataTable table4 = DBQueries.LoadGridSaleServicesCardForm(ID);

            // Отключаем автоматическое создание столбцов
            dataGridView2.AutoGenerateColumns = false;
            // Настраиваем привязку столбцов (делаем один раз)
            dataGridView2.Columns["ColumnServices"].DataPropertyName = "services_id";
            dataGridView2.Columns["ColumnPrice"].DataPropertyName = "price";
            
            // Устанавливаем DataSource
            dataGridView2.DataSource = table4;
            dataGridView2.ReadOnly = true;
            sumTextBox.ReadOnly = true;
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
        //Заполнение ComboBox товары
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
        //Подсчет суммы в строке price * quantity
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

            //Очистка маски телефона от лишних символов
            phone = Regex.Replace(phone, @"[^\d]", "");

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

                SaveDataGridViewToList();
                SaveDataGridViewToListServices();

                if (counteragentId < 1)
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    string res = DBQueries.SaveCard(TableName, CardData.ToArray());
                    if (res == "Успешно сохранено!")
                    {
                        string res1 = "";
                        string res3 = "";
                        string ids = "";
                        DataTable tb = DBQueries.GetLastInsertId(TableName);
                        ids = tb.Rows[0]["last_id"].ToString();
                        idSup = int.Parse(ids);

                        CardData2.Add(("saleproducts_id", idSup));
                        CardData2.Add(("address", address));
                        CardData2.Add(("phone", phone));

                        string res2 = DBQueries.SaveCard("delivery", CardData2.ToArray());
                        if (res2 == "Успешно сохранено!")
                        {
                            //Сохранение данных из таблицы построчно (товары)
                            foreach (Tuple<int, int> tup in SaleProdTable)
                            {
                                int quantity = tup.Item2;
                                int prodId = tup.Item1;
                                int supProdTabl_id = 0;
                                //нужно написать запрос, который по id товара будет находить во вьюшке sapProdTable_id
                                //в котором current_balans не равен 0 или меньше или равен количеству
                                DataTable table = DBQueries.GetIDSupprodtable(prodId);
                                if (table.Rows.Count > 0)
                                {
                                    for (int i = 0; i < table.Rows.Count; i++)
                                    {
                                        int balance = Convert.ToInt32(table.Rows[i]["current_balance"]);
                                        if (balance >= quantity)
                                        {
                                            supProdTabl_id = Convert.ToInt32(table.Rows[i]["supprodtable_id"]);
                                            break;
                                        }
                                        else
                                        {
                                            int sumQuan = 0;
                                            for (int j = 0; j < table.Rows.Count; j++)
                                            {
                                                sumQuan += Convert.ToInt32(table.Rows[j]["current_balance"]);
                                            }
                                            MessageBox.Show($"На складе {sumQuan} единиц товара в {table.Rows.Count} партиях. Внесите списание несколькими строками.");
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Товара нет в наличии.");
                                }

                                CardData1.Clear();
                                CardData1.Add(("saleproducts_id", idSup));
                                CardData1.Add(("supprodtable_id", supProdTabl_id));
                                CardData1.Add(("quantity", tup.Item2));
                                res1 = DBQueries.SaveCard("saleprodtable", CardData1.ToArray());
                            }
                            if (res1 == "Успешно сохранено!")
                            {
                                //Сохранение данных из таблицы построчно (услуги)
                                foreach (Tuple<int> tup1 in SaleServicesTable)
                                {
                                    CardData3.Clear();
                                    CardData3.Add(("saleproducts_id", ids));
                                    CardData3.Add(("services_id", tup1.Item1));
                                    //CardData1.Add(("quantity", tup1.Item2));
                                    res3 = DBQueries.SaveCard("saleservice", CardData3.ToArray());
                                }
                            }
                            else { MessageBox.Show("Ошибка сохранения в таблицу saleservice"); }
                        }
                        else { MessageBox.Show("Ошибка сохранения в таблицу saleprodtable"); }
                    }
                    else { MessageBox.Show("Ошибка сохранения в таблицу delivery"); }
                    MessageBox.Show("Успешно сохранено.");
                    this.Close();
                }
            }
            else
            {
                this.Close();                
            }
        }
        //Сохранение данных из грида1 в список SupProdTable
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
        //Сохранение данных из грида2 в список SaleServicesTable
        private void SaveDataGridViewToListServices()
        {
            // Очищаем список перед заполнением
            //SupProdTable.Clear();

            // Проходим по всем строкам DataGridView
            foreach (DataGridViewRow row1 in dataGridView2.Rows)
            {
                // Пропускаем новую пустую строку
                if (row1.IsNewRow) continue;

                // Проверяем, что все ячейки не пустые
                if (row1.Cells["ColumnServices"].Value != null)
                {
                    try
                    {
                        int value1 = Convert.ToInt32(row1.Cells["ColumnServices"].Value);
                        
                        // Добавляем кортеж в список
                        SaleServicesTable.Add(new Tuple<int>(value1));
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show($"Ошибка преобразования в строке {row1.Index + 1}: {ex.Message}");
                    }
                }
            }

            // Результат
            //MessageBox.Show($"Сохранено {SupProdTable.Count} записей");
        }
        //Итого по карточке в sumTextBox
        private void CalculateSum()
        {
            decimal sum = 0;

            // Суммируем строки из первого DataGridView (товары)
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Пропускаем пустые строки и новую строку для ввода
                if (!row.IsNewRow && row.Cells["Column5"].Value != null)
                {
                    if (decimal.TryParse(row.Cells["Column5"].Value.ToString(), out decimal rowSum))
                    {
                        sum += rowSum;
                    }
                }
            }

            // Суммируем строки из второго DataGridView (услуги)
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                // Пропускаем пустые строки и новую строку для ввода
                if (!row.IsNewRow && row.Cells["ColumnPrice"].Value != null)
                {
                    if (decimal.TryParse(row.Cells["ColumnPrice"].Value.ToString(), out decimal rowPrice))
                    {
                        sum += rowPrice;
                    }
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
        // Обработчик события изменения выбранного значения в комбобоксе Column2
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Проверяем, что редактируется колонка Column2
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["Column2"].Index)
            {
                // Получаем ComboBox, который используется для редактирования
                ComboBox comboBox = e.Control as ComboBox;
                if (comboBox != null)
                {
                    // Удаляем предыдущий обработчик, чтобы не было дублирования
                    comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
            
                    // Добавляем новый обработчик
                    comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }
        }
        //
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
    
            // Проверяем, что выбрано значение (не пустой элемент)
            if (comboBox.SelectedIndex > 0)
            {
                // Получаем выбранный элемент
                var selectedItem = comboBox.SelectedItem;
        
                // Извлекаем ID товара из выбранного элемента
                int productId = 0;
        
                // В зависимости от того, как хранятся данные в комбобоксе
                if (selectedItem is DataRowView rowView)
                {
                    // Если используется DataBinding
                    productId = Convert.ToInt32(rowView["Id"]);
                }
                else if (selectedItem.GetType().GetProperty("Id") != null)
                {
                    // Если используется анонимный тип
                    dynamic dynamicItem = selectedItem;
                    productId = Convert.ToInt32(dynamicItem.Id);
                }
        
                if (productId > 0)
                {
                    // Получаем текущую строку
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
            
                    // Загружаем цену товара из базы данных
                    decimal price = DBQueries.GetProductPrice(productId);
            
                    // Устанавливаем цену в Column4
                    dataGridView1.Rows[rowIndex].Cells["Column4"].Value = price;
                }
            }
        }
        //заполнение Combobox услуги
        private void FillServicesComboWithIds()
        {
            DataGridViewComboBoxColumn Column2 = dataGridView2.Columns["ColumnServices"] as DataGridViewComboBoxColumn;

            if (Column2 == null) return;

            // Создаем DataTable для хранения ID и текста
            DataTable source = new DataTable();
            source.Columns.Add("Id", typeof(int));
            source.Columns.Add("DisplayText", typeof(string));
            // Добавляем колонку для цены (можно скрыть)
            source.Columns.Add("Price", typeof(decimal));

            // Добавляем пустой элемент
            source.Rows.Add(0, "--Выберите услугу--", 0);

            // Загружаем товары
            DataTable services = DBQueries.LoadGridServicesComboBox();
            foreach (DataRow row in services.Rows)
            {
                source.Rows.Add(
                    Convert.ToInt32(row["services_id"]),
                    $"{row["services"]}",
                    Convert.ToDecimal(row["price"]) // предполагаем, что колонка с ценой называется "price"
                );
            }

            // Привязываем данные к колонке
            Column2.DataSource = source;
            Column2.DisplayMember = "DisplayText";
            Column2.ValueMember = "Id";

            // Добавляем обработчик события для автоматического заполнения цены
            dataGridView2.CellValueChanged += (sender, e) =>
            {
                // Проверяем, что это нужная колонка и ячейка не пустая
                if (e.ColumnIndex == Column2.Index && e.RowIndex >= 0)
                {
                    var comboBoxCell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                    if (comboBoxCell != null && comboBoxCell.Value != null)
                    {
                        // Получаем выбранный ID
                        int selectedId = Convert.ToInt32(comboBoxCell.Value);

                        // Ищем цену в source по ID
                        DataRow[] foundRows = source.Select($"Id = {selectedId}");
                        if (foundRows.Length > 0)
                        {
                            decimal price = Convert.ToDecimal(foundRows[0]["Price"]);

                            // Устанавливаем цену в колонку "Цена" (предполагаем, что она существует)
                            if (dataGridView2.Columns.Contains("ColumnPrice"))
                            {
                                dataGridView2.Rows[e.RowIndex].Cells["ColumnPrice"].Value = price;
                            }
                        }
                    }
                }
            };        
        }
        // Обработчики для второго DataGridView
        private void DataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView2.Columns["ColumnPrice"].Index)
            {
                CalculateSum();
            }
        }

        private void DataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateSum();
        }

        private void DataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateSum();
        }

       
    }
}
