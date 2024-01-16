using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappers
{
    public static class MapPart
    {
        public static Part MapFromDB(PartDB db)
        {
            return new Part(db.Name, db.Name);
        }

        public static PartDB MapToDB(Part part)
        {
            return new PartDB(part.Name);
        }
    }
}
