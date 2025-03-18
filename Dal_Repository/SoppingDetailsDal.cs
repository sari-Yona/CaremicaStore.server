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
    public class SoppingDetailsDal : IDalShoppingDetail
    {
        public async Task<int> Add(SoppingDetailDto c,int shoppingId)
        {
            ProjectDbContext db = new ProjectDbContext();
            db.SoppingDetails.Add(converters.SoppingDetailsConverters.ToSoppingDetail(c, shoppingId));
            return await db.SaveChangesAsync();
        }


        public async Task<SoppingDetailDto> SelectById(int id)
        {
            ProjectDbContext db = new ProjectDbContext();
            SoppingDetail soppingDetail = db.SoppingDetails.FirstOrDefault(p => p.Id == id);
            return converters.SoppingDetailsConverters.ToSoppingDetailsDto(soppingDetail);

        }

        

        public async Task<int> Update(int id, SoppingDetailDto newS)
        {
            ProjectDbContext db = new ProjectDbContext();
            SoppingDetail soppingDetail = db.SoppingDetails.FirstOrDefault(p => p.Id == id);
            soppingDetail.ProductId = newS.ProductId;
            soppingDetail.Quantity = newS.Quantity;
            return await db.SaveChangesAsync();

        }
    }
}
