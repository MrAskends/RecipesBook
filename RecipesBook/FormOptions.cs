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
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
            Main.optionsFormClosing = false;
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !Main.optionsFormClosing)
            {
                Application.Exit();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms[0];
            mainForm.Show(); // Показываем главную форму
            Main.optionsFormClosing = true;
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckDataCorrectness()) // Если данные корректны
            {
                Main.connection.MySqlAddDishRecipe(textBoxNewDish.Text, textBoxNewRecipe.Text); // Вызов метода добавления нового рецепта в БД
                textBoxNewDish.Clear(); // Очищаем текстбокс с названием блюда
                textBoxNewRecipe.Clear(); // Очищаем текстбокс с рецептом блюда
                Main.mainFormFirstShowing = true;
            }
        }

        private bool CheckDataCorrectness() // Метод для проверки корректности введенных данных
        {
            if (textBoxNewDish.Text == "" || textBoxNewRecipe.Text == "") // Проверка что все поля заполнены 
            {
                MessageBox.Show("Одно из полей не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Main.connection.MySqlCheckDish(textBoxNewDish.Text))  // Проверка на присутствие в бд такого же блюда
            {
                MessageBox.Show("Такое произведение уже есть в хранилище.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
