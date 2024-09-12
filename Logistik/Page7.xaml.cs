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
    /// Логика взаимодействия для Page7.xaml
    /// </summary>
    public partial class Page7 : Page
    {
        ConnectDB dataBase = new ConnectDB();

        private int iddriver = 0;
        private int idvehicle = 0;

        private int OrderID = 0;

        private ObservableCollection<Zakaz> zak = new ObservableCollection<Zakaz>();

        public Page7()
        {
            InitializeComponent();
        }

        private void LoadDatazakaz()
        {
            dataGrid.ItemsSource = zak;

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DateTime dateOnly = DateTime.Now.Date;


            string strlastInsertedId = Poisk.Text;
            int lastInsertedId = Convert.ToInt32(strlastInsertedId);

            

            string qyery = $" SELECT Orders.OrderID, Customers.FirstName + ' ' + Customers.LastName AS CustomerName, PickupLocation.L_Name + ' ' + PickupLocation.City AS PunktOtpravki, DeliveryLocation.L_Name + ' ' + DeliveryLocation.City AS PunktPriyoma, Orders.OrderDate, Orders.Cost, Orders.VehicleID, Orders.DriverID, OrderStatus.StatusDescription " +
                $" FROM Orders INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID" +
                $" INNER JOIN Locations AS PickupLocation ON Orders.PickupLocationID = PickupLocation.LocationID " +
                $" INNER JOIN Locations AS DeliveryLocation ON Orders.DeliveryLocationID = DeliveryLocation.LocationID inner join OrderStatus on Orders.O_Status = OrderStatus.StatusID where OrderID = {lastInsertedId}";
            dataBase.openConnection();
            SqlCommand command7 = new SqlCommand(qyery, dataBase.getConnection());
            using (SqlDataReader reader = command7.ExecuteReader())
            {

                if (reader.HasRows)
                {
                    zak.Clear();
                    while (reader.Read())
                    {
                        zak.Add(new Zakaz
                        {
                            OrderID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LocationIDO = reader.GetString(2),
                            LocationIDN = reader.GetString(3),
                            OrderDate = reader.GetDateTime(4).Date,
                            StatusDescription = reader.GetDecimal(5),
                            PriyomDate = dateOnly.Date,
                            StatusDescrip = reader.GetString(8)

                        });
                        idvehicle = reader.GetInt32(6);
                        iddriver = reader.GetInt32(7);
                       
                        OrderID = reader.GetInt32(0);
                        
                        MessageBox.Show("Зап  !" + idvehicle.ToString() + "  " + iddriver.ToString());
                    }                  
                }
                else { MessageBox.Show("Запись не найден!"); }


            }
            LoadDatazakaz();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            zak.Clear();
        }

        private void Creat_Click(object sender, RoutedEventArgs e)
        {
            string vehicle = $"UPDATE Vehicle SET V_Status = 'Свободен' where VehicleID = {idvehicle}";
            SqlCommand command1 = new SqlCommand(vehicle, dataBase.getConnection());
            command1.ExecuteNonQuery();

            string driver = $"UPDATE Drivers SET D_Status = 'Свободен' where DriverID = {iddriver}";
            SqlCommand command2 = new SqlCommand(driver, dataBase.getConnection());
            command2.ExecuteNonQuery();

            string order = $"UPDATE Orders SET O_Status = 3 where OrderID = {OrderID}";
            SqlCommand command3 = new SqlCommand(order, dataBase.getConnection());
            command3.ExecuteNonQuery();

            zak.Clear();
            MessageBox.Show($"Заказ {OrderID} закрить!");


        }
    }
}
