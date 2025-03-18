using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal_Repository.models;
using Dto_Common_Entities;
namespace Dal_Repository.converters
{
    internal class SoppingDetailsConverters
    {
        public static SoppingDetailDto ToSoppingDetailsDto(models.SoppingDetail s)
        {
            SoppingDetailDto sNew = new SoppingDetailDto();
            sNew.Id = s.Id;
            sNew.ProductId = s.ProductId;
            sNew.Quantity = s.Quantity;
                
            if (s.Product != null)
            {
                sNew.NameProduct=s.Product.NameProduct;
                sNew.Price = s.Product.Price;
                sNew.Picture=s.Product.Picture;
            }
            return sNew;
        }
        public static List<SoppingDetailDto> ToListSoppingDto(List<models.SoppingDetail> ls)
        {
            List<SoppingDetailDto> lnew = new List<SoppingDetailDto>();
            foreach (models.SoppingDetail s in ls)
            {
                lnew.Add(ToSoppingDetailsDto(s));
            }
            return lnew;
        }


        public static models.SoppingDetail ToSoppingDetail(SoppingDetailDto s,int shoppingId)
        {
            models.SoppingDetail sNew = new models.SoppingDetail();
            sNew.ProductId = s.ProductId;
            sNew.Quantity = s.Quantity;
            sNew.SoppingId= shoppingId;

            return sNew;
        }
    }
}
