using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal_Repository.models;
using Dto_Common_Entities;
using IDal_Repository;
using Microsoft.EntityFrameworkCore;

namespace Dal_Repository
{
    public class CustomerDal : IDalCustomer
    {
        public async Task<int> Add(CustomerDto c)
        {
            try
            {
                using (ProjectDbContext db = new ProjectDbContext())
                {
                    var customerEntity = converters.CustomerConverters.ToCustomer(c);
                    await db.Customers.AddAsync(customerEntity);
                    await db.SaveChangesAsync();
                    return customerEntity.Id; // החזרת ה-ID החדש שנוצר
                }
            }
            catch (Exception)
            {
                return 0; // החזרת 0 במקרה של כישלון
            }
        }

        

        public async Task<List<CustomerDto>> SelectAll()
        {
            ProjectDbContext db = new ProjectDbContext();
            var q = await db.Customers.ToListAsync();
            return converters.CustomerConverters.ToListCustomerDto(q);
        }

       

        public async Task<CustomerDto> SelectById(int id)
        {
            ProjectDbContext db = new ProjectDbContext();
            Customer customer = db.Customers.FirstOrDefault(p => p.Id == id);
            return converters.CustomerConverters.ToCustomerDto(customer);

        }

    }
}
