using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatalayerModel
{
    public class PhotoDB
    {
        public PhotoDB() { }
        public PhotoDB(string location)
        {
            Location = location;
        }

        [Key]
        [MaxLength(500)]
        public string Location { get; set; }
        //[Required]
        //[MaxLength(500)]
        //public int ItemDBId { get; set; }
    }
}
