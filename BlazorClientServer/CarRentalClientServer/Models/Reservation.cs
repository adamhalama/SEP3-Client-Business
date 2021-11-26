namespace CarRentalClientServer.Models
{
    public class Reservation
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public long CustomerId { get; set; }
        public long EmployeeId { get; set; }
        public int SecurityDeposit { get; set; }
        public long DateCreated { get; set; }
        public long DateStart { get; set; }
        public long DateEnd { get; set; }
        public int AllowedKm { get; set; }
        public int PaymentAmount { get; set; }
        public long BillDate { get; set; }
        public bool IsPaid { get; set; }
        
    }
}