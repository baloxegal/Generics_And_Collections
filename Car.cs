using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics_And_Collections
{
    class Car<T, U> : IComparable where T : Profile where U : IMoveable
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
        public int? Wings
        {
            get;
            set;
        }
        public string Registry
        {
            get;
            set;
        }
        public Fuel FuelType
        {
            get;
            set;
        }
        public static MyComparator myComparator = new MyComparator();
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
            return $"Car profile is: {Profile}, and it is {TypeMove}, and fuel type is {FuelType}, and trailer is {Trailer ?? "NULL"}";
        }

        public int CompareTo(object obj)
        {
            var c = obj as Car<Profile, IMoveable>;
            return FuelType.CompareTo(c.FuelType);
        }        
    }
    public enum Fuel { PETROL, DIESEL, GAS };

    class MyComparator : IComparer, IEqualityComparer
    {
        public int Compare(object x, object y)
        {
            var c = x as Car<Profile, IMoveable>;
            var d = y as Car<Profile, IMoveable>;
            if (c.Profile.Equals(d.Profile) && c.TypeMove.Equals(d.TypeMove) && c.FuelType.Equals(d.FuelType))
                return 0;
            else
                return -1;
        }
        public new bool Equals(object x, object y)
        {
            var c = x as Car<Profile, IMoveable>;
            var d = y as Car<Profile, IMoveable>;
            if (c.Profile.Equals(d.Profile) && c.TypeMove.Equals(d.TypeMove) && c.FuelType.Equals(d.FuelType))
                return true;
            else
                return false;
        }
        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
