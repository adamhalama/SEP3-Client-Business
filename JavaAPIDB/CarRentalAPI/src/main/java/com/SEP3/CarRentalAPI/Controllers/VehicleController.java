package com.SEP3.CarRentalAPI.Controllers;

import com.SEP3.CarRentalAPI.DBRepository.VehicleRepository;
import com.SEP3.CarRentalAPI.Model.Vehicle;
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
public class VehicleController
{

    @Autowired
    private VehicleRepository repository;

    @GetMapping("/vehicles")
    public List<Vehicle> getAllVehicles()
    {
        return repository.findAll();
    }

    @GetMapping("/vehicles/{id}")
    public ResponseEntity<Vehicle> getVehicleById(@PathVariable(value = "id") Long vehicleId)
            throws ResourceNotFoundException
    {
        Vehicle vehicle = repository.findById(vehicleId)
                .orElseThrow(() -> new ResourceNotFoundException("Employee not found for this id :: " + vehicleId));
        return ResponseEntity.ok().body(vehicle);
    }

    @PostMapping("/vehicles")
    public Vehicle createVehicle(@Valid @RequestBody Vehicle vehicle)
    {
        return repository.save(vehicle);
    }

    @PutMapping("/vehicles/{id}")
    public ResponseEntity<Vehicle> updateVehicle(@PathVariable(value = "id") Long vehicleId,
                                                 @Valid @RequestBody Vehicle vehicleDetails) throws ResourceNotFoundException
    {
        Vehicle vehicle = repository.findById(vehicleId)
                .orElseThrow(() -> new ResourceNotFoundException("Vehicle not found for this id :: " + vehicleId));

        vehicle.setName(vehicleDetails.getName());
        vehicle.setType(vehicleDetails.getType());
        vehicle.setPricePerDay(vehicleDetails.getPricePerDay());
        vehicle.setSeatsCount(vehicleDetails.getSeatsCount());
        vehicle.setAutomatic(vehicleDetails.isAutomatic());
        vehicle.setPowerKw(vehicleDetails.getPowerKw());
        vehicle.setFuelType(vehicleDetails.getFuelType());
        vehicle.setDeposit(vehicleDetails.getDeposit());
        
        final Vehicle updatedVehicle = repository.save(vehicle);
        return ResponseEntity.ok(updatedVehicle);
    }

    @DeleteMapping("/vehicles/{id}")
    public Map<String, Boolean> deleteVehicle(@PathVariable(value = "id") Long vehicleId)
            throws ResourceNotFoundException {
        Vehicle vehicle = repository.findById(vehicleId)
                .orElseThrow(() -> new ResourceNotFoundException("Vehicle not found for this id :: " + vehicleId));

        repository.delete(vehicle);
        Map<String, Boolean> response = new HashMap<>();
        response.put("deleted", Boolean.TRUE);
        return response;
    }

}
