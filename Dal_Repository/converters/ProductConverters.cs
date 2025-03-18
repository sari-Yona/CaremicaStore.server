using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal_Repository.models;
using Dto_Common_Entities;
namespace Dal_Repository.converters
{
    public class ProductConverters
    {
        public static ProductDto ToProductDto(models.Product p)
        {
            ProductDto pNew = new ProductDto();
            pNew.Id = p.Id;
            pNew.NameProduct = p.NameProduct;
            pNew.Description = p.Description;
            pNew.Price = p.Price;
            pNew.Picture = p.Picture;
            pNew.Quantity = p.Quantity;
            if (p.Category != null)
            {
                pNew.CategoryId = p.Category.Id;
                pNew.NameCategory = p.Category.NameCategory;
            }
            if(p.Company != null)
            { 
                pNew.CompanyId = p.Company.Id;
                pNew.NameCompany = p.Company.NameCompany;
            }
            return pNew;
        }
        public static List<ProductDto> ToListProductDto(List<models.Product> lp)
        {
            List<ProductDto> lnew = new List<ProductDto>();
            foreach (models.Product p in lp)
            {
                lnew.Add(ToProductDto(p));
            }
            return lnew;
        }


        public static models.Product ToProduct(ProductDto p)
        {
            models.Product pNew = new models.Product();
            pNew.NameProduct = p.NameProduct;
            pNew.Description = p.Description;
            pNew.Price = p.Price;
            pNew.Quantity = p.Quantity;
            pNew.Picture = p.Picture;
            pNew.CategoryId = p.CompanyId;
            pNew.CompanyId = p.CompanyId;

            return pNew;
        }
    }
}
