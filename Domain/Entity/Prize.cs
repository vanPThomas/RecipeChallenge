using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Prize
    {
        public Prize(int id, string logo, string name, string description, string company)
        {
            SetId(id);
            SetLogo(logo);
            SetName(name);
            SetDescription(description);
            SetCompany(company);
        }
        public Prize(string logo, string name, string description, string company)
        {
            SetLogo(logo);
            SetName(name);
            SetDescription(description);
            SetCompany(company);
        }

        
        public int Id { get; private set; }
        public string Logo { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Company { get; private set; }

        public void SetId(int id) {
            if (id <= 0) throw new PrizeException("SetId - Id is less than or equal to 0");
            Id = id;
        }

        public void SetLogo(string logo) {
            if (string.IsNullOrWhiteSpace(logo)) throw new PrizeException("SetLogo - Logo string is null or whitespace");
            Logo = logo;
        }

        public void SetName(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new PrizeException("SetName - Name is null or whitespace");
            Name = name;
        }

        public void SetDescription(string description) {
            if (string.IsNullOrWhiteSpace(description)) throw new PrizeException("SetDescription - Description is null or whitespace");
            Description = description;
        }

        public void SetCompany(string company) {
            if (string.IsNullOrWhiteSpace(company)) throw new PrizeException("SetCompany - Company is null or whitespace");
            Company = company;
        }
    }
}
