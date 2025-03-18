using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;
namespace IBll_Services
{
    public interface IBllCategory
    {
        public Task<List<CategoryDto>> SelectAll();

    }
}
