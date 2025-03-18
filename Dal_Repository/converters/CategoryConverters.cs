using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto_Common_Entities;
namespace Dal_Repository.converters
{
    internal class CategoryConverters
    {
        public static CategoryDto ToCategoryDto(models.Category c)
        {
            CategoryDto cNew = new CategoryDto();
            cNew.Id = c.Id;
            cNew.NameCategory = c.NameCategory;
            return cNew;
        }
        public static List<CategoryDto> ToListCategoryDto(List<models.Category> lc)
        {
            List<Dto_Common_Entities.CategoryDto> lnew = new List<CategoryDto>();
            foreach (models.Category c in lc)
            {
                lnew.Add(ToCategoryDto(c));
            }
            return lnew;
        }


        public static models.Category ToCategory(CategoryDto c)
        {
            models.Category cNew = new models.Category();
            cNew.NameCategory= c.NameCategory;
            return cNew;
        }
    }
}
