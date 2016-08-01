using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryDatabaseApi.Dto
{
    public class Favorites
    {
        [Key]
        public int Id { get; set; }
       
        public int UserId { get; set; }

        public string Url { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string ImgUrl { get; set; }
    }
}
