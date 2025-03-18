using Dto_Common_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;
using IDal_Repository;
using Microsoft.EntityFrameworkCore;
using Dal_Repository.models;

namespace Dal_Repository
{
    public class CompanyDal : IDal_Repository.IDalCompany
    {


        public async Task<List<CompanyDto>> SelectAll()
        {
            ProjectDbContext db = new ProjectDbContext();
            var q = await db.Companies.ToListAsync();
            return converters.CompanyConverters.ToListCompanyDto(q);
        }

     
    }
}
