using Dto_Common_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;

namespace Bll_Services
{
    public class CompanyBll:IBll_Services.IBllCompany
    {
        IDal_Repository.IDalCompany c;
        public CompanyBll(IDal_Repository.IDalCompany c)
        {
            this.c = c;
        }
        public async Task<List<CompanyDto>> SelectAll()
        {
            return await c.SelectAll();
        }
        
    }
}
