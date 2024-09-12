using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Logistik.Tables;

namespace Logistik
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml  Klienti
    /// </summary>
    public partial class Page1 : Page
    {
        ConnectDB dataBase = new ConnectDB();

        private ObservableCollection<Customer> courses = new ObservableCollection<Customer>();

        public Page1()
        {
            InitializeComponent();
            LoadData();
        }

        //LoadData
        private void LoadData()
        {
            dataGrid.ItemsSource = courses;   
        }
        //DELETE
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            if (dataGrid.SelectedItem is Customer selectedCourse)
            {
                dataBase.openConnection();
                string query = $"DELETE FROM Customers WHERE CustomerID = {selectedCourse.CustomerID}";
                SqlCommand comm = new SqlCommand(query, dataBase.getConnection());
                MessageBox.Show("Успешно удалено! ", comm.ExecuteNonQuery().ToString());
                courses.Clear();
            }
            else
            {
                MessageBox.Show("Выберите строку!.");
            }

        }
        //PoiskKlient
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string query = $"SELECT * FROM [LOGISTIKA].[dbo].[Customers] where FirstName = '{Poisk.Text}'";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConnection();
            int comm = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                
                if (reader.HasRows)
                {
                    courses.Clear();
                    while (reader.Read())
                    {
                        courses.Add(new Customer
                        {
                            CustomerID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            PhoneNumber = reader.GetString(3),
                            Email = reader.GetString(4),
                            C_Address = reader.GetString(5)
                        });
                    }
                }
                else { MessageBox.Show("Запись не найден!");}

               
            }
            LoadData();
        }
        //Ochistka
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            courses.Clear();
            LoadData();
            
        }
        //Update
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Customer selectedCourse)
            {
                try
                {
                    dataBase.openConnection();
                    string query = $"UPDATE Customers SET FirstName = '{selectedCourse.FirstName}', LastName = '{selectedCourse.LastName}', PhoneNumber = '{selectedCourse.PhoneNumber}',Email = '{selectedCourse.Email}', C_Address = '{selectedCourse.C_Address}' WHERE CustomerID = {selectedCourse.CustomerID}";
                    SqlCommand comm = new SqlCommand(query, dataBase.getConnection());
                    MessageBox.Show("Успешно обновлено", comm.ExecuteNonQuery().ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Попробуйте перезапустить программу/n" + ex);
                }
                finally
                {
                    dataBase.closeConnection();
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку!.");
            }
        }
        //Create
        private void Creat_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Customer selectedCourse)
            {
                try
                {
                    dataBase.openConnection();
                    string query = $"insert into Customers(FirstName,LastName,PhoneNumber,Email,C_Address) " +
                                    $" values('{selectedCourse.FirstName}','{selectedCourse.LastName}','{selectedCourse.PhoneNumber}','{selectedCourse.Email}','{selectedCourse.C_Address}')";
                    SqlCommand comm = new SqlCommand(query, dataBase.getConnection());
                    MessageBox.Show("Успешно", comm.ExecuteNonQuery().ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Попробуйте перезапустить программу/n" + ex);
                }
                finally 
                {
                    dataBase.closeConnection();
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку.");
            }
        }
    }

}
