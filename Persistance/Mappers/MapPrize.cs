using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappers
{
    public static class MapPrize
    {
        public static Prize MapFromDB(PrizeDB db)
        {
            return new Prize((int)db.Id, db.Logo, db.Name, db.Description, db.Company);
        }

        public static PrizeDB MapToDB(Prize prize)
        {
            return new PrizeDB(prize.Logo, prize.Name, prize.Description, prize.Company);
        }
    }
}
