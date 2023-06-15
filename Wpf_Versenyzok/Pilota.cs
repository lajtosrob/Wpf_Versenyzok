using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Versenyzok
{
    class Pilota
    {
        string nev;
        DateTime szuletesi_datum;
        string nemzetiseg;
        string rajtszam;

        public Pilota(string nev, DateTime szuletesi_datum, string nemzetiseg, string rajtszam)
        {
            this.nev = nev;
            this.szuletesi_datum = szuletesi_datum;
            this.nemzetiseg = nemzetiseg;
            this.rajtszam = rajtszam;
        }

        public string Nev { get => nev;  }
        public DateTime Szuletesi_datum { get => szuletesi_datum;  }
        public string Nemzetiseg { get => nemzetiseg;  }
        public string Rajtszam { get => rajtszam;  }
    }
}
