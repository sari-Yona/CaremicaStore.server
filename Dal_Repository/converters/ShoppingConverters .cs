using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal_Repository.models;
using Dto_Common_Entities;
namespace Dal_Repository.converters
{
    internal class ShoppingConverters
    {
        public static ShoppingDto ToShoppingDto(models.Shopping s)
        {
            ShoppingDto sNew = new ShoppingDto();
            sNew.Id = s.Id;
            sNew.Date=s.Date;
            sNew.Remark=s.Remark;
            sNew.Sum=s.Sum;
            sNew.CustomerId=s.CustomerId;
            return sNew;
        }
        public static List<ShoppingDto> ToListSoppingDto(List<models.Shopping> ls)
        {
            List<ShoppingDto> lnew = new List<ShoppingDto>();
            foreach (models.Shopping s in ls)
            {
                lnew.Add(ToShoppingDto(s));
            }
            return lnew;
        }


        public static models.Shopping ToShopping(ShoppingDto s)
        {
            models.Shopping sNew = new models.Shopping();
            sNew.Date = s.Date;
            sNew.Remark = s.Remark;
            sNew.Sum = s.Sum;
            sNew.CustomerId = s.CustomerId;
            return sNew;
        }
    }
}
