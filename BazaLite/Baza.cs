using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaLite
{
    public class Baza
    {
        private string NazwaBazy { get; set; }

        public Baza(string name)
        {
            this.NazwaBazy = "c:\\a\\" + name +  ".txt";

            if (!File.Exists(this.NazwaBazy))
            {
                File.Create(this.NazwaBazy).Close();
            }
        }

        public void Dodaj(string linia)
        {
            var strumienPlik = new StreamWriter(this.NazwaBazy, true);

            strumienPlik.WriteLine(linia);

            strumienPlik.Close();
        }

        public void Usun(string linia)
        {
            var linie = this.Odczytaj();

            var strumienPlik = new StreamWriter(this.NazwaBazy);

            foreach (var l in linie)
            {
                if ( l == linia) continue;
                
                strumienPlik.WriteLine(l);
            }

            strumienPlik.Close();
        }

        public IEnumerable<string> Odczytaj()
        {
            var rezult = new List<string>();

            using (var strumienOdczytu = new StreamReader(this.NazwaBazy))
            {
                    var linia = strumienOdczytu.ReadLine();

                    while (!string.IsNullOrEmpty(linia))
                    {
                        rezult.Add(linia);
                        linia = strumienOdczytu.ReadLine();
                    }

                    strumienOdczytu.Close();
            }

            return rezult;
        }
    }
}
