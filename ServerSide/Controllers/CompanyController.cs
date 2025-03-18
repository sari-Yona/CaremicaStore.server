using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        IBll_Services.IBllCompany c;
        public CompanyController(IBll_Services.IBllCompany c)
        {
            this.c = c;
        }

        [HttpGet]
        public async Task<List<Dto_Common_Entities.CompanyDto>> Get()
        {
            return await c.SelectAll();
        }
    }
}
