using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace Logistik
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        ConnectDB dataBase = new ConnectDB();
        public Page3()
        {
            InitializeComponent();
            //LoadOrderDataFromDatabase();
            //CreateChart();
        }
        private List<OrderData> orderDataList = new List<OrderData>();
       

        public class OrderData
        {
            public DateTime OrderMonth { get; set; }
            public int OrderCount { get; set; }
            public decimal TotalCost { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadOrderDataFromDatabase();
            CreateChart();
        }

        private void LoadOrderDataFromDatabase()
        {
            string query = "SELECT FORMAT(OrderDate, 'yyyy-MM') AS OrderMonth, COUNT(*) AS OrderCount, SUM(Cost) AS TotalCost FROM Orders GROUP BY FORMAT(OrderDate, 'yyyy-MM') ORDER BY OrderMonth";

            
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConnection();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    orderDataList.Add(new OrderData
                    {
                        OrderMonth = DateTime.Parse(reader.GetString(0)),
                        OrderCount = reader.GetInt32(1),
                        TotalCost = reader.GetDecimal(2)
                    });
                }
                dataGrid.ItemsSource = orderDataList;
            }
            

            MessageBox.Show($"Data loaded successfully. Total records: {orderDataList.Count}");
        }

        private void CreateChart()
        {
            if (orderDataList.Count == 0)
            {
                MessageBox.Show("No data available to display.");
                return;
            }

            var plotModel = new PlotModel { Title = "Ежемесячный анализ заказов и доходов" };

            var orderSeries = new LineSeries
            {
                Title = "Заказы",
                MarkerType = MarkerType.Circle
            };

            var costSeries = new LineSeries
            {
                Title = "Доход",
                MarkerType = MarkerType.Square
            };

            foreach (var data in orderDataList)
            {
                orderSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.OrderMonth), data.OrderCount));
                costSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.OrderMonth), (double)data.TotalCost));
            }

            plotModel.Series.Add(orderSeries);
            plotModel.Series.Add(costSeries);

            var dateAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "yyyy-MM",
                Title = "Месяц",
                IntervalType = DateTimeIntervalType.Months,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };

            var orderAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Количество заказов",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };

            var revenueAxis = new LinearAxis
            {
                Position = AxisPosition.Right,
                Title = "Доход",
                Key = "Ось дохода",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };

            plotModel.Axes.Add(dateAxis);
            plotModel.Axes.Add(orderAxis);
            plotModel.Axes.Add(revenueAxis);

            costSeries.YAxisKey = "Ось дохода";

            plotView.Model = plotModel;
            MessageBox.Show("Диаграмма успешно создана");
        }

    }
}
