using Dto_Common_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll_Services
{
    public interface IBllCustomer
    {
        public Task<CustomerDto> LogIn(string Email);

        public Task<CustomerDto> SignIn(CustomerDto customer);

    }
}
