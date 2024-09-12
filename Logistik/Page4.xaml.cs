using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
using static Logistik.Tables;

namespace Logistik
{
    /// <summary>
    /// Логика взаимодействия для Page4.xaml Transportnie sreedstva
    /// </summary>
    public partial class Page4 : Page
    {
        ConnectDB dataBase = new ConnectDB();

        private ObservableCollection<Vehicle> coursesVeh = new ObservableCollection<Vehicle>();

        public Page4()
        {
            InitializeComponent();
            LoadData();
        }

        //LoadData
        private void LoadData()
        {
            dataGridVeh.ItemsSource = coursesVeh;
        }
        //Creat
        private void Creat_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridVeh.SelectedItem is Vehicle selectedCourse)
            {
                try
                {
                    dataBase.openConnection();
                    string query = $"insert into Vehicle(LicensePlate,Model,Capacity,V_Status) " +
                                    $" values('{selectedCourse.LicensePlate}','{selectedCourse.Model}','{selectedCourse.Capacity}','{selectedCourse.V_Status}')";
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
            if (dataGridVeh.SelectedItem is Vehicle selectedCourse)
            {
                try
                {
                    dataBase.openConnection();
                    string query = $"UPDATE Vehicle SET LicensePlate = '{selectedCourse.LicensePlate}', Model = '{selectedCourse.Model}', Capacity = '{selectedCourse.Capacity}' WHERE VehicleID = {selectedCourse.VehicleID}";
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
            if(dataGridVeh.SelectedItem is Vehicle selectedCourse)
            {
                string query = $"DELETE FROM Vehicle WHERE VehicleID = {selectedCourse.VehicleID}";
                SqlCommand comm = new SqlCommand(query, dataBase.getConnection());
                MessageBox.Show("Успешно удалено! ", comm.ExecuteNonQuery().ToString());
                coursesVeh.Clear();
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
                string query = $"SELECT * FROM [LOGISTIKA].[dbo].[Vehicle] where LicensePlate = '{Poisk.Text}'";
                SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                dataBase.openConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            coursesVeh.Clear();
                            coursesVeh.Add(new Vehicle
                            {
                                VehicleID = reader.GetInt32(0),
                                LicensePlate = reader.GetString(1),
                                Model = reader.GetString(2),
                                Capacity = reader.GetDecimal(3),
                                V_Status = reader.GetString(4),

                            });
                        }
                    }
                    else { MessageBox.Show("Запись не найден!"); }
                }
                LoadData();
            }
            else 
            {
                string query = $"SELECT * FROM [LOGISTIKA].[dbo].[Vehicle]";
                SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                dataBase.openConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            coursesVeh.Clear();
                            coursesVeh.Add(new Vehicle
                            {
                                VehicleID = reader.GetInt32(0),
                                LicensePlate = reader.GetString(1),
                                Model = reader.GetString(2),
                                Capacity = reader.GetDecimal(3),
                                V_Status = reader.GetString(4),

                            });
                        }
                    }
                    else { MessageBox.Show("Запись не найден!"); }
                }
                LoadData();
            }           
        }
        //ChistkaDataGrid
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            coursesVeh.Clear();
            LoadData();
        }
    }
}
