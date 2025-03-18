using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;

namespace IDal_Repository
{
    public interface IDalCustomer
    {
        public  Task<int> Add(CustomerDto c);
    
        public  Task<List<CustomerDto>> SelectAll();


        public Task<CustomerDto> SelectById(int id);

    }
}
