using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace MojeDemotywatory.Infrastructure
{
    public class AutoryzacjaUlubionych : AuthorizeAttribute 
    {
        private string uzytkownik;

        public AutoryzacjaUlubionych(string nazwaUzytkownika)
        {
            this.uzytkownik = nazwaUzytkownika;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (Environment.UserName == uzytkownik)
            {
                return true;
            }

            return false;
        }
    }
}