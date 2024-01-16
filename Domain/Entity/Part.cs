using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Part
    {
       
        public Part(string name, string unitOfMeasurement)
        {
            SetName(name); 
            SetUnitOfMeasurement(unitOfMeasurement);
        }

        public string Name { get; private set; }
        public string UnitOfMeasurement { get; private set; }

        public void SetName(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new PartException("SetName - Name is null or whitespace");
            Name = name;
        }

        public void SetUnitOfMeasurement(string unitOfMeasurement) {
            if (string.IsNullOrWhiteSpace(unitOfMeasurement)) throw new PartException("SetUnitOfMeasurement - Unit of measurement is null or whitespace");
            UnitOfMeasurement = unitOfMeasurement;
        }
    }
}
