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
        public Car()
        {

        }
        public Car(T profile)
        {
            Profile = profile;
        }
        public Car(T profile, U typeMove)
        {
            Profile = profile;
            TypeMove = typeMove;
            Console.WriteLine("Super Car Created");
        }
        public override string ToString()
        {
            return $"Car profile is: {Profile}, and it is {TypeMove}";
        }

    }    
}
