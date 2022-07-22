using System.Collections.Generic;

namespace RecipesBook
{
    class Main
    {
        public static DataBase connection; // Создаем объект класса DataBase

        public static User user; // Создаем объект класса User

        public static List<string> allDishes; // Создаем список блюд которые есть

        public static bool registrationFormClosing; // Флаг для отлавливания закрытия окна регистрации

        public static bool loginFormClosing; // Флаг для отлавливания закрытия окна логина

        public static bool mainFormShowing; // Флаг для отлавливания открытия главного окна

        public static bool mainFormFirstShowing; // Флаг для отлавливания первого открытия главного окна

        public static bool optionsFormClosing; // Флаг для отлавливания закрытия окна настроек

        static Main() // Singleton класса
        {
            connection = new DataBase("localhost", 3306, "root", "", "recipes_book", 100000);
            user = new User();
            allDishes = new List<string>();
            registrationFormClosing = false;
            loginFormClosing = false;
            mainFormShowing = false;
            mainFormFirstShowing = false;
            optionsFormClosing = false;
        }
    }
}
