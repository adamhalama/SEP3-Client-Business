package com.SEP3.CarRentalAPI.Model;

import javax.persistence.*;

@Entity
@Table(name = "reservation")
public class Reservation
{
    private long id;
    private int vehicleId;
    private int customerId;
    private int employeeId;
    private int securityDeposit;
    private long dateCreated;
    private long dateStart;
    private long dateEnd;
    private int allowedKm;
    private int paymentAmount;
    private long billDate;
    private boolean isPaid;


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public long getId() {
        return id;
    }
    public void setId(long id) {
        this.id = id;
    }

    @Column(name = "vehicle_id", nullable = false)
    public int getVehicleId() {
        return vehicleId;
    }
    public void setVehicleId(int vehicleId) {
        this.vehicleId = vehicleId;
    }

    @Column(name = "customer_id", nullable = false)
    public int getCustomerId() {
        return customerId;
    }
    public void setCustomerId(int customerId) {
        this.customerId = customerId;
    }

    @Column(name = "employee_id", nullable = true)
    public int getEmployeeId() {
        return employeeId;
    }
    public void setEmployeeId(int employeeId) {
        this.employeeId = employeeId;
    }
    
    @Column(name = "security_deposit", nullable = false)
    public int getSecurityDeposit() {
        return securityDeposit;
    }
    public void setSecurityDeposit(int securityDeposit) {
        this.securityDeposit = securityDeposit;
    }
    
    @Column(name = "date_created", nullable = false)
    public long getDateCreated() {
        return dateCreated;
    }
    public void setDateCreated(long dateCreated) {
        this.dateCreated = dateCreated;
    }

    @Column(name = "date_start", nullable = false)
    public long getDateStart() {
        return dateStart;
    }
    public void setDateStart(long dateStart) {
        this.dateStart = dateStart;
    }

    @Column(name = "date_end", nullable = false)
    public long getDateEnd() {
        return dateCreated;
    }
    public void setDateEnd(long dateCreated) {
        this.dateEnd = dateCreated;
    }

    @Column(name = "allowed_km", nullable = false)
    public int getAllowedKm() {
        return allowedKm;
    }
    public void setAllowedKm(int allowedKm) {
        this.allowedKm = allowedKm;
    }

    @Column(name = "payment_amount", nullable = false)
    public int getPaymentAmount() {
        return paymentAmount;
    }
    public void setPaymentAmount(int paymentAmount) {
        this.paymentAmount = paymentAmount;
    }

    @Column(name = "bill_date", nullable = false)
    public long getBillDate() {
        return billDate;
    }
    public void setBillDate(long billDate) {
        this.billDate = billDate;
    }

    @Column(name = "isPaid", nullable = false)
    public boolean isPaid() {
        return isPaid;
    }
    public void setPaid(boolean isPaid) {
        this.isPaid = isPaid;
    }

    @Override
    public String toString()
    {
        return "Reservation{" +
                "id=" + id +
                ", vehicleId=" + vehicleId +
                ", customerId=" + customerId +
                ", employeeId=" + employeeId +
                ", securityDeposit=" + securityDeposit +
                ", dateCreated=" + dateCreated +
                ", dateStart=" + dateStart +
                ", dateEnd=" + dateEnd +
                ", allowedKm=" + allowedKm +
                ", paymentAmount=" + paymentAmount +
                ", billDate=" + billDate +
                ", isPaid=" + isPaid +
                '}';
    }
}
