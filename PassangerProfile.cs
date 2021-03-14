using System;

namespace Generics_And_Collections
{
    class PassangerProfile : Profile
    {
        public int Seats
        {
            get;
            set;
        }
        public int Tickets
        {
            get;
            set;
        }

        public new void Rout()
        {
            base.Rout();
            Console.WriteLine("to Tiraspol station");
        }
        public override string ToString()
        {
            return "passanger";
        }
    }
}
