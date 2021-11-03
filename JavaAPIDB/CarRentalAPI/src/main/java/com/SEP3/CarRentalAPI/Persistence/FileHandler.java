package com.SEP3.CarRentalAPI.Persistence;

import com.SEP3.CarRentalAPI.Model.CarList;

import java.io.*;

public class FileHandler
{

    private CarList carList;

    public CarList loadCarListFromFile() {
        carList = new CarList();
        String filename = "CarList.bin";
        ObjectInputStream in = null;

        try
        {
            File file = new File(filename);
            FileInputStream fis = new FileInputStream(file);
            in = new ObjectInputStream(fis);

            try
            {
                carList = (CarList) in.readObject();
            }
            catch (InvalidClassException e)
            {
                System.out.print("\nThe CarList.bin contains an outdated class. You need to delete the .bin data\n" +
                        "run the program again and fill the list from the start.\n" +
                        "Alternatively revert the changes in the model classes.\n");
            }
            catch (Exception e)
            {
                e.printStackTrace();
            }
        }
        catch (EOFException e)
        {
            System.out.print("The file is empty");
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
        finally
        {
            try
            {
                in.close();
            }
            catch (NullPointerException e)
            {
                System.out.println(", error while closing, because the file is empty.");
            }
            catch (IOException e)
            {
                e.printStackTrace();
            }
        }
        System.out.println("reading from : " + filename +
                " complete");
        return carList;
    }


    public void saveCarListToFile(CarList carList)
    {
        String filename = "CarList.bin";

        ObjectOutputStream out = null;

        try {
            File file = new File(filename);
            FileOutputStream fos = new FileOutputStream(file);
            out = new ObjectOutputStream(fos);

            out.writeObject(carList);
        }
        catch (IOException e)
        {
            System.out.println("did not save to - " + filename);
        }
        finally
        {
            try
            {
                out.close();
            }
            catch (IOException e)
            {
                e.printStackTrace();
            }
        }
        System.out.println("saving to : " + filename +
                " complete");
    }

}
