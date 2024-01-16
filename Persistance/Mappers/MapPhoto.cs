using Persistence.DatalayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappers
{
    public static class MapPhoto
    {
        public static string mapFromDB(PhotoDB photo)
        {
            return photo.Location.ToString();
        }
    }
}
