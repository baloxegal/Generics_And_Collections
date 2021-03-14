using System;

namespace Generics_And_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            IFlyable typeFly = new Fly();
            Profile cargoProfile = new CargoProfile();
            Car<Profile, IMoveable> car1 = new Car<Profile, IMoveable>(cargoProfile, typeFly);

            car1.TypeMove.MoveRight();
            ((IFlyable)car1.TypeMove).MoveUp();
            var a = car1.Profile as CargoProfile;
            a.CargoCapacity = 5000;
            a.Carry = 4900;
            a.Rout();
            
            IMoveable typeMove = new Move();
            Profile passangerProfile = new PassangerProfile();
            Car<Profile, IMoveable> car2 = new Car<Profile, IMoveable>(passangerProfile, typeMove);

            car2.TypeMove.MoveRight();
            car2.TypeMove.MoveLeft();           
            ((PassangerProfile)car2.Profile).Seats = 50;
            ((PassangerProfile)car2.Profile).Tickets = 40;
            ((PassangerProfile)car2.Profile).Rout();
            
            CarPark<Car<Profile, IMoveable>> carPark = new CarPark<Car<Profile, IMoveable>>(10);

            carPark.park[0] = car1;           
            carPark.park[1] = car2;
            
            for (var i = 2; i < carPark.park.Length; i++)
            {
                if(i % 2 == 0 && (i != 6 && i != 8))
                    carPark.park[i] = new Car<Profile, IMoveable>(cargoProfile, typeFly);
                else if (i == 6 || i == 8)
                    carPark.park[i] = new Car<Profile, IMoveable>(new CargoPassangerProfile(), typeFly);
                else
                    carPark.park[i] = new Car<Profile, IMoveable>(passangerProfile, typeMove);
            }
            
            foreach (var c in carPark.park)
            {
                Console.WriteLine(c);
            }

            var t1 = carPark.park[5];
            var t2 = carPark.park[6];

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
