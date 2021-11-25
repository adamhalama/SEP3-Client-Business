package com.SEP3.CarRentalAPI.DBRepository;

import com.SEP3.CarRentalAPI.DBEntities.Car;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface CarRentalRepository
{
    List<Car> getAllCars();
    Car Save(Car car);
    List<Car> findAll();

    Car addCar(String name, String model);

    Car addCar(long id, String name, String model);
}
