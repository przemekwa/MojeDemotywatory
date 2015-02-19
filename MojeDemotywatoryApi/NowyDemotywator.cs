﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{
    internal class NowyDemotywator : DemotywatorBuldier
    {
        public override Demotywator Build()
        {
            var rezult = new Demotywator
            {
                AdresStrony = this.AdresStrony,
                CzySaSlajdy = this.CzySaSlajdy,
                AdresObrazka = this.AdresObrazka,
                ListaSlajdow = this.ListaSlajdów,
                AsdresStronyZeSlajdami = this.AsdresStronyZeSlajdami
            };

            if (rezult.CzySaSlajdy)
            {
                rezult.ListaSlajdow = ApiTools.PobierzDemotywatoryZeSlajdow(rezult.AsdresStronyZeSlajdami);
            }


            return rezult;
            
        }
    }

    internal class NowyDemotywatorSlajd : DemotywatorSlajdBuldier
    {
        public override DemotywatorSlajd Build()
        {
            var rezult = new DemotywatorSlajd
            {
                AdresObrazka = this.AdresObrazka,
                Opis = this.Opis
            };

            return rezult;

        }
    }
}