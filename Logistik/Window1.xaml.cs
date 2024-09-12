using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Logistik
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ConnectDB dataBase = new ConnectDB();
        public Window1()
        {
            InitializeComponent();
        }


        private void ShowHideButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                PasswordBox.Visibility = Visibility.Collapsed;
                PasswordTextBox.Visibility = Visibility.Visible;
                PasswordTextBox.Text = PasswordBox.Password;
                ShowHideButton.Content = "🙈";
            }
            else
            {
                PasswordBox.Visibility = Visibility.Visible;
                PasswordTextBox.Visibility = Visibility.Collapsed;
                PasswordBox.Password = PasswordTextBox.Text;
                ShowHideButton.Content = "👁";
            }
        }

        public void admin()
        {

        }

        public void master()
        {

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            dataBase.openConnection();
            string username = PasswordEncryption.EncryptPassword(UserNameTextBox.Text);

            string password = PasswordEncryption.EncryptPassword(PasswordBox.Password);

            System.Windows.MessageBox.Show(password);
            System.Windows.MessageBox.Show(username);


            string Em_Login = "";
            string Em_Password = "";
            string FIO = "";
            string Job_Title = "";

            string queryselect = $"select Pass_Log.Em_Login, Pass_Log.Em_Password, Sotrudniki.FIO, Sotrudniki.Job_Title from Pass_Log  inner join Sotrudniki on Pass_Log.ID_Employee = Sotrudniki.ID_Employee where Pass_Log.Em_Login = '{username}' and Pass_Log.Em_Password = '{password}'";

            // Создание команды SQL с использованием запроса и подключения
            SqlCommand command = new SqlCommand(queryselect, dataBase.getConnection());

            // Создание адаптера данных, который использует команду SQL
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            // Создание пустой таблицы данных в памяти
            DataTable dataTable = new DataTable();

            // Заполнение таблицы данных результатами выполнения SQL-запроса
            adapter.Fill(dataTable);

            command.ExecuteNonQuery(); // Выполнение команды

            if (dataTable.Rows.Count > 0)
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Em_Login = Convert.ToString(reader["Em_Login"]);
                        Em_Password = Convert.ToString(reader["Em_Password"]);
                        FIO = Convert.ToString(reader["FIO"]);
                        Job_Title = Convert.ToString(reader["Job_Title"]);
                    }
                }
                dataBase.closeConnection();

                if (Job_Title == "Администратор")
                {

                    master();
                }
                else if (Job_Title == "Мастер")
                {

                    admin();
                }


            }
            else
            {
                System.Windows.MessageBox.Show("Неправильный пароль или логин!");

            }

            UserNameTextBox.Text = "";
            PasswordBox.Password = "";


        }


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Логин")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Логин";
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }


        public class PasswordEncryption
        {
            public static string EncryptPassword(string password)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // Преобразуем пароль в массив байтов и вычисляем хеш
                    byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                    // Создаем StringBuilder для хранения хеша в виде строки
                    StringBuilder builder = new StringBuilder();

                    // Преобразуем каждый байт хеша в шестнадцатеричную строку и добавляем к строке
                    for (int i = 0; i < data.Length; i++)
                    {
                        builder.Append(data[i].ToString("x2"));
                    }

                    // Возвращаем зашифрованный пароль
                    return builder.ToString();
                }
            }
        }

    }
}
