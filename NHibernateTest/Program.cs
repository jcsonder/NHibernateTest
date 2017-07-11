using NHibernateTest.Backend.DomainModel;
using NHibernateTest.Backend.Service;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarService();

            // Create data
            Console.WriteLine("--- Save car 1");
            Car sportCar = new SportCar { Name = "Porsche", Model = "356", Color = "silver" };
            sportCar.Owners.Add(new Owner { Name = "Mickey Mouse", Year = 2000, Car = sportCar });
            sportCar.Owners.Add(new Owner { Name = "Roger Rabbit", Year = 2005, Car = sportCar });
            carService.SaveCar(sportCar);
            // Console.WriteLine(sportCar.Drive());

            Console.WriteLine("--- Save car 2");
            Car truck = new Truck { Name = "Ford", Model = "F-350", Color = "blue" };
            truck.Owners.Add(new Owner { Name = "Norbert Ullmann", Year = 2015, Car = truck });
            // Console.WriteLine(truck.Drive());
            carService.SaveCar(truck);

            // load data
            Console.WriteLine("--- load single Car by Id");
            Car loadedTruck = carService.LoadCar(truck.Id);
            Console.WriteLine(loadedTruck.ToString());

            Console.WriteLine("--- load Cars");
            IList<Car> allLoadedCars = carService.LoadCars();
            foreach (Car loadedCar in allLoadedCars)
            {
                Console.WriteLine(loadedCar.ToString());
            }

            Console.WriteLine("--- load Cars in background thread. threadId = {0}", Thread.CurrentThread.ManagedThreadId);
            IList<Car> carsLoadedInWorkerThread = null;
            Task x = Task.Run(() =>
            {
                Console.WriteLine("... in background thread. threadId = {0}", Thread.CurrentThread.ManagedThreadId);
                carsLoadedInWorkerThread = carService.LoadCars();
                Thread.Sleep(10000);
            });

            x.Wait();

            x.ContinueWith(t => 
            {
                Console.WriteLine("... back on calling therad. threadId = {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("carsLoadedInWorkerThread.Count() == {0}", carsLoadedInWorkerThread.Count);
            });

            Console.WriteLine("finish. thread {0}", carsLoadedInWorkerThread.Count);
            Console.ReadLine();
        }   
    }
}
