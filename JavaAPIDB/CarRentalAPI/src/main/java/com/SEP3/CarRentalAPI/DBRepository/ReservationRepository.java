package com.SEP3.CarRentalAPI.DBRepository;

import com.SEP3.CarRentalAPI.Model.Reservation;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ReservationRepository extends JpaRepository<Reservation, Long>
{
}
