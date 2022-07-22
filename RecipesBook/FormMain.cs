using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipesBook
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_VisibleChanged(object sender, EventArgs e)
        {
            if (Main.mainFormFirstShowing)
            {
                Main.mainFormFirstShowing = false;
                if (!Main.user.admin) // Если пользователь не администратор
                {
                    buttonOptions.Visible = false; // Скрываем кнопку настроек
                }
                comboBoxDishes.Items.Clear(); // Очищаем элементы комбобокса
                Main.connection.MySqlGetDishes(); // Метод получения всех доступных блюд
                foreach (string dish in Main.allDishes) // Проходим по всему списку и добавляем все доступные блюда в комбобокс
                {
                    comboBoxDishes.Items.Add(dish); // Записываем в комбобокс блюда
                }
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            try
            {
                Main.connection.MySqlOpenConnection(); // Вызывает метод подключения к БД
                Main.connection.MySqlCreateDataBase(); // Вызывает метод создания БД
                Main.connection.MySqlCreateTables(); // Вызывает метод создания таблиц в БД
                Main.mainFormShowing = false;
                FormLogin loginForm = new FormLogin(); // Создание формы для логина
                loginForm.Show(); // Открытие второй формы (Логинига)
                this.Hide(); // Эту форму скрываем
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Выводим сообщение об ошбике
                Application.Exit();
            }
        }

        private void comboBoxDishes_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxRecipe.Text = Main.connection.MySqlGetDishRecipe(Convert.ToString(comboBoxDishes.SelectedItem)); // Вызываем метод получения рецепта по выбранному блюду и записываем его в текстбокс
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            FormOptions optionsForm = new FormOptions(); // Создание формы для добавления новых рецептов
            optionsForm.Show(); // Открытие формы для добавления новых рецептов
            this.Hide();
        }
    }
}
