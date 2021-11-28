package com.SEP3.CarRentalAPI.Controllers;

import com.SEP3.CarRentalAPI.DBRepository.ReservationRepository;
import com.SEP3.CarRentalAPI.Model.Reservation;
import com.SEP3.CarRentalAPI.exception.ResourceNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/api")
public class ReservationController
{
    @Autowired
    private ReservationRepository repository;

    @GetMapping("/reservations")
    public List<Reservation> getAllReservations() {
        return repository.findAll();
    }

    @GetMapping("/reservations/{id}")
    public ResponseEntity<Reservation> getReservationById(@PathVariable(value = "id") Long reservationId)
            throws ResourceNotFoundException
    {
        Reservation reservation = repository.findById(reservationId)
                .orElseThrow(() -> new ResourceNotFoundException("Reservation not found for this id :: " + reservationId));
        return ResponseEntity.ok().body(reservation);
    }

    @PostMapping("/reservations")
    public Reservation createReservation(@Valid @RequestBody Reservation reservation) {
        return repository.save(reservation);
    }

    @PutMapping("/reservations/{id}")
    public ResponseEntity<Reservation> updateReservation(@PathVariable(value = "id") Long reservationId,
                                                   @Valid @RequestBody Reservation reservationDetails) throws ResourceNotFoundException {
        Reservation reservation = repository.findById(reservationId)
                .orElseThrow(() -> new ResourceNotFoundException("Reservation not found for this id :: " + reservationId));

        reservation.setVehicleId(reservationDetails.getVehicleId());
        reservation.setCustomerId(reservationDetails.getCustomerId());
        reservation.setEmployeeId(reservationDetails.getEmployeeId());
        reservation.setSecurityDeposit(reservationDetails.getSecurityDeposit());
        reservation.setDateCreated(reservationDetails.getDateCreated());
        reservation.setDateStart(reservationDetails.getDateStart());
        reservation.setDateEnd(reservationDetails.getDateEnd());
        reservation.setAllowedKm(reservationDetails.getAllowedKm());
        reservation.setPaymentAmount(reservationDetails.getPaymentAmount());
        reservation.setBillDate(reservationDetails.getBillDate());
        reservation.setPaid(reservationDetails.isPaid());
        final Reservation updatedReservation = repository.save(reservation);
        return ResponseEntity.ok(updatedReservation);
    }

    @DeleteMapping("/reservations/{id}")
    public Map<String, Boolean> deleteReservation(@PathVariable(value = "id") Long reservationId)
            throws ResourceNotFoundException {
        Reservation reservation = repository.findById(reservationId)
                .orElseThrow(() -> new ResourceNotFoundException("Reservation not found for this id :: " + reservationId));

        repository.delete(reservation);
        Map<String, Boolean> response = new HashMap<>();
        response.put("deleted", Boolean.TRUE);
        return response;
    }
}
