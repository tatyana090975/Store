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
            MySqlCommand command = new MySqlCommand("SELECT \r\n    p.person_id,   \r\n    u.login,\r\n    u.password,\r\n    CONCAT(p.surname, ' ', p.name, ' ', p.secondname) AS display_name\r\nFROM person p\r\nINNER JOIN users u ON p.person_id = u.users_id\r\nORDER BY p.surname;", dB.GetConnection());
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
            MySqlCommand command = new MySqlCommand("SELECT \r\n    CONCAT(p.surname, ' ', p.name, ' ', \r\n           COALESCE(p.secondname, '')) AS 'ФИО',\r\n    pos.position AS 'Должность'\r\nFROM employe e\r\nINNER JOIN person p ON e.person_id = p.person_id\r\nINNER JOIN `position` pos ON e.position_id = pos.position_id\r\nORDER BY p.surname;", dB.GetConnection());
            adapter1.SelectCommand = command;
            adapter1.Fill(table);
            dB.closeConnection();
            return table;
        }
    }
}
