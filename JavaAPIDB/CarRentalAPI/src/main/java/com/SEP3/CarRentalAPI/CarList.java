package com.SEP3.CarRentalAPI;

import java.util.ArrayList;

public class CarList
{
    private ArrayList<Car> carList;

    public CarList()
    {
        carList = new ArrayList<>();
    }

    public void generateCars()
    {
        carList.add(new Car(1, "BMW", "3er"));
        carList.add(new Car(2, "BMW", "2er coupe"));
        carList.add(new Car(3, "Mercedes", "CLS 63"));
        carList.add(new Car(4, "Mercedes", "A 45"));
        carList.add(new Car(5, "BMW", "4er Gran Coupe"));
    }

    public ArrayList<Car> getCarList()
    {
        return carList;
    }
}
