
using System.ComponentModel.DataAnnotations;

namespace MojeDemotywatoryDatabaseApi.Dto
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
