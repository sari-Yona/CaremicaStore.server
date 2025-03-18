using Dto_Common_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll_Services
{
    public interface IBllCompany
    {
        public Task<List<CompanyDto>> SelectAll();

    }
}
