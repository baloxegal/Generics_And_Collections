using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics_And_Collections
{
    class CarParkService<T, U, D> where T : Car<Profile, IMoveable> where U : Enum where D : Enum
    {        
        public T[] park;
        public Dictionary<U, int> DestinationsDistanceFromBase;        
        public List<KeyValuePair<T, D>> CarDriversList;
        public HashSet<KeyValuePair<T, D>> CarDriverSet;
        public CarParkService(int length)
        {
            park = new T[length];
            DestinationsDistanceFromBase = new Dictionary<U, int>();
            CarDriversList = new List<KeyValuePair<T, D>>();
            CarDriverSet = new HashSet<KeyValuePair<T, D>>();
        }

    }
    public enum Destination { CHISINAU, BALTI, OCNITA, CIMISLIA, TIRASPOL }
    public enum Driver { PETRICA, VASILICA, VALERICA, TOLICA, SERGICA }
}
