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
    public class ProductDal : IDalProduct
    {

       //מחזיר חצי ראשון של המוצרים
        public async Task<List<ProductDto>> SelectAll()
        {
            ProjectDbContext db = new ProjectDbContext();
            var totalProducts = await db.Products.CountAsync(); // סופר את כל המוצרים
            var halfCount = totalProducts *0.95; // חצי מהכמות

            var q = await db.Products.Include(p=>p.Category).Include(p=>p.Company)
                .OrderByDescending(p=>p.UpdateDate).Take((int)halfCount).ToListAsync();
            return converters.ProductConverters.ToListProductDto(q);
        }

        //מחזיר  את כל המוצרים
        public async Task<List<ProductDto>> SelectAllServer()
        {
            ProjectDbContext db = new ProjectDbContext();
            var q = await db.Products.Include(p => p.Category).Include(p => p.Company).ToListAsync();
            return converters.ProductConverters.ToListProductDto(q);
        }

        public async Task<int> Update(int id, ProductDto newP)
        {
            ProjectDbContext db = new ProjectDbContext();
            Product product = db.Products.FirstOrDefault(p => p.Id == id);
            product.NameProduct = newP.NameProduct;
            product.Description =newP.Description;
            product.Quantity = newP.Quantity;
            product.Price = newP.Price;
            product.Picture = newP.Picture;
            return await db.SaveChangesAsync();

        }

        public async Task<ProductDto> SelectById(int id)
        {
            ProjectDbContext db = new ProjectDbContext();
            Product product = db.Products.Include(p => p.Category).Include(p => p.Company).FirstOrDefault(p => p.Id == id);
            return converters.ProductConverters.ToProductDto(product);

        }

        public async Task<List<ProductDto>> SelectByFilter(FilterOptionsDto fo)
        {
            ProjectDbContext db = new ProjectDbContext();
            var q = await db.Products.Include(p => p.Category).Include(p => p.Company).ToListAsync();

            if (fo.CategoryId != 0)
            {
                q = q.Where(p => p.CategoryId == fo.CategoryId).ToList();
            }

            if (fo.CompanyId != 0)
            {
                q = q.Where(p => p.CompanyId == fo.CompanyId).ToList();
            }

            if (fo.MaxPrice != 0)
            {
                q = q.Where(p => p.Price <= (int)fo.MaxPrice).ToList();
            }

            if (fo.MinPrice != 0)
            {
                q = q.Where(p => p.Price >= (int)fo.MaxPrice).ToList();
            }

            return converters.ProductConverters.ToListProductDto(q);


        }

        //SelectByFilter(FilterOptionsDto fo) SelectByIdModel(int id)
        //{
        //    ProjectDbContext db = new ProjectDbContext();
        //    Product product = db.Products.FirstOrDefault(p => p.Id == id);
        //    return product;

        //}


    }
}
