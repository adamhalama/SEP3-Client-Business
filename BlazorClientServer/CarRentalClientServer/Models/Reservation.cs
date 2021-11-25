namespace CarRentalClientServer.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
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