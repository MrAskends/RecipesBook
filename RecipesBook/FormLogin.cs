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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            Main.loginFormClosing = false;
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" || textBoxPassword.Text == "") // Проверка на пустые поля ввода
            {
                MessageBox.Show("Одно из полей не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Main.user.login = textBoxLogin.Text; // Пользователю задаем значение логина которые он ввел
                Main.user.password = textBoxPassword.Text; // Пользователю задаем значение пароля которые он ввел

                textBoxLogin.Clear(); // Очищаем текстбокс
                textBoxPassword.Clear(); // Очищаем текстбокс
                if (!Main.connection.MySqlLoginUser(Main.user)) // Если пользователь не найдет то
                {
                    MessageBox.Show("Логин или пароль неверен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод ошибки
                }
                else // Если найден
                {
                    Form mainForm = Application.OpenForms[0];
                    Main.mainFormShowing = true;
                    Main.mainFormFirstShowing = true;
                    mainForm.Show(); // Показываем главную форму
                    Main.loginFormClosing = true;
                    this.Close();
                }
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            FormRegistration registrationForm = new FormRegistration(); // Создание второй формы для регистрации и передача данных с этой формы на вторую
            registrationForm.Show(); // Открытие второй формы
            this.Hide();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !Main.loginFormClosing)
            {
                Application.Exit();
            }
        }
    }
}
