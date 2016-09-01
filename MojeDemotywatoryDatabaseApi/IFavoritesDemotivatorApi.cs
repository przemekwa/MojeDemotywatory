using System.Collections.Generic;
using MojeDemotywatoryDatabaseApi.Dto;

namespace MojeDemotywatoryDatabaseApi
{
    public interface IFavoritesDemotivatorApi
    {
        void Add(Favorites favorites);
        IEnumerable<Favorites> Get();
        void Remove(int id);
    }
}