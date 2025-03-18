using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IBll_Services.IBllCategory c;
        public CategoryController(IBll_Services.IBllCategory c)
        {
            this.c = c;
        }

        [HttpGet]
        public async Task<List<Dto_Common_Entities.CategoryDto>> Get()
        {
            return await c.SelectAll();
        }
    }
}
