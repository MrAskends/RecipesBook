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
    public partial class FormRegistration : Form
    {
        public FormRegistration()
        {
            InitializeComponent();
            Main.registrationFormClosing = false;
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if (CheckDataCorrectness())
            {
                Main.user.login = textBoxLogin.Text; // Пользователю задаем значение логина который он ввел
                Main.user.password = textBoxPassword.Text; // Пользователю задаем значение пароля который он ввел
                if (!Main.connection.MySqlRegisterUser(Main.user))
                {
                    MessageBox.Show("Такой пользователь уже зарегистрирован.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Main.user = new User(); // Очищаем пользователя
                }
                else
                {
                    MessageBox.Show("Вы успешно зарегистрированы!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form loginForm = Application.OpenForms[1];
                    loginForm.Show(); // Показываем форму логининга
                    Main.registrationFormClosing = true;
                    this.Close();
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Form loginForm = Application.OpenForms[1];
            loginForm.Show(); // Показываем форму логининга
            Main.registrationFormClosing = true;
            this.Close();
        }

        private bool CheckDataCorrectness() // Метод проверки корректности введенных данных
        {
            if (textBoxLogin.Text == "" || textBoxPassword.Text == "" || textBoxPasswordRepeat.Text == "") // Проверка на пустые поля ввода данных
            {
                MessageBox.Show("Одно из полей не заполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxLogin.Text.Length < 6) // Проверка на длину логина
            {
                MessageBox.Show("логин не может быть короче 6 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxPassword.Text.Length < 6) // Проверка на длину пароля
            {
                MessageBox.Show("Пароль не может быть короче 6 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxPassword.Text != textBoxPasswordRepeat.Text) // Проверка на совпадение паролей
            {
                MessageBox.Show("Пароли отличаются.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void FormRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !Main.registrationFormClosing)
            {
                Application.Exit();
            }
        }
    }
}
