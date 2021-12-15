using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CarRentalClientServer.Data;
using CarRentalClientServer.Utilities;

namespace CarRentalClientServer.Models
{
    public class ReservationFormatted
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("vehicle")] public Vehicle Vehicle { get; set; }
        [JsonPropertyName("customer")] public Customer Customer { get; set; }
        [JsonPropertyName("employee")] public Employee Employee { get; set; }

        public long VehicleId { get; set; }
        public string VehicleName { get; set; }
        public long CustomerId { get; set; }
        public long EmployeeId { get; set; }
        
        public string EmployeeName { get; set; }

        [JsonPropertyName("securityDeposit")] public int SecurityDeposit { get; set; }
        [JsonPropertyName("dateCreated")] public DateTime DateCreated { get; set; }
        [JsonPropertyName("dateStart")] public DateTime DateStart { get; set; }
        [JsonPropertyName("dateEnd")] public DateTime DateEnd { get; set; }
        
        [JsonPropertyName("allowedKm")] public int AllowedKm { get; set; }
        [JsonPropertyName("paymentAmount")] public float PaymentAmount { get; set; }
        [JsonPropertyName("billDate")] public DateTime BillDate { get; set; }
        [JsonPropertyName("isPaid")] public bool IsPaid { get; set; }

        public ReservationFormatted()
        {
        }

        public ReservationFormatted(long id, Vehicle vehicle, Customer customer, Employee employee, long vehicleId, 
            string vehicleName, long customerId, long employeeId, int securityDeposit, DateTime dateCreated, 
            DateTime dateStart, DateTime dateEnd, int allowedKm, float paymentAmount, DateTime billDate, bool isPaid)
        {
            Id = id;
            Vehicle = vehicle;
            Customer = customer;
            Employee = employee;
            VehicleId = vehicleId;
            VehicleName = vehicleName;
            CustomerId = customerId;
            EmployeeId = employeeId;
            SecurityDeposit = securityDeposit;
            DateCreated = dateCreated;
            DateStart = dateStart;
            DateEnd = dateEnd;
            AllowedKm = allowedKm;
            PaymentAmount = paymentAmount;
            BillDate = billDate;
            IsPaid = isPaid;
        }

        public ReservationFormatted(ReservationFormatted reservationFormatted)
        {
            Id = reservationFormatted.Id;
            Vehicle = reservationFormatted.Vehicle;
            Customer = reservationFormatted.Customer;
            Employee = reservationFormatted.Employee;
            VehicleId = reservationFormatted.VehicleId;
            VehicleName = reservationFormatted.VehicleName;
            CustomerId = reservationFormatted.CustomerId;
            EmployeeId = reservationFormatted.EmployeeId;
            SecurityDeposit = reservationFormatted.SecurityDeposit;
            DateCreated = reservationFormatted.DateCreated;
            DateStart = reservationFormatted.DateStart;
            DateEnd = reservationFormatted.DateEnd;
            AllowedKm = reservationFormatted.AllowedKm;
            PaymentAmount = reservationFormatted.PaymentAmount;
            BillDate = reservationFormatted.BillDate;
            IsPaid = reservationFormatted.IsPaid;
        }

        public ReservationFormatted(Reservation reservation)
        {
            Id = reservation.Id;
            Vehicle = reservation.Vehicle;
            Customer = reservation.Customer;
            Employee = reservation.Employee;
            VehicleId = -1;
            VehicleName = "Not Found";
            CustomerId = -1;
            EmployeeId = -1;
            EmployeeName = "N/A";
            if (reservation.Vehicle != null && reservation.Vehicle.Name != null)
            {
                VehicleId = reservation.Vehicle.Id;
                VehicleName = reservation.Vehicle.Name;
            }
            if (reservation.Customer != null)
                CustomerId = reservation.Customer.Id;
            if (reservation.Employee != null && reservation.Employee.Name != null)
            {
                EmployeeId = reservation.Employee.Id;
                EmployeeName = reservation.Employee.Name;
            }
            SecurityDeposit = reservation.SecurityDeposit;
            DateCreated = TimeConversionUtility.GetDateTime(reservation.DateCreated);
            DateStart = TimeConversionUtility.GetDateTime(reservation.DateStart);
            DateEnd = TimeConversionUtility.GetDateTime(reservation.DateEnd);
            AllowedKm = reservation.AllowedKm;
            PaymentAmount = reservation.PaymentAmount;
            BillDate = TimeConversionUtility.GetDateTime(reservation.BillDate);
            IsPaid = reservation.IsPaid;
        }

        public Reservation ToVanillaReservation()
        {
            return new Reservation()
            {
                Id = Id,
                Vehicle = Vehicle,
                Customer = Customer,
                Employee = Employee,
                SecurityDeposit = SecurityDeposit,
                DateCreated = TimeConversionUtility.DateTimeToUnix(DateCreated),
                DateStart = TimeConversionUtility.DateTimeToUnix(DateStart),
                DateEnd = TimeConversionUtility.DateTimeToUnix(DateEnd),
                AllowedKm = AllowedKm,
                PaymentAmount = PaymentAmount,
                BillDate = TimeConversionUtility.DateTimeToUnix(BillDate),
                IsPaid = IsPaid
            };
        }
        
        public static IList<ReservationFormatted> FormatReservations(IList<Reservation> reservations)
        {
            IList<ReservationFormatted> formattedReservations = new List<ReservationFormatted>();
            foreach (var reservation in reservations)
            {
                formattedReservations.Add(new ReservationFormatted(reservation));
            }

            return formattedReservations;

            // var reservationFormatted = new ReservationFormatted(reservation);
            // reservationFormatted.DateStart.

            //todo find solution for day calculation
        }

        public static int GetDaysBetweenTime(DateTime startTime, DateTime endTime)
        {
            TimeSpan timeSpan = endTime - startTime;
            return (int) Math.Ceiling(timeSpan.TotalDays);
        }
    }
}