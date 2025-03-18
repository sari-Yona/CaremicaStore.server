using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;

namespace IDal_Repository
{
    public interface IDalProduct
    {
        public Task<List<ProductDto>> SelectAll();


        public Task<int> Update(int id, ProductDto newP);
 

        public Task<ProductDto> SelectById(int id);

        public Task<List<ProductDto>> SelectByFilter(FilterOptionsDto fo);

        public Task<List<ProductDto>> SelectAllServer();



    }
}
