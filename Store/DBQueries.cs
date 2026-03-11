using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class DBQueries
    {
        //Запрос содержимого грида
        public static DataTable ReturnGridForm(int id)
        {
            int ID = id;
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            //string columnName = $"{tableName}_id";
            string query = $"SELECT * FROM `supprodtable` WHERE `supplierproducts_id` = @id ORDER BY supprodtable_id";
            MySqlCommand command = new MySqlCommand(query, dB.GetConnection());
            command.Parameters.AddWithValue("@id", ID);
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //Обновление DataGridView (табличной части) карточки
        public static string UpdateGridCard(string tableName, int id, params (string column, object value)[] data)
        {
            string errorMessage = string.Empty;
            DB dB = new DB();

            try
            {
                dB.openConnection();

                // Проверяем, есть ли данные для обновления
                if (data == null || data.Length == 0)
                {
                    return "Нет данных для обновления";
                }

                // Формируем SET часть запроса
                var setClauses = string.Join(", ",
                    data.Select((d, i) => $"{d.column} = @p{i}"));
                string rowId = "supprodtable" + "_" + "id";
                // SQL запрос с правильным синтаксисом UPDATE
                string sql = $"UPDATE {tableName} SET {setClauses} WHERE {rowId} = @id";

                using (var command = new MySqlCommand(sql, dB.GetConnection()))
                {
                    // Добавляем параметры для SET значений
                    for (int i = 0; i < data.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@p{i}", data[i].value ?? DBNull.Value);
                    }

                    // Добавляем параметр для ID
                    command.Parameters.AddWithValue("@id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        //return "Запись не найдена или не была изменена";
                    }

                    return "Успешно обновлено!";
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062) // Код ошибки дублирования
            {
                errorMessage = $"Запись уже существует в базе данных.";
                return errorMessage;
            }
            catch (MySqlException ex)
            {
                errorMessage = $"Ошибка базы данных ({ex.Number}): {ex.Message}";
                return errorMessage;
            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка: {ex.Message}";
                return errorMessage;
            }
            finally
            {
                dB.closeConnection();
            }
        }
        //Заполнение грида карточки SupplierProductsCardForm при открытии
        public static DataTable LoadGridSupplierProductsCardForm(int id)
        {
            int ID = id;
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT p.product_id, quantity,price, CONCAT(p.product, ' ', COALESCE(c.color, ''), ' ', p.length, 'x', p.width, 'x', p.height) AS product_info, (quantity * price) AS sum FROM supprodtable spt LEFT JOIN product p ON spt.product_id = p.product_id LEFT JOIN color c ON p.color_id = c.color_id WHERE spt.supplierproducts_id = 11 ORDER BY p.product;", dB.GetConnection());
            command.Parameters.AddWithValue("@id", ID);
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //Заполнение grid SupplierProductsForm данными 
        public static DataTable LoadGridSupplierProductsForm(string TableName)
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT s.supplierProducts_id, s.date, c.name,\r\ns.inpNum,\r\ns.inpDate\r\nFROM supplierProducts s\r\nLEFT JOIN\r\ncounteragent c ON s.counteragent_id = c.counteragent_id;", dB.GetConnection());
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }

        //Загрузка грида counteragent
        public static DataTable LoadGridCounteragentForm()
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT c.counteragent_id, o.ownership, c.name, c.address, c.phone, c.itn, CONCAT(p.surname, ' ', p.name, ' ', p.secondname) AS display_name FROM person p INNER JOIN counteragent c ON p.person_id = c.person_id LEFT JOIN ownership o ON c.ownership_id = o.ownership_id ORDER BY p.surname;", dB.GetConnection());
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //Cмена статуса предыдущей записи на false при сохранении новой карточки торговой наценки
        public static void UpdateStatusTradeVargin(int product_id)
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE trademargintable SET status = FALSE WHERE product_id = @product_id AND status = TRUE;", dB.GetConnection());
            command.Parameters.AddWithValue("@product_id", product_id);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dB.closeConnection();
        }
        
        //Загрузка списка пользователей в поле loginPasswordList LoginForm
        public static DataTable LoadLoginList()
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT users_id, users_login, users_password FROM users", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dB.closeConnection();
            return table;
        }

        //Заполнение grid в простых формах (данные берутся из одной таблицы бд)
        public static DataTable LoadGridInForm(string tableName)
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            string columnName = $"{tableName}_id";
            string query = $"SELECT * FROM `{tableName}`";
            MySqlCommand command = new MySqlCommand(query, dB.GetConnection());
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //удаление строки из базы данных по id
        public static string DeleteRow(string tableName, int numId)
        {
            string errorMessage = string.Empty;
            DB dB = new DB();
            try
            {
                dB.openConnection();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                // Формируем имя столбца как имя_таблицы_id
                string columnName = $"{tableName}_id";
                string query = $"DELETE FROM `{tableName}` WHERE `{columnName}` = @numId";

                MySqlCommand command = new MySqlCommand(query, dB.GetConnection());
                command.Parameters.AddWithValue("@numId", numId);
                adapter1.SelectCommand = command;
                adapter1.Fill(table);

                dB.closeConnection();
                errorMessage = $"Запись успешно удалена.";
                return errorMessage;
            }
            catch (MySqlException ex) when (ex.Number == 1451) // Код ошибки удаления
            {
                // Извлекаем значение из сообщения об ошибке
                errorMessage = $"Невозможно удалить запись т.к. она используется в других справочниках.";
                return errorMessage;
            }
            catch (MySqlException ex)
            {
                errorMessage = $"Ошибка базы данных: {ex.Message}";
                return errorMessage;
            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка: {ex.Message}";
                return errorMessage;
            }
            finally
            {
                dB.closeConnection();
            }

        }
        //Сохраниение карточки в таблицу базы данных
        public static string SaveCard(string tableName, params (string column, object value)[] data)
        {
            string errorMessage = string.Empty;
            DB dB = new DB();
            try
            {
                dB.openConnection();
                // Формируем SQL динамически
                var columns = string.Join(", ", data.Select(d => d.column));
                var parameters = string.Join(", ", data.Select((d, i) => $"@p{i}"));

                string sql = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                using (var command = new MySqlCommand(sql, dB.GetConnection()))
                {
                    // Добавляем параметры
                    for (int i = 0; i < data.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@p{i}", data[i].value ?? DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                    return "Успешно сохранено!";
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062) // Код ошибки дублирования
            {
                // Извлекаем значение из сообщения об ошибке
                errorMessage = $"Запись уже существует в базе данных.";
                return errorMessage;
            }
            catch (MySqlException ex)
            {
                errorMessage = $"Ошибка базы данных: {ex.Message}";
                return errorMessage;
            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка: {ex.Message}";
                return errorMessage;
            }
            finally
            {
                dB.closeConnection();
            }
        }


        //Заполнение grid UsersForms данными из таблиц users и person
        public static DataTable LoadGridUsersForm()
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT p.person_id, u.login, u.password, CONCAT(p.surname, ' ', p.name, ' ', p.secondname) AS display_name FROM person p INNER JOIN users u ON p.person_id = u.users_id ORDER BY p.surname;", dB.GetConnection());
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //Заполнение данными Combobox
        public static DataTable LoadDateInComboBox(string TableName)
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `{TableName}`", dB.GetConnection());
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //Заполнение grid EmployeForms данными из таблиц position и person
        public static DataTable LoadGridEmployeForm()
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT e.employe_id AS 'ID', CONCAT(p.surname, ' ', p.name, ' ', COALESCE(p.secondname, '')) AS 'ФИО', pos.position AS 'Должность' FROM employe e INNER JOIN person p ON e.person_id = p.person_id INNER JOIN `position` pos ON e.position_id = pos.position_id ORDER BY p.surname;", dB.GetConnection());
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //Заполнение grid ProductForms данными из таблиц product и color
        public static DataTable LoadGridProductForm()
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT p.product_id, p.product, c.color, p.length, p.width, p.height  FROM product p LEFT JOIN color c ON p.color_id = c.color_id;", dB.GetConnection());
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //Заполнение грида product_material
        public static DataTable LoadGridProductMaterialForm()
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT pm.product_Material_id, CONCAT (p.product, ' ', COALESCE(c.color, ''), ' ', p.length, 'x', p.width, 'x', p.height) AS product_info,  m.material, e.element FROM product_material pm LEFT JOIN product p ON pm.product_id = p.product_id LEFT JOIN color c ON p.color_id = c.color_id INNER JOIN material m ON pm.material_id = m.material_id INNER JOIN element e ON pm.element_id = e.element_id ORDER BY p.product, m.material, e.element;", dB.GetConnection());
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //Заполнение грида tradeMarginTable
        public static DataTable LoadGridTradeMarginForm()
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT t.tradeMarginTable_id, CONCAT(p.product, ' ', COALESCE(c.color, ''), ' ', p.length, 'x', p.width, 'x', p.height) AS product_info, t.percent, t.status, t.date    FROM product p  LEFT JOIN color c ON p.color_id = c.color_id LEFT JOIN trademargintable t ON t.product_id = p.product_id LEFT JOIN product_material pm ON pm.product_id = p.product_id ORDER BY p.product;", dB.GetConnection());
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //запрос на заполнение полей при открытии карточки общий
        public static DataTable LoadParentCard(int id, string tabeName)
        {
            string tableName = tabeName;
            int cardId = id;
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            string columnName = $"{tableName}_id";
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `{tableName}` WHERE `{columnName}` = @id", dB.GetConnection());
            command.Parameters.AddWithValue("@id", cardId);
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //
        public static DataTable LoadProduct(int id, string tabeName)
        {
            string tableName = tabeName;
            int cardId = id;
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            string columnName = $"{tableName}_id";
            MySqlCommand command = new MySqlCommand($"SELECT  p.product, c.color,  p.length,  p.width,  p.height FROM product p LEFT JOIN color c ON p.color_id = c.color_id WHERE p.product_id = @id", dB.GetConnection());
            command.Parameters.AddWithValue("@id", cardId);
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
        //Кнопка ОК обновление данных в карточке
        public static string UpdateCard(string tableName, int id, params (string column, object value)[] data)
        {
            string errorMessage = string.Empty;
            DB dB = new DB();

            try
            {
                dB.openConnection();

                // Проверяем, есть ли данные для обновления
                if (data == null || data.Length == 0)
                {
                    return "Нет данных для обновления";
                }

                // Формируем SET часть запроса
                var setClauses = string.Join(", ",
                    data.Select((d, i) => $"{d.column} = @p{i}"));
                string rowId = tableName + "_" + "id";
                // SQL запрос с правильным синтаксисом UPDATE
                string sql = $"UPDATE {tableName} SET {setClauses} WHERE {rowId} = @id";

                using (var command = new MySqlCommand(sql, dB.GetConnection()))
                {
                    // Добавляем параметры для SET значений
                    for (int i = 0; i < data.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@p{i}", data[i].value ?? DBNull.Value);
                    }

                    // Добавляем параметр для ID
                    command.Parameters.AddWithValue("@id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return "Запись не найдена или не была изменена";
                    }

                    return "Успешно обновлено!";
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062) // Код ошибки дублирования
            {
                errorMessage = $"Запись уже существует в базе данных.";
                return errorMessage;
            }
            catch (MySqlException ex)
            {
                errorMessage = $"Ошибка базы данных ({ex.Number}): {ex.Message}";
                return errorMessage;
            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка: {ex.Message}";
                return errorMessage;
            }
            finally
            {
                dB.closeConnection();
            }
        }
        //Получить id последней записи в таблице supplierproducts
        public static DataTable GetLastId(string tabeName)
        {
            string tableName = tabeName;            
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            string columnName = $"{tableName}_id";
            MySqlCommand command = new MySqlCommand($"SELECT MAX(`supplierproducts_id`) FROM `supplierproducts`", dB.GetConnection());
            //command.Parameters.AddWithValue("@id", columnName);
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
    }
}