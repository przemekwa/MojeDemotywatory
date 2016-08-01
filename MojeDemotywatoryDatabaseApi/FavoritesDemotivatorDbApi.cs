using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MojeDemotywatoryDatabaseApi.Dto;

namespace MojeDemotywatoryDatabaseApi
{
    public class FavoritesDemotivatorDbApi
    {
        private FavoritesDemotivatorContext favoritesDemotivatorContext;

        public FavoritesDemotivatorDbApi()
        {
            this.favoritesDemotivatorContext = new FavoritesDemotivatorContext();
        }

        public IEnumerable<Favorites> GetFavoritesDemotivator()
        {
            return this.favoritesDemotivatorContext.Favorites;
        }
    }
}
