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

        public IEnumerable<string> Odczytaj()
        {
            using (var strumienOdczytu = new StreamReader(this.NazwaBazy))
            {
                while (true)
                {
                    var linia = strumienOdczytu.ReadLine();

                    if (!string.IsNullOrEmpty(linia))
                    {
                        yield return linia;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
