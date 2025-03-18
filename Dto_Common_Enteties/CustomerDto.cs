using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto_Common_Entities
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime DateBirth { get; set; }

    }
}
