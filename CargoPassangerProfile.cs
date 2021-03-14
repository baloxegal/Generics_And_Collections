using System;

namespace Generics_And_Collections
{
    class CargoPassangerProfile : Profile
    {
        public CargoProfile CargoProfile
        {
            get;
            set;
        }
        public PassangerProfile PassangerProfile
        {
            get;
            set;
        }

        public new void Rout()
        {
            base.Rout();
            Console.WriteLine("to Bucuresti airport with Cargo");
        }
        public override string ToString()
        {
            return "cargo - passanger";
        }
    }
}
