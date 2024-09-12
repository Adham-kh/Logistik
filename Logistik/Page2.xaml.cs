using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        ConnectDB dataBase = new ConnectDB();

        private ObservableCollection<Location> location = new ObservableCollection<Location>();

        private ObservableCollection<Zakaz> zak = new ObservableCollection<Zakaz>();

        public Page2()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataBase.openConnection();
            string query = $"SELECT DISTINCT City FROM Locations";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    location.Clear();
                    while (reader.Read())
                    {
                        location.Add(new Location
                        {
                            
                            City = reader.GetString(0),
                        });
                    }
                }
                Poisk.ItemsSource = location;
                Poisk.DisplayMemberPath = "City";
            }

        }

        private void LoadDatazakaz() 
        {
            dataGridZakaz.ItemsSource = zak;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string GorodOtpravki = "Худжанд";
            string PunktOtpravki = "Пункт Приёма №2";

            string GorodPoluchatel = Poisk.Text;
            string Punkt = name.Text;
            string imyaklienta = klient.Text;




            decimal.TryParse(dlina.Text, out decimal DlinaGruza);
            decimal.TryParse(ves.Text, out decimal VesGruza);
            decimal.TryParse(shirina.Text, out decimal ShirinaGruza);


            decimal obyom = DlinaGruza + ShirinaGruza;

            //MessageBox.Show(obyom.ToString());


            //Location
            int IDGorodOtpravki = 2;
            int IDGorodPoluchatel = 0;
            dataBase.openConnection();
            string query = $"SELECT * from Locations  WHERE City = '{Poisk.Text}'";
            SqlCommand command1 = new SqlCommand(query, dataBase.getConnection());

            using (SqlDataReader reader = command1.ExecuteReader())
            {
                while (reader.Read())
                {
                    IDGorodPoluchatel = reader.GetInt32(0);
                }
            }
           // MessageBox.Show(IDGorodOtpravki.ToString(), IDGorodPoluchatel.ToString());


            //Marshrut
            decimal Distance = 0;
            decimal EstimatedTime = 0;
            dataBase.openConnection();
            string route = $"SELECT * FROM Rout WHERE StartLocationID = {IDGorodOtpravki} and EndLocationID = {IDGorodPoluchatel};";
            SqlCommand command2 = new SqlCommand(route, dataBase.getConnection());

            using (SqlDataReader reader = command2.ExecuteReader())
            {
                while (reader.Read())
                {
                    Distance = reader.GetDecimal(3);
                    EstimatedTime = reader.GetDecimal(4);
                }
            }
            //MessageBox.Show(Distance.ToString(), EstimatedTime.ToString());


            decimal Cost = FreightCalculator.CalculateFreightCost(Distance, VesGruza, obyom);
            int intValue = Convert.ToInt32(Cost);


            //MessageBox.Show(Cost.ToString());


            //Klient
            int CustomerID = 0;
            string kl = $"SELECT * FROM Customers WHERE FirstName = '{klient.Text}'";
            SqlCommand command3 = new SqlCommand(kl, dataBase.getConnection());

            using (SqlDataReader reader = command3.ExecuteReader())
            {
                while (reader.Read())
                {
                    CustomerID = reader.GetInt32(0);

                }
            }
            //MessageBox.Show(CustomerID.ToString() + "klient");

            //Vehiles 

            int IDVehicle = 0;
            string IDquery = "SELECT * From Vehicle  where V_Status = 'Свободен'";
            SqlCommand command4 = new SqlCommand(IDquery, dataBase.getConnection());

            using (SqlDataReader reader = command4.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IDVehicle = reader.GetInt32(0);

                    }
                }
                else { MessageBox.Show(IDVehicle.ToString() + " Cвободных транспорных средств нет!"); return; }
            }
            MessageBox.Show(IDVehicle.ToString() + "Vehicel");


            //Driver 


            int IDDriver = 0;
            string Driverquery = "SELECT * From Drivers  where D_Status = 'Свободен'";
            SqlCommand command5 = new SqlCommand(Driverquery, dataBase.getConnection());

            using (SqlDataReader reader = command5.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IDDriver = reader.GetInt32(0);

                    }
                }
                else { MessageBox.Show(IDDriver.ToString() + " Cвободных водилей нет!"); return; }
            }
            MessageBox.Show(IDDriver.ToString() + "Driver");

            //Zapis 
            DateTime dateOnly = DateTime.Now.Date;

            string dateonlu2 = dateOnly.ToString();

            string firstTenCharacters = dateonlu2.Substring(0, 10);

            //MessageBox.Show(firstTenCharacters.ToString() + "   Date");
            //double estimatedTimeDouble = (double)EstimatedTime;
            //DateTime DeliveryDate = dateOnly.AddDays(estimatedTimeDouble);
            //string DeliveryDate2 = DeliveryDate.ToString();
            //string firstTenCharactersDeliveryDate = DeliveryDate2.Substring(0, 10);
            //MessageBox.Show(firstTenCharactersDeliveryDate.ToString() + "  DilevryDate");

            int status = 2;
            int lastInsertedId = 0;
            string querytZakaz = $"INSERT INTO Orders(CustomerID,VehicleID,DriverID ,PickupLocationID,DeliveryLocationID,OrderDate,O_Status,Cost) values({CustomerID},{IDVehicle},{IDDriver},{IDGorodOtpravki},{IDGorodPoluchatel},'{firstTenCharacters}',{status},{intValue}) SELECT SCOPE_IDENTITY()";
            using (SqlCommand command6 = new SqlCommand(querytZakaz, dataBase.getConnection()))
            {
                dataBase.openConnection();
                // Выполняем команду и получаем последний вставленный идентификатор
                var result = command6.ExecuteScalar();
                if (result != null)
                {
                    lastInsertedId = Convert.ToInt32(result);
                    MessageBox.Show("Не удалось получить последний вставленный ID" + lastInsertedId.ToString());

                }
                else
                {
                    MessageBox.Show("Не удалось получить последний вставленный ID");
                }
            }

            
            MessageBox.Show($"Последний вставленный ID: {lastInsertedId}");

            string qyery = $" SELECT Orders.OrderID, Customers.FirstName + ' ' + Customers.LastName AS CustomerName, PickupLocation.L_Name + ' ' + PickupLocation.City AS PunktOtpravki, DeliveryLocation.L_Name + ' ' + DeliveryLocation.City AS PunktPriyoma, Orders.OrderDate, Orders.Cost " +
                $" FROM Orders INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID" +
                $" INNER JOIN Locations AS PickupLocation ON Orders.PickupLocationID = PickupLocation.LocationID " +
                $" INNER JOIN Locations AS DeliveryLocation ON Orders.DeliveryLocationID = DeliveryLocation.LocationID where OrderID = {lastInsertedId}";
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
                        });
                    }
                }
                else { MessageBox.Show("Запись не найден!"); }


            }
            LoadDatazakaz();

            string queryD_Status = $"UPDATE Drivers SET D_Status = 'Занять' where DriverID = {IDDriver}";
            SqlCommand command9 = new SqlCommand(queryD_Status, dataBase.getConnection());
            int DCode = command9.ExecuteNonQuery();
            //MessageBox.Show(DCode.ToString() + "Zakaz queryD_Status");


            string queryV_Status = $"UPDATE Vehicle SET V_Status = 'Занять' where VehicleID = {IDVehicle}";
            SqlCommand command8 = new SqlCommand(queryV_Status, dataBase.getConnection());
            int VCode = command8.ExecuteNonQuery();
            MessageBox.Show(VCode.ToString() + "Zakaz VCode");

        }


        public class FreightCalculator
        {
            public static decimal CalculateFreightCost(decimal distance, decimal weight, decimal volume)
            {
                
                decimal distanceCost = (decimal)distance;

                decimal weightSurcharge = (decimal)weight * 0.5m;  // примерная наценка за кг
                decimal volumeSurcharge = (decimal)volume * 0.5m;  // примерная наценка за м³
                decimal totalCost = distanceCost + weightSurcharge + volumeSurcharge;

                return totalCost;
            }

        }



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Poisk.SelectedItem != null)
            {
                string query1 = $"SELECT L_Name FROM Locations where City = '{Poisk.Text}'";
                SqlCommand command1 = new SqlCommand(query1, dataBase.getConnection());
                SqlDataAdapter adapter4 = new SqlDataAdapter(command1);
                DataTable dataTable4 = new DataTable();
                adapter4.Fill(dataTable4);
                name.ItemsSource = dataTable4.DefaultView;
                name.DisplayMemberPath = "L_Name";
            }
        }

        private void Button_Ohcistka(object sender, RoutedEventArgs e)
        {
            zak.Clear();

        }
    }
}
