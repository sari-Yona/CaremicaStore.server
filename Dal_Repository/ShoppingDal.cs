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
    public class ShoppingDal : IDalShopping
    {
        public async Task<int> Add(ShoppingDto s)
        {
            try
            {
                using (ProjectDbContext db = new ProjectDbContext())
                {
                    var shoppingEntity = converters.ShoppingConverters.ToShopping(s);
                    await db.Shoppings.AddAsync(shoppingEntity);
                    await db.SaveChangesAsync();
                    return shoppingEntity.Id; // החזרת ה-ID החדש שנוצר
                }
            }
            catch (Exception)
            {
                return 0; // החזרת 0 במקרה של כישלון
            }
        }




    }
}
