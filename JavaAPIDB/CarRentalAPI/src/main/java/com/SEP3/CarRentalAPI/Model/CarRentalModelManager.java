package com.SEP3.CarRentalAPI.Model;

import com.SEP3.CarRentalAPI.Persistence.FileHandler;

import java.util.List;

public class CarRentalModelManager implements CarRentalModel
{
    FileHandler fileHandler;
    CarList carList;

    public CarRentalModelManager()
    {
        carList = new CarList();
        fileHandler = new FileHandler();

        carList.generateCars();
        fileHandler.saveCarListToFile(carList);
    }

    @Override
    public List<Car> getAllCars()
    {
        return fileHandler.loadCarListFromFile().getCarList();
    }

    @Override
    public Car addCar(String name, String model)
    {
        return carList.addCar(name, model);
    }

    @Override
    public Car addCar(int id, String name, String model)
    {
        return carList.addCar(id, name, model);
    }


}
