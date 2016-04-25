using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryBaza.DomainModel
{
    public class Uzytkownicy
    {
        public int Id { get; set; }
        public int Uzytkownik_Id { get; set; }
        public string Url { get; set; }
        public string Img_Url { get; set; }
        public virtual ICollection<Demotywatory> ListaDemotywatorów { get; set; }

        public Uzytkownicy()
        {
            this.ListaDemotywatorów = new List<Demotywatory>();
        }
    }
}
