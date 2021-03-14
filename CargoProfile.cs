using System;

namespace Generics_And_Collections
{
    class CargoProfile : Profile
    { 
        public int CargoCapacity
        {
            get;
            set;
        }
        public int Carry
        {
            get;
            set;
        }

        public new void Rout()
        {
            base.Rout();
            Console.WriteLine("to Covoare Ungheni");
        }
        public override string ToString()
        {
            return "cargo";
        }
    }
}
