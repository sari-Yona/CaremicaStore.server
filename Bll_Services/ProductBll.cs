using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;


namespace Bll_Services
{
    public class ProductBll:IBll_Services.IBllProduct
    {
        IDal_Repository.IDalProduct c;
        public ProductBll(IDal_Repository.IDalProduct c)
        {
            this.c = c;
        }
        public async Task<List<ProductDto>> SelectAll()
        {
            return await c.SelectAll();
        }


        //סינונים-----------------------------------

        public async Task<List<ProductDto>> SelectByFilter(FilterOptionsDto fo)
        {
            return await c.SelectByFilter(fo);
        }
        //public async Task<List<ProductDto>> SelectFilteredByCategoryId(int categoryId)
        //{
        //    var allProducts = await SelectAll();
        //    return allProducts.Where(product => product.CategoryId == categoryId).ToList();
        //}


        //public async Task<List<ProductDto>> SelectByMaxPrice(double maxPrice)
        //{
        //    var products = await c.SelectAll();
        //    return products.Where(product => product.Price <= maxPrice).ToList();
        //}


    }
}
