using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;
namespace Dal_Repository.converters
{
    internal class CompanyConverters
    {
        public static CompanyDto ToCompanyDto(models.Company c)
        {
            CompanyDto cNew = new CompanyDto();
            cNew.Id = c.Id;
            cNew.NameCompany = c.NameCompany;
            return cNew;
        }
        public static List<CompanyDto> ToListCompanyDto(List<models.Company> lc)
        {
            List<CompanyDto> lnew = new List<CompanyDto>();
            foreach (models.Company c in lc)
            {
                lnew.Add(ToCompanyDto(c));
            }
            return lnew;
        }


        public static models.Company ToCategory(CompanyDto c)
        {
            models.Company cNew = new models.Company();
            cNew.NameCompany = c.NameCompany;
            return cNew;
        }
    }
}
