using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;

namespace IDal_Repository
{
    public interface IDalCategory
    {
        public Task<List<CategoryDto>> SelectAll();

    }
}
