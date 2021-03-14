using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics_And_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            IFlyable typeFly = new Fly();
            Profile cargoProfile = new CargoProfile();
            Car<Profile, IMoveable> car1 = new Car<Profile, IMoveable>(cargoProfile, typeFly, Fuel.DIESEL, "Big Trailer");
            car1.Registry = "CVB 825";

            //NULLABLE
            car1.Wheeles = null;
            Console.WriteLine($"It is a example of NULLABLE: Wheels = {car1.Wheeles ?? 0}");
            
            car1.Wheeles = 4;
            Console.WriteLine($"It is a example of NULLABLE: Wheels = {car1.Wheeles ?? 0}");
            
            var w = car1.Wheeles;
            Console.WriteLine($"It is a example of NULLABLE: Wheels = {w ?? 0}");

            car1.Wheeles = null;
            w = null;
            int wl = car1.Wheeles ?? w ?? 10;
            Console.WriteLine($"It is a example of NULLABLE: Wheels = {wl}");

            int zx;
            if (car1.Wheeles.HasValue)
                zx = (int)car1.Wheeles;
            Console.WriteLine($"It is a example of NULLABLE: Wheels = {(car1.Wheeles.HasValue ? car1.Wheeles : -1)}");

            int? wls = car1.Wheeles;
            Console.WriteLine($"It is a example of NULLABLE: Wheels = {wls ?? -1000}");
            Console.WriteLine("=============================================");

            //USE GENERICS
            car1.TypeMove.MoveRight();
            ((IFlyable)car1.TypeMove).MoveUp();
            var a = car1.Profile as CargoProfile;
            a.CargoCapacity = 5000;
            a.Carry = 4900;
            a.Rout();
            
            IMoveable typeMove = new Move();
            Profile passangerProfile = new PassangerProfile();
            Car<Profile, IMoveable> car2 = new Car<Profile, IMoveable>(passangerProfile, typeMove, Fuel.PETROL);
            car2.Registry = "CMU 999";

            car2.TypeMove.MoveRight();
            car2.TypeMove.MoveLeft();           
            ((PassangerProfile)car2.Profile).Seats = 50;
            ((PassangerProfile)car2.Profile).Tickets = 40;
            ((PassangerProfile)car2.Profile).Rout();
            
            CarParkService<Car<Profile, IMoveable>, Destination, Driver> carPark = new CarParkService<Car<Profile, IMoveable>, Destination, Driver>(10);

            carPark.park[0] = car1;           
            carPark.park[1] = car2;
                        
            for (var i = 2; i < carPark.park.Length; i++)
            {
                if(i % 2 == 0 && (i != 6 && i != 8))
                    carPark.park[i] = new Car<Profile, IMoveable>(cargoProfile, typeFly, Fuel.DIESEL, "Big Trailer");
                else if (i == 6 || i == 8)
                    carPark.park[i] = new Car<Profile, IMoveable>(new CargoPassangerProfile(), typeFly, Fuel.GAS, "Small Trailer");
                else
                    carPark.park[i] = new Car<Profile, IMoveable>(passangerProfile, typeMove, Fuel.PETROL);
            }           

            foreach (var c in carPark.park)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("=============================================");

            //DICTIONARY, LIST AND SET
            carPark.DestinationsDistanceFromBase.Add(Destination.BALTI, 150);
            carPark.DestinationsDistanceFromBase.Add(Destination.OCNITA, 240);
            carPark.DestinationsDistanceFromBase.Add(Destination.CIMISLIA, 75);
            foreach (var d in carPark.DestinationsDistanceFromBase)
            {
                Console.WriteLine($"Distance from Chisinau to {d.Key} is a {d.Value} km");
            }
            Console.WriteLine("=============================================");

            carPark.CarDriversList.Add(KeyValuePair.Create<Car<Profile, IMoveable>, Driver>(car1, Driver.VALERICA));
            carPark.CarDriversList.Add(KeyValuePair.Create<Car<Profile, IMoveable>, Driver>(car2, Driver.TOLICA));
            
            foreach(var l in carPark.CarDriversList)
                Console.WriteLine($"It is cars/drivers list {l.Key.Registry ?? "NULL"} : {l.Value}");
            Console.WriteLine("=============================================");

            carPark.CarDriverSet.Add(KeyValuePair.Create<Car<Profile, IMoveable>, Driver>(car1, Driver.VALERICA));
            carPark.CarDriverSet.Add(KeyValuePair.Create<Car<Profile, IMoveable>, Driver>(car2, Driver.TOLICA));
            var s = carPark.CarDriverSet.Add(carPark.CarDriversList.ElementAt(0));
            Console.WriteLine(s);

            foreach (var l in carPark.CarDriverSet)
                Console.WriteLine($"It is cars/drivers set {l.Key.Registry ?? "NULL"} : {l.Value}");
            Console.WriteLine("=============================================");

            //COMPARE
            Car<Profile, IMoveable> car3 = new Car<Profile, IMoveable>(cargoProfile, typeFly, Fuel.DIESEL, "Big Trailer");
            
            Console.WriteLine(car1.Equals(car2));
            Console.WriteLine(car1.CompareTo(car2) == 0 ? "True" : "False");//Compare by FuelType
            Console.WriteLine(Car<Profile, IMoveable>.myComparator.Compare(car1, car2) == 0 ? "True" : "False");// Compare by custom Comparator
            Console.WriteLine(Car<Profile, IMoveable>.myComparator.Equals(car1, car2));// Compare by custom EqualityComparator
            Console.WriteLine("=============================================");
            Console.WriteLine(car1.Equals(car3));
            Console.WriteLine(car1.CompareTo(car3) == 0 ? "True" : "False");
            Console.WriteLine(Car<Profile, IMoveable>.myComparator.Compare(car1, car3) == 0 ? "True" : "False");
            Console.WriteLine(Car<Profile, IMoveable>.myComparator.Equals(car1, car3));
            Console.WriteLine("=============================================");
            Console.WriteLine(car2.Equals(car3));
            Console.WriteLine(car2.CompareTo(car3) == 0 ? "True" : "False");
            Console.WriteLine(Car<Profile, IMoveable>.myComparator.Compare(car2, car3) == 0 ? "True" : "False");
            Console.WriteLine(Car<Profile, IMoveable>.myComparator.Equals(car2, car3));
            Console.WriteLine("=============================================");

            //MY GENERIC COLLECTION CLASS
            MyGenericCollection<int> myCollection = new MyGenericCollection<int>();

            myCollection.Set(9, 56);
            myCollection.Set(5, 26);

            for (int i = 0; i < 10; i++)
            {
                myCollection.Add(new Random().Next(0, 20));
            }
            foreach (var m in myCollection)
            {
                Console.WriteLine(m);
            }
            Console.WriteLine("=============================================");
            myCollection.Set(18, 21);
            myCollection.Set(15, 97);
            foreach (var m in myCollection)           
                Console.WriteLine(m);
            Console.WriteLine("=============================================");
            Console.WriteLine(myCollection.Size());
            Console.WriteLine(myCollection.ArrayLength());
            Console.WriteLine("=============================================");
            Console.WriteLine(myCollection.Get(5));
            Console.WriteLine(myCollection.Get(9));
            Console.WriteLine(myCollection.Get(15));
            Console.WriteLine(myCollection.Get(18));
            Console.WriteLine("=============================================");
            myCollection.Swap(9, 5);
            myCollection.Swap(18, 15);
            Console.WriteLine(myCollection.Get(5));
            Console.WriteLine(myCollection.Get(9));            
            Console.WriteLine(myCollection.Get(15));
            Console.WriteLine(myCollection.Get(18));
            Console.WriteLine("=============================================");            
        }
    }
}
