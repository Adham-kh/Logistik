using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistik
{
    internal class Tables
    {
        public class Customer
        {
            public int CustomerID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string C_Address { get; set; }
        }
        public class Vehicle
        {
            public int VehicleID { get; set; }
            public string LicensePlate { get; set; }
            public string Model { get; set; }
            public decimal Capacity { get; set; }
            public string V_Status { get; set; }
        }
        public class Driver
        {
            public int DriverID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string D_Status { get; set; }
        }
        public class Location
        {
            public int LocationID { get; set; }
            public string L_Name { get; set; }
            public string L_Address { get; set; }
            public string City { get; set; }
            public string L_State { get; set; }
            public string ZipCode { get; set; }
        }
        public class OrderStatus
        {
            public int StatusID { get; set; }
            public string StatusDescription { get; set; }
        }
        public class Route
        {
            public int RouteID { get; set; }
            public int StartLocationID { get; set; }
            public int EndLocationID { get; set; }
            public decimal Distance { get; set; }
            public decimal EstimatedTime { get; set; }
        }
        public class Order
        {
            public int OrderID { get; set; }
            public int CustomerID { get; set; }
            public int VehicleID { get; set; }
            public int DriverID { get; set; }
            public int PickupLocationID { get; set; }
            public int DeliveryLocationID { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime PickupDate { get; set; }
            public DateTime DeliveryDate { get; set; }
            public int O_Status { get; set; }
        }
        public class Zakaz 
        {
            public int OrderID { get; set; }
            public string FirstName { get; set; }
            public string LocationIDO { get; set; }
            public string LocationIDN {  get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime PriyomDate { get; set; }
            public decimal  StatusDescription {  get; set; }
            public string StatusDescrip {  get; set; }
        }


    }
}
