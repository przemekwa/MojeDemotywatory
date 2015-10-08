using MojeDemotywatoryApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaLite
{
    class DemotywatoryDbContex : DbContext
    {
        public DbSet<DemotywatorSlajd> Demotywatory { get; set; }
    }
}
