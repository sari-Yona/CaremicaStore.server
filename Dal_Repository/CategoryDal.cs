using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal_Repository.models;
using Dto_Common_Entities;
using IDal_Repository;
using Microsoft.EntityFrameworkCore;

namespace Dal_Repository
{
    public class CategoryDal : IDalCategory
    {

        public async Task<List<CategoryDto>> SelectAll()
        {
            ProjectDbContext db = new ProjectDbContext();
            var q = await db.Categories.ToListAsync();
            return converters.CategoryConverters.ToListCategoryDto(q);
        }




    }
}
