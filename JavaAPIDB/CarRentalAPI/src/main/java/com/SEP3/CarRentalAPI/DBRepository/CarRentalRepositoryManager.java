package com.SEP3.CarRentalAPI.DBRepository;

import com.SEP3.CarRentalAPI.DBEntities.Car;
import com.SEP3.CarRentalAPI.DBEntities.CarList;
import com.SEP3.CarRentalAPI.Persistence.FileHandler;
import org.springframework.data.domain.Example;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;

import java.util.List;
import java.util.Optional;

public class CarRentalRepositoryManager 
{
    FileHandler fileHandler;
    CarList carList;

    public CarRentalRepositoryManager()
    {
        carList = new CarList();
        fileHandler = new FileHandler();

        carList.generateCars();
        fileHandler.saveCarListToFile(carList);
    }

    
    public List<Car> getAllCars()
    {
        return fileHandler.loadCarListFromFile().getCarList();
    }

    
    public Car addCar(String name, String model)
    {
        return carList.addCar(name, model);
    }

    
    public Car addCar(long id, String name, String model)
    {
        return carList.addCar(id, name, model);
    }


    
    public List<Car> findAll()
    {
        return null;
    }

    
    public List<Car> findAll(Sort sort)
    {
        return null;
    }

    
    public Page<Car> findAll(Pageable pageable)
    {
        return null;
    }

    
    public List<Car> findAllById(Iterable<Long> longs)
    {
        return null;
    }

    
    public long count()
    {
        return 0;
    }

    
    public void deleteById(Long aLong)
    {

    }

    
    public void delete(Car entity)
    {

    }

    
    public void deleteAllById(Iterable<? extends Long> longs)
    {

    }

    
    public void deleteAll(Iterable<? extends Car> entities)
    {

    }

    
    public void deleteAll()
    {

    }

    
    public <S extends Car> S save(S entity)
    {
        return null;
    }

    
    public <S extends Car> List<S> saveAll(Iterable<S> entities)
    {
        return null;
    }

    
    public Optional<Car> findById(Long aLong)
    {
        return Optional.empty();
    }

    
    public boolean existsById(Long aLong)
    {
        return false;
    }

    
    public void flush()
    {

    }

    
    public <S extends Car> S saveAndFlush(S entity)
    {
        return null;
    }

    
    public <S extends Car> List<S> saveAllAndFlush(Iterable<S> entities)
    {
        return null;
    }

    
    public void deleteAllInBatch(Iterable<Car> entities)
    {

    }

    
    public void deleteAllByIdInBatch(Iterable<Long> longs)
    {

    }

    
    public void deleteAllInBatch()
    {

    }

    /**
     * @param aLong
     * @deprecated
     */
    
    public Car getOne(Long aLong)
    {
        return null;
    }

    
    public Car getById(Long aLong)
    {
        return null;
    }

    
    public <S extends Car> Optional<S> findOne(Example<S> example)
    {
        return Optional.empty();
    }

    
    public <S extends Car> List<S> findAll(Example<S> example)
    {
        return null;
    }

    
    public <S extends Car> List<S> findAll(Example<S> example, Sort sort)
    {
        return null;
    }

    
    public <S extends Car> Page<S> findAll(Example<S> example, Pageable pageable)
    {
        return null;
    }

    
    public <S extends Car> long count(Example<S> example)
    {
        return 0;
    }

    
    public <S extends Car> boolean exists(Example<S> example)
    {
        return false;
    }
}
