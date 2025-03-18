using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;
namespace Dal_Repository.converters
{
    public class CustomerConverters
    {
        public static CustomerDto ToCustomerDto(models.Customer c)
        {
            CustomerDto cNew = new CustomerDto();
            cNew.Id = c.Id;
            cNew.CustomerName = c.CustomerName;
            cNew.Phone = c.Phone;
            cNew.Email = c.Email;
            cNew.DateBirth = c.DateBirth;
            return cNew;
        }
        public static List<CustomerDto> ToListCustomerDto(List<models.Customer> lc)
        {
            List<CustomerDto> lnew = new List<CustomerDto>();
            foreach (models.Customer c in lc)
            {
                lnew.Add(ToCustomerDto(c));
            }
            return lnew;
        }


        public static models.Customer ToCustomer(CustomerDto c)
        {
            models.Customer cNew = new models.Customer();
            cNew.CustomerName = c.CustomerName;
            cNew.Phone = c.Phone;
            cNew.Email = c.Email;
            cNew.DateBirth = c.DateBirth;
            return cNew;
        }
    }
}
