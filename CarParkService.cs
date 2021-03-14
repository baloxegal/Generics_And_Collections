using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics_And_Collections
{
    class CarParkService<T> where T : Car<Profile, IMoveable>
    {        
        public T[] park;
        public Dictionary<Destination, int> DestinationsDistanceFromBase;        

        public CarParkService(int length)
        {
            park = new T[length];
            DestinationsDistanceFromBase = new Dictionary<Destination, int>();
        }

    }
    public enum Destination { CHISINAU, BALTI, OCNITA, CIMISLIA, TIRASPOL }
}
