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
        private readonly FavoritesDemotivatorContext favoritesDemotivatorContext;

        public FavoritesDemotivatorDbApi()
        {
            this.favoritesDemotivatorContext = new FavoritesDemotivatorContext();
        }

        public IEnumerable<Favorites> Get()
        {
            return this.favoritesDemotivatorContext.Favorites;
        }

        public void Add(Favorites favorites)
        {
            this.favoritesDemotivatorContext.Favorites.Add(favorites);
            this.favoritesDemotivatorContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var favoritesToRemove = this.favoritesDemotivatorContext.Favorites.Single(f => f.Id == id);

            this.favoritesDemotivatorContext.Favorites.Remove(favoritesToRemove);

            this.favoritesDemotivatorContext.SaveChanges();
        }
    }
}
