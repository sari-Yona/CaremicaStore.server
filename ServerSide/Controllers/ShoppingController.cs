using Dto_Common_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        IBll_Services.IBllShopping s;
        public ShoppingController(IBll_Services.IBllShopping s)
        {
            this.s = s;
        }

            [HttpPost("finishShopping/{customerId}")]
            public async Task<ActionResult<ShoppingDto>> FinishShopping(int customerId, List<SoppingDetailDto> ls)
            {
                (ShoppingDto shDto, Dictionary<int, ProductDto> dDto) result = await s.FinishShopping(ls, customerId);
                if (result.shDto==null&&result.dDto==null)
                    return StatusCode(500, "Internal server error ");
                if(result.shDto==null)
                    return Conflict(result.dDto); // מחזיר קוד 409 עם המוצרים שחסרים במלאי
                
                return Ok(result.shDto); 
            }

           


    }
    }

