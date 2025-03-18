using Dto_Common_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll_Services
{
    public interface IBllShopping
    {
        public Task<(ShoppingDto shDto, Dictionary<int, ProductDto> dDto)> FinishShopping(List<SoppingDetailDto> lsd, int CustomerId);
        
    }
}
