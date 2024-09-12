using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using System.Data.SqlClient;
using static Logistik.Tables;

namespace Logistik
{
    
    /// <summary>
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {

        ConnectDB dataBase = new ConnectDB();

        private ObservableCollection<Driver> coursesDr = new ObservableCollection<Driver>();

        public Page5()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGrid.ItemsSource = coursesDr;
        }

        //Creat
        private void Creat_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Driver selectedCourse)
            {
                try
                {
                    dataBase.openConnection();
                    string query = $"insert into Drivers(FirstName,LastName,PhoneNumber,Email,D_Status) " +
                                    $" values('{selectedCourse.FirstName}','{selectedCourse.LastName}','{selectedCourse.PhoneNumber}','{selectedCourse.Email}','{selectedCourse.D_Status}')";
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
        //Update
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Driver selectedCourse)
            {
                try
                {
                    dataBase.openConnection();
                    string query = $"UPDATE Drivers SET FirstName = '{selectedCourse.FirstName}', LastName = '{selectedCourse.LastName}', PhoneNumber = '{selectedCourse.PhoneNumber}',Email = '{selectedCourse.Email}' WHERE DriverID = {selectedCourse.DriverID}";
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
        //Delete
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Driver selectedCourse)
            {
                string query = $"DELETE FROM Drivers WHERE DriverID = {selectedCourse.DriverID}";
                SqlCommand comm = new SqlCommand(query, dataBase.getConnection());
                MessageBox.Show("Успешно удалено! ", comm.ExecuteNonQuery().ToString());
                coursesDr.Clear();
            }
            else
            {
                MessageBox.Show("Выберите строку!.");
            }
        }
        //Poisk
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (Poisk.Text != "")
            {
                string query = $"SELECT * FROM [LOGISTIKA].[dbo].[Drivers] where FirstName = '{Poisk.Text}'";
                SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                dataBase.openConnection();
                int comm = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        coursesDr.Clear();
                        while (reader.Read())
                        {
                            coursesDr.Add(new Driver
                            {
                                DriverID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                PhoneNumber = reader.GetString(3),
                                Email = reader.GetString(4),
                                D_Status = reader.GetString(5)
                            });
                        }
                    }
                    else { MessageBox.Show("Запись не найден!"); }


                }
                LoadData();
            }
            else 
            {
                string query = $"SELECT * FROM [LOGISTIKA].[dbo].[Drivers]";
                SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                dataBase.openConnection();
                int comm = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        coursesDr.Clear();
                        while (reader.Read())
                        {
                            coursesDr.Add(new Driver
                            {
                                DriverID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                PhoneNumber = reader.GetString(3),
                                Email = reader.GetString(4),
                                D_Status = reader.GetString(5)
                            });
                        }
                    }
                    else { MessageBox.Show("Запись не найден!"); }


                }
                LoadData();
            }
        }
        //Ochistka
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            coursesDr.Clear();
        }
    }
}
