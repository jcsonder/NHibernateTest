using NHibernateTest.Backend.DomainModel;
using NHibernateTest.Backend.Service;
using System;
using System.Collections.Generic;

namespace NHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarService();

            // Create data
            Console.WriteLine("### CREATE NEW DATA");
            Console.WriteLine("--- Save sportCar");
            Car sportCar = new SportCar { Name = "Porsche", Model = "356", Color = "silver" };

            Owner owner1 = new Owner { Name = "Mickey Mouse", Year = 2000, Car = sportCar };
            owner1.Parameters.Add(new Parameter { Name = "param1" });

            sportCar.Owners.Add(owner1);
            sportCar.Owners.Add(new Owner { Name = "Roger Rabbit", Year = 2005, Car = sportCar });
            carService.SaveCar(sportCar);

            Console.WriteLine("--- Save truck");
            Car truck = new Truck { Name = "Ford", Model = "F-350", Color = "blue" };
            truck.Owners.Add(new Owner { Name = "Norbert Ullmann", Year = 2015, Car = truck });
            carService.SaveCar(truck);

            // load data
            Console.WriteLine();
            Console.WriteLine("### LOAD DATA");
            Console.WriteLine("--- load single Car by Id: Id={0}", truck.Id);
            Car loadedTruck = carService.LoadCar(truck.Id);
            Console.WriteLine(loadedTruck.ToString());

            Console.WriteLine();
            Console.WriteLine("--- load all Cars of all types");
            IList<Car> allLoadedCars = carService.LoadCars();
            foreach (Car loadedCar in allLoadedCars)
            {
                Console.WriteLine(loadedCar.ToString());
                ////Console.WriteLine(loadedCar.Drive());
            }

            Console.WriteLine();
            Console.WriteLine("press any key to delete sport car: the two owners should be removed too!");
            Console.ReadLine();
            carService.DeleteCar(sportCar.Id);


            Console.WriteLine();
            Console.WriteLine("press any key to end");
            Console.ReadLine();
        }   

        private void TplTests()
        {
            ////Console.WriteLine("--- load Cars in background thread. threadId = {0}", Thread.CurrentThread.ManagedThreadId);
            ////IList<Car> carsLoadedInWorkerThread = null;
            ////Task x = Task.Run(() =>
            ////{
            ////    Console.WriteLine("... in background thread. threadId = {0}", Thread.CurrentThread.ManagedThreadId);
            ////    carsLoadedInWorkerThread = carService.LoadCars();
            ////    Thread.Sleep(10000);
            ////});

            ////x.Wait();

            ////x.ContinueWith(t => 
            ////{
            ////    Console.WriteLine("... back on calling therad. threadId = {0}", Thread.CurrentThread.ManagedThreadId);
            ////    Console.WriteLine("carsLoadedInWorkerThread.Count() == {0}", carsLoadedInWorkerThread.Count);
            ////});

            ////Console.WriteLine("finish. thread {0}", carsLoadedInWorkerThread.Count);
        }
    }
}
