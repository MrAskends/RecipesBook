using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RecipesBook
{
    class DataBase
    {
        public string host { get; set; } // Поле для хранения Хоста
        public int port { get; set; } // Поле для хранения Порта
        public string userName { get; set; } // Поле для хранения Имени пользователя (БД)
        public string password { get; set; } // Поле для хранения Пароля пользователя (БД)
        public string dbName { get; set; } // Поле для хранения Названия БД
        int numberOfIterations { get; set; } // Поле для хранения количества итераций при хэшировании

        public MySqlConnection connection; // Объект класса mysql

        public DataBase(string host, int port, string userName, string password, string dbName, int numberOfIterations) // Конструктор класса
        {
            this.host = host;
            this.port = port;
            this.userName = userName;
            this.password = password;
            this.dbName = dbName;
            this.numberOfIterations = numberOfIterations;
            this.connection = new MySqlConnection("server=" + host + ";port=" + password + ";userName=" + userName + ";password=" + password);
        }

        public void MySqlOpenConnection() // Метод подключения к БД
        {
            if (this.connection.State == System.Data.ConnectionState.Closed) // Если не мы подключены к БД
                connection.Open(); // То подключаемся
        }

        public void MySqlCloseConnection() // Метод отключения от БД
        {
            if (this.connection.State == System.Data.ConnectionState.Open) // Если мы подключены к БД
                connection.Close(); // То отключаемся
        }

        public void MySqlCreateDataBase() // Метод создания БД
        {
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS recipes_book", connection); // Команда создания БД, если она еще не создана
            cmd.ExecuteNonQuery(); // Выполнение команды
            connection.ChangeDatabase(dbName); // Выбор БД с которой будет работать программа
        }

        public void MySqlCreateTables() // Метод создания таблиц в БД
        {
            MySqlCommand cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS users (" +
                "id integer not null auto_increment primary key," +
                "login text not null," +
                "password text not null," +
                "admin tinyint(1) not null default '0'" +
                ")", connection); // Команда создания таблицы пользователей, если она еще не создана
            cmd.ExecuteNonQuery(); // Выполнение команды
            cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS recipes (" +
                "id integer not null auto_increment primary key," +
                "dish text not null," +
                "dish_recipe text not null" +
                ")", connection); // Команда создания таблицы рецептов, если она еще не создана
            cmd.ExecuteNonQuery(); // Выполнение команды
        }

        public bool MySqlRegisterUser(User user) // Метод регистрации пользователя
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE login=@uL", connection); // Команда поиска пользователя в БД
            cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = user.login; // Замена параметра @uL в команде
            MySqlDataReader reader = cmd.ExecuteReader(); // Создание ридера, который получает ответ от БД
            if (reader.HasRows) // Если ответ имеет строки то
            {
                reader.Close(); // Закрытие запроса
                return false; // Пользователь уже зарегистрирован
            }
            else
            {
                reader.Close(); // Закрытие запроса
                cmd = new MySqlCommand("INSERT INTO users (login, password) VALUES (@uL, @uP)", connection); // Команда вставки данных нового пользователя в таблицу
                cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = user.login; // Замена параметра @uL в команде
                cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = MySqlGetHash(user.password); // Замена параметра @uP в команде и хэширование пароля
                cmd.ExecuteNonQuery(); // Выполнение команды
                return true; // Пользователь успешно зарегистрировался
            }

        }

        public bool MySqlLoginUser(User user) // Метод логининга пользователя
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE login=@uL", connection); // Команда поиска пользователя в БД
            cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = user.login; // Замена параметра @uL в команде
            MySqlDataReader reader = cmd.ExecuteReader(); // Создание ридера, который получает ответ от БД
            if (reader.HasRows) // Если ответ имеет строки то
            {
                reader.Read(); // Считываем строку
                if (MySqlValidatePassword(Convert.ToString(reader.GetValue(2)), user.password)) // Если метод проверки валидности пароля вернет true то 
                {
                    user.id = Convert.ToInt32(reader.GetValue(0)); // Заполнение поля id из полученной строки
                    user.login = Convert.ToString(reader.GetValue(1)); // Заполнение поля login из полученной строки
                    user.password = ""; // Очищаем пароль, чтобы не хранить его в оперативной памяти
                    user.admin = Convert.ToBoolean(reader.GetValue(3)); // Заполнение поля admin из полученной строки
                    reader.Close(); // Закрытие запроса
                    return true; // Пользователь найден
                }
                else
                {
                    reader.Close(); // Закрытие запроса
                    return false; // Пароль неправильный
                }
            }
            else
            {
                reader.Close(); // Закрытие запроса
                return false; // Пользователь не найден
            }
        }

        public void MySqlGetDishes() // Метод получения всех доступных блюд в БД
        {
            Main.allDishes = new List<string>(); // Очищаем список блюд
            MySqlCommand cmd = new MySqlCommand("SELECT dish FROM recipes", connection); // Команда получения блюд из БД
            MySqlDataReader reader = cmd.ExecuteReader(); // Создание ридера, который получает ответ от БД
            while (reader.Read()) // Считываем строки
            {
                Main.allDishes.Add(Convert.ToString(reader.GetValue(0))); // Записываем в список все доступные блюда
            }
            reader.Close(); // Закрытие запроса
        }

        public string MySqlGetDishRecipe(string selectedDish) // Метод получения рецепта выбранного блюда
        {
            string recipe = ""; // создаем строку для хранения рецепта
            MySqlCommand cmd = new MySqlCommand("SELECT dish_recipe FROM recipes WHERE dish=@d", connection); // Команда получения блюд из БД
            cmd.Parameters.Add("@d", MySqlDbType.VarChar).Value = selectedDish; // Замена параметра @d в команде
            MySqlDataReader reader = cmd.ExecuteReader(); // Создание ридера, который получает ответ от БД
            while (reader.Read()) // Считываем строки
            {
                recipe = Convert.ToString(reader.GetValue(0)); // Записываем в строку рецепт
            }
            reader.Close(); // Закрытие запроса

            return recipe; // Возвращаем рецепт
        }

        public bool MySqlCheckDish(string nameNewDish) // Метод проверки присутствия блюда в БД
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM recipes WHERE dish=@d", connection); // Команда получения блюда из БД
            cmd.Parameters.Add("@d", MySqlDbType.VarChar).Value = nameNewDish; // Замена параметра @d в команде
            MySqlDataReader reader = cmd.ExecuteReader(); // Создание ридера, который получает ответ от БД
            if (reader.HasRows) // Если ответ имеет строки, значит, что такое блюдо уже есть в БД
            {
                return true;
            }
            reader.Close(); // Закрытие запроса
            return false;
        }

        public void MySqlAddDishRecipe(string dishName, string dishRecipe) // Метод добавления нового рецепта блюда в БД
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO recipes (dish, dish_recipe) VALUES(@d, @dr)", connection); // Команда вставки нового рецепта блюда в БД
            cmd.Parameters.Add("@d", MySqlDbType.VarChar).Value = dishName; // Замена параметра @d в команде
            cmd.Parameters.Add("@dr", MySqlDbType.VarChar).Value = dishRecipe; // Замена параметра @dr в команде
            cmd.ExecuteNonQuery(); // Выполнение команды
        }

        public string MySqlGetHash(string pwd) // Метод хэширования паролей
        {
            byte[] salt; // Массив для хранения соли
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]); // Заполняем массив соли последовательностью случайных значений 
            var pbkdf2 = new Rfc2898DeriveBytes(pwd, salt, numberOfIterations); // Формируем ключ на основе пароля и соли
            byte[] hash = pbkdf2.GetBytes(20);  // Формируем хэш на основе ключа
            byte[] hashBytes = new byte[36]; // Массив для хранения хэша и соли
            Array.Copy(salt, 0, hashBytes, 0, 16); // Записываем в массив соль
            Array.Copy(hash, 0, hashBytes, 16, 20); // Записываем в массив хэш
            return Convert.ToBase64String(hashBytes); // Возвращаем захэшированный пароль в виде строки
        }

        public bool MySqlValidatePassword(string storedPwd, string enteredPwd) // Метод валидации пароля
        {
            byte[] hashBytes = Convert.FromBase64String(storedPwd); // Переводим захешированный пароль типа строки в массив
            byte[] salt = new byte[16]; // Создаем массив для хранения соли
            Array.Copy(hashBytes, 0, salt, 0, 16); // Получаем соль из хранящегося пароля
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPwd, salt, numberOfIterations); // На основе соли хранящегося пароля и введенного пароля создаем ключ
            byte[] hash = pbkdf2.GetBytes(20); // Формируем хэш для введенного пароля
            for (int i = 0; i < 20; i++) // Проходимся по обоим хэшам и побайтово сравниваем их
                if (hashBytes[i + 16] != hash[i]) // Если вдруг хотя бы один байт отличается то
                    return false; // пароль неверный
            return true; // Пароль верный
        }
    }
}
