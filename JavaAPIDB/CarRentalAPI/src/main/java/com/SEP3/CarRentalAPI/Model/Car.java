package com.SEP3.CarRentalAPI.Model;

public class Car
{
    private final int id;
    private final String name;
    private final String model;

    public Car(int id, String name, String model)
    {
        this.id = id;
        this.name = name;
        this.model = model;
    }

    public int getId()
    {
        return id;
    }

    public String getName()
    {
        return name;
    }

    public String getModel()
    {
        return model;
    }
}
