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

            Console.WriteLine("--- Save car 1");
            Car car = new SportCar("Porsche", "356", "silver");
            Console.WriteLine(car.Drive());
            carService.SaveCar(car);

            Console.WriteLine("--- Save car 2");
            Car truck = new Truck("Ford", "F-350", "blue");
            Console.WriteLine(truck.Drive());
            carService.SaveCar(truck);

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
