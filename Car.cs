using System;

namespace Generics_And_Collections
{
    class Car<T, U> where T : Profile where U : IMoveable
    {
        public T Profile
        {
            get;
            set;
        }
        public U TypeMove
        {
            get;
            set;
        }
        public string Trailer
        {
            get;
            set;
        }
        public int? Wheeles
        {
            get;
            set;
        }
        public Fuel FuelType
        {
            get;
            set;
        }
        public Car()
        {

        }
        public Car(T profile, Fuel fuel)
        {
            Profile = profile;
            FuelType = fuel;
            Console.WriteLine("Super Car Created");
        }
        public Car(T profile, U typeMove)
        {
            Profile = profile;
            TypeMove = typeMove;            
            Console.WriteLine("Super Car Created");
        }
        public Car(T profile, U typeMove, Fuel fuel)
        {
            Profile = profile;
            TypeMove = typeMove;
            FuelType = fuel;
            Console.WriteLine("Super Car Created");
        }
        public Car(T profile, U typeMove, Fuel fuel, String trailer)
        {
            Profile = profile;
            TypeMove = typeMove;
            FuelType = fuel;
            Trailer = trailer;
            Console.WriteLine("Super Car Created");
        }
        public override string ToString()
        {
            return $"Car profile is: {Profile}, and it is {TypeMove}, and fuel type is {FuelType}, and trailer is {Trailer}";
        }        
    }
    public enum Fuel { PETROL, DIESEL, GAS };
}
