using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CarRentalClientServer.Data;

namespace CarRentalClientServer.Models
{
    public class ReservationFormatted
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("vehicle")] public Vehicle Vehicle { get; set; }
        [JsonPropertyName("customer")] public Customer Customer { get; set; }
        [JsonPropertyName("employee")] public Employee Employee { get; set; }

        public string VehicleNameAndId { get; set; }
        public string CustomerNameAndId { get; set; }
        public string EmployeeNameAndId { get; set; }

        [JsonPropertyName("securityDeposit")] public int SecurityDeposit { get; set; }
        [JsonPropertyName("dateCreated")] public DateTime DateCreated { get; set; }
        [JsonPropertyName("dateStart")] public DateTime DateStart { get; set; }
        [JsonPropertyName("dateEnd")] public DateTime DateEnd { get; set; }
        [JsonPropertyName("allowedKm")] public int AllowedKm { get; set; }
        [JsonPropertyName("paymentAmount")] public float PaymentAmount { get; set; }
        [JsonPropertyName("billDate")] public DateTime BillDate { get; set; }
        [JsonPropertyName("isPaid")] public bool IsPaid { get; set; }

        public ReservationFormatted(long id, Vehicle vehicle, Customer customer, Employee employee, string vehicleNameAndId, string customerNameAndId, string employeeNameAndId, int securityDeposit, DateTime dateCreated, DateTime dateStart, DateTime dateEnd, int allowedKm, float paymentAmount, DateTime billDate, bool isPaid)
        {
            Id = id;
            Vehicle = vehicle;
            Customer = customer;
            Employee = employee;
            VehicleNameAndId = vehicleNameAndId;
            CustomerNameAndId = customerNameAndId;
            EmployeeNameAndId = employeeNameAndId;
            SecurityDeposit = securityDeposit;
            DateCreated = dateCreated;
            DateStart = dateStart;
            DateEnd = dateEnd;
            AllowedKm = allowedKm;
            PaymentAmount = paymentAmount;
            BillDate = billDate;
            IsPaid = isPaid;
        }

        public ReservationFormatted(Reservation reservation)
        {
            Id = reservation.Id;
            Vehicle = reservation.Vehicle;
            Customer = reservation.Customer;
            Employee = reservation.Employee;
            VehicleNameAndId = "Not Found";
            CustomerNameAndId = "Not Found";
            EmployeeNameAndId = "Not Found";
            if (reservation.Vehicle != null && reservation.Vehicle.Name != null)
                VehicleNameAndId = " #" + reservation.Vehicle.Id + reservation.Vehicle.Name;
            
            if (reservation.Customer != null && reservation.Customer.Name != null)
                CustomerNameAndId = " #" + reservation.Customer.Id + reservation.Customer.Name;
            
            if (reservation.Employee != null && reservation.Employee.Name != null)
                EmployeeNameAndId = " #" + reservation.Employee.Id + reservation.Employee.Name;
            SecurityDeposit = reservation.SecurityDeposit;
            DateCreated = DateTimeConversions.GetDateTime(reservation.DateCreated);
            DateStart = DateTimeConversions.GetDateTime(reservation.DateStart);
            DateEnd = DateTimeConversions.GetDateTime(reservation.DateEnd);
            AllowedKm = reservation.AllowedKm;
            PaymentAmount = reservation.PaymentAmount;
            BillDate = DateTimeConversions.GetDateTime(reservation.BillDate);
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
                DateCreated = DateTimeConversions.DateTimeToUnix(DateCreated),
                DateStart = DateTimeConversions.DateTimeToUnix(DateStart),
                DateEnd = DateTimeConversions.DateTimeToUnix(DateEnd),
                AllowedKm = AllowedKm,
                PaymentAmount = PaymentAmount,
                BillDate = DateTimeConversions.DateTimeToUnix(BillDate),
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
    }
}