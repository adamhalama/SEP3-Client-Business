package com.SEP3.CarRentalAPI.Controllers;

import com.SEP3.CarRentalAPI.Model.Car;
import com.SEP3.CarRentalAPI.Model.CarRentalModel;
import com.SEP3.CarRentalAPI.Model.CarRentalModelManager;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.concurrent.atomic.AtomicLong;

@RestController
public class CarController
{

    /*@Autowired
    CarRentalModel carRentalModel;*/

    private static final String templateName = "name=" + "%s";
    private static final String templateModel = "model=" + "%s";
    private final AtomicLong counter = new AtomicLong();


    @GetMapping("/car")
    public Car car(@RequestParam(value = "name", defaultValue = "BMW") String name, @RequestParam(value = "model", defaultValue = "M2 cs") String model)
    {
        return new Car((int)counter.incrementAndGet(), name, model);
//        return new Car(counter.incrementAndGet(), String.format(templateName, name), String.format(templateModel, model));
    }

   /* @GetMapping("/cars")
    public CarList cars()
    {
        CarList carList = new CarList();
        carList.generateCars();
        return carList;
    }*/

    @GetMapping("/cars")
    public ResponseEntity<List<Car>> cars()
    {
        /*CarList carList = new CarList();
        carList.generateCars();
        return  new ResponseEntity<>(carList.getCarList(), HttpStatus.OK);*/

        CarRentalModel carRentalModel = new CarRentalModelManager();

        List<Car> carData = carRentalModel.getAllCars();
        if (!carData.isEmpty())
        {
            return new ResponseEntity<>(carData, HttpStatus.OK);
        } else
        {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }

    }

    @PostMapping("/cars")
    public ResponseEntity<Car> addCar(@RequestBody Car car)
    {
        CarRentalModel carRentalModel = new CarRentalModelManager();
        try
        {
            Car addedCar = carRentalModel.addCar(car.getId(), car.getName(), car.getModel());
            return new ResponseEntity<>(addedCar, HttpStatus.CREATED);
        } catch (Exception e)
        {
            e.printStackTrace();
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

}

