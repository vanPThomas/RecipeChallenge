using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class PartDB
    {
        public PartDB()
        {
        }

        public PartDB(string name) {
            Name = name;
        }

        //public PartDB(string name, int itemDBId) {
        //    Name = name;
        //    ItemDBId = itemDBId;
        //}

        [Key]
        [MaxLength(500)]
        public string Name { get; private set; }
        //public int ItemDBId { get; private set; }

    }
}
