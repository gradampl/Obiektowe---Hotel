using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    interface IHotel
    {
        void DodajRezerwacje(string p1,string p2,int p3,double p4);
        void OdwolajRezerwacje();
    }
}
