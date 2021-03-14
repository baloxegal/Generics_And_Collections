using System;
using System.Collections;

namespace Generics_And_Collections
{
    class MyGenericCollection<T> : IEnumerable
    {
        const int SIZE = 10;
        int pointer = -1;
        T[] collection;
        int[] sets;
        public MyGenericCollection()
        {
            collection = new T[SIZE];
            sets = new int[collection.Length];
            for(int s = 0; s < sets.Length; s++)
            {
                sets[s] = -1;
            }
        }
        public int Size()
        {
            int count = 0;            
            for(int sn = 0; sn < sets.Length; sn++)
            {
                if (sets[sn] > pointer)
                    count++;
            }            
            return pointer + 1 + count;
        }
        public int ArrayLength()
        {
            return collection.Length;
        }
        public T Get(int i)
        {
            try
            {
                if (i < 0 || i > collection.Length - 1)
                    throw new IndexOutOfRangeException("Error - Specified inex is out of range");
            }
            catch (IndexOutOfRangeException r)
            {
                Console.WriteLine(r);
                return collection[0];
            }
            return collection[i];
        }
        public void Set(int i, T obj)
        {
            try
            {
                if (i < 0 || i > collection.Length - 1)
                    throw new IndexOutOfRangeException("Error - Specified inex is out of range");
            }
            catch (IndexOutOfRangeException r)
            {
                Console.WriteLine(r);
                i = 0;
            }
            collection[i] = obj;
            if(pointer < i)
            {
                for (int s = 0; s < sets.Length * 2; s++)
                {
                    if (s < sets.Length && sets[s] == i)
                        break;
                    else if (s >= sets.Length && sets[s - sets.Length] == -1)
                    {
                        sets[s - sets.Length] = i;
                        break;
                    }
                    if(s == sets.Length * 2 - 1)
                    {
                        int[] newSets = new int[sets.Length * 2];
                        sets.CopyTo(newSets, 0);
                        sets = newSets;
                        sets[sets.Length / 2] = i;
                        for(int z = sets.Length / 2 + 1; z < sets.Length; z++)
                        {
                            sets[z] = -1;
                        }
                        break;
                    }
                }
            }            
        }
        public void Swap(int i, int j)
        {
            var temp = Get(i);
            Set(i, Get(j));
            Set(j, temp);
        }
        public void Swap(T obj_1, T obj_2)
        {
            try
            {
                if (obj_1 is Int32)
                    throw new FormatException("Error - arguments don't can be integer");
            }
            catch(FormatException e)
            {
                Console.WriteLine(e);
                return;
            }
            Swap(FirstIndexOf(obj_1), FirstIndexOf(obj_2));            
        }
        public void Swap(T obj_1, int ind_1, T obj_2, int ind_2)
        {
            try
            {
                if (obj_1 is int)
                    throw new FormatException("Error - arguments don't can be integer");
                if (FirstIndexOf(obj_1) == ind_1 && FirstIndexOf(obj_2) == ind_2)
                    Swap(ind_1, ind_2);
                else
                    throw new ArgumentException("Error - element specified by index doesn't contain specified value");
            }
            catch(ArgumentException a)
            {
                Console.WriteLine(a);
                return;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                return;
            }
        }
        public void Add(T obj)
        {            
            pointer++;
            if(pointer < collection.Length)
            {
                for (int i = 0; i < sets.Length; i++)
                {
                    if (sets[i] == pointer)
                    {
                        pointer++;
                        if (pointer == collection.Length)
                            break;
                        i = 0;
                    }                                       
                }
                if(pointer == collection.Length)
                {
                    T[] newCollection = new T[collection.Length * 2];                    
                    collection.CopyTo(newCollection, 0);
                    collection = newCollection;
                }
                collection[pointer] = obj;
            }            
        }
        public bool Contains(T obj)
        {
            for (int cc = 0; cc < collection.Length; cc++)
                if (collection[cc].Equals(obj))
                    return true;
            return false;
        }
        public int FirstIndexOf(T obj)
        {
            for (int cc = 0; cc < collection.Length; cc++)
                if (collection[cc].Equals(obj))
                    return cc;
            return -1;
        }
        public int LastIndexOf(T obj)
        {
            for (int cc = collection.Length - 1; cc >= 0; cc--)
                if (collection[cc].Equals(obj))
                    return cc;
            return -1;
        }
        public IEnumerator GetEnumerator()
        {
            return collection.GetEnumerator();
        }
    }
}
