package com.SEP3.CarRentalAPI.Model;

import java.util.List;

public interface CarRentalModel
{
    List<Car> getAllCars();
    Car addCar(String name, String model);

    Car addCar(int id, String name, String model);
}
