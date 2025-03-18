using Dto_Common_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IBll_Services.IBllCustomer c;
        public CustomerController(IBll_Services.IBllCustomer c)
        {
            this.c = c;
        }

            [HttpPost("login")]
            public async Task<ActionResult<CustomerDto>> LogIn(CustomerDto customer)
            {
                CustomerDto customerDto =await  c.LogIn(customer.Email);
                if (customerDto == null)
                 return NotFound(); 
                return Ok(customerDto); 
            }

            [HttpPost("signin")]
            public async Task<ActionResult<CustomerDto>> SignIn(CustomerDto newCustomer)
            {
            CustomerDto customerDto = await c.SignIn(newCustomer);
            if (customerDto == null)
                return Conflict("Email already exists.");
            if(customerDto.Id == null)
                return BadRequest();
            return Ok(customerDto);
            }


    }
    }

