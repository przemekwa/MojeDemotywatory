using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MojeDemotywatoryDatabaseApi.Dto;

namespace MojeDemotywatoryDatabaseApi
{
    internal class FavoritesDemotivatorContext : DbContext
    {
        public DbSet<Favorites> Favorites { get; set; }

        public FavoritesDemotivatorContext() : base("FavoritesDemotivator")
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
        }
    }
}
