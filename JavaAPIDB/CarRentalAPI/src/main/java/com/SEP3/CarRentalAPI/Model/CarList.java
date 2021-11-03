package com.SEP3.CarRentalAPI.Model;

import java.util.ArrayList;

public class CarList
{
    private ArrayList<Car> carList;
    static int incrementor = 0;

    public CarList()
    {
        carList = new ArrayList<>();
    }

    public void generateCars()
    {
        addCar( "BMW", "3er");
        addCar( "BMW", "2er coupe");
        addCar( "Mercedes", "CLS 63");
        addCar( "Mercedes", "A 45");
        addCar( "BMW", "4er Gran Coupe");
    }

    public ArrayList<Car> getCarList()
    {
        return carList;
    }

    public Car addCar(String name, String model)
    {
        incrementor++;
        Car newCar = new Car(incrementor, name, model);
        carList.add(newCar);
        return newCar;
    }

    public Car addCar(int id, String name, String model)
    {
        Car newCar = new Car(id, name, model);
        carList.add(newCar);
        return newCar;
    }
}
