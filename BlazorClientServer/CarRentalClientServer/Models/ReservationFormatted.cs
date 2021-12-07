using System;
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
        [JsonPropertyName("securityDeposit")] public int SecurityDeposit { get; set; }
        [JsonPropertyName("dateCreated")] public DateTime DateCreated { get; set; }
        [JsonPropertyName("dateStart")] public DateTime DateStart { get; set; }
        [JsonPropertyName("dateEnd")] public DateTime DateEnd { get; set; }
        [JsonPropertyName("allowedKm")] public int AllowedKm { get; set; }
        [JsonPropertyName("paymentAmount")] public float PaymentAmount { get; set; }
        [JsonPropertyName("billDate")] public DateTime BillDate { get; set; }
        [JsonPropertyName("isPaid")] public bool IsPaid { get; set; }

        public ReservationFormatted(Reservation reservation)
        {
            Id = reservation.Id;
            Vehicle = reservation.Vehicle;
            Customer = reservation.Customer;
            Employee = reservation.Employee;
            SecurityDeposit = reservation.SecurityDeposit;
            DateCreated = DateTimeConversions.GetDateTime(reservation.DateCreated);
            DateStart = DateTimeConversions.GetDateTime(reservation.DateStart);
            DateEnd = DateTimeConversions.GetDateTime(reservation.DateEnd);
            AllowedKm = reservation.AllowedKm;
            PaymentAmount = reservation.PaymentAmount;
            BillDate = DateTimeConversions.GetDateTime(reservation.BillDate);
            IsPaid = reservation.IsPaid;
        }
    }
}