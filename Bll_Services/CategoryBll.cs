using Dto_Common_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;
using IBll_Services;
namespace Bll_Services
{
    public class CategoryBll: IBllCategory
    {
        IDal_Repository.IDalCategory c;
        public CategoryBll(IDal_Repository.IDalCategory c)
        {
            this.c = c;
        }
        public async Task<List<CategoryDto>> SelectAll()
        {
            return await c.SelectAll();
        }
    }
}
