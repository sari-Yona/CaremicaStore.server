using Dto_Common_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IBll_Services.IBllProduct p;
        public ProductController(IBll_Services.IBllProduct p)
        {
            this.p = p;
        }

        [HttpGet]
        public async Task<List<ProductDto>> SelectAll()
        {
            return await p.SelectAll();
        }

        [HttpPost]
        public async Task<List<ProductDto>> SelectByFilter(FilterOptionsDto fo)
        {
            return await p.SelectByFilter(fo);
        }

        //[HttpGet("byprice/{maxprice}")]
        //public async Task<List<ProductDto>> SelectByMaxPrice(double maxprice)
        //{
        //    return await p.SelectByMaxPrice(maxprice);
        //} 

        //[HttpGet("bycategory/{categoryid}")]
        //public async Task<List<ProductDto>> SelectFilteredByCategoryId(int categoryid)
        //{
        //    return await p.SelectFilteredByCategoryId(categoryid);
        //}






    }
    }

