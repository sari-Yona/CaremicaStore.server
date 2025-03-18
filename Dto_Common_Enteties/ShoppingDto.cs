using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto_Common_Entities
{
    public class ShoppingDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public double Sum { get; set; }

        public string? Remark { get; set; }


    }
}
