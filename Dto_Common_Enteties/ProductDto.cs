using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto_Common_Entities
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string NameProduct { get; set; } = null!;

        public int CategoryId { get; set; }

        public int CompanyId { get; set; }

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string Picture { get; set; } = null!;

        public int Quantity { get; set; }

        public DateTime UpdateDate { get; set; }

        public string? NameCategory { get; set; }

        public string NameCompany { get; set; } = null!;
    }
}
