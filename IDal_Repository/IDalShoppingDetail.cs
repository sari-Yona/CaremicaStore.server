using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;

namespace IDal_Repository
{
    public interface IDalShoppingDetail
    {
        public Task<int> Add(SoppingDetailDto c, int shoppingId);

        public Task<int> Update(int id, SoppingDetailDto newC);

        public Task<SoppingDetailDto> SelectById(int id);

    }
}
