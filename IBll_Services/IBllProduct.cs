using Dto_Common_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll_Services
{
    public interface IBllProduct
    {
        public Task<List<ProductDto>> SelectAll();

        public Task<List<ProductDto>> SelectByFilter(FilterOptionsDto fo);


        //public Task<List<ProductDto>> SelectFilteredByCategoryId(int categoryId);


        //public Task<List<ProductDto>> SelectByMaxPrice(double maxPrice);
    }
}
