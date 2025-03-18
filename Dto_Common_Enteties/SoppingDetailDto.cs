using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto_Common_Entities
{
    public class SoppingDetailDto
    {
        public int Id { get; set; }


        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string NameProduct { get; set; } = null!;

        public double Price { get; set; }

        public string Picture { get; set; } = null!;



    }
}
