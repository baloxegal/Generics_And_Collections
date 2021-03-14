using System;

namespace Generics_And_Collections
{
    class CarPark<T> where T : Car<Profile, IMoveable>
    {        
        public T[] park;

        public CarPark(int length)
        {
            park = new T[length];
        }
    }
}
