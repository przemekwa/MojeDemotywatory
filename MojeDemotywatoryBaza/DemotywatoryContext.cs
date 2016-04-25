using MojeDemotywatoryBaza.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryBaza
{
    public class DemotywatoryContext : DbContext
    {
        public DemotywatoryContext(string con) :
                     base("name="+con)
        {
            Database.SetInitializer<DemotywatoryContext>(null);
        }

        public DbSet<Demotywatory> Demotywatory { get; set; }
        public DbSet<Uzytkownicy> Uzytkownicy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
