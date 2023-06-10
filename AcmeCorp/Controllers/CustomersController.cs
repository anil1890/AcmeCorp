using AcmeCorp.Interface;
using AcmeCorp.Model;
using AcmeCorp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace AcmeCorp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>();

        /// <summary>
        /// private readonly ApplicationDbContext _context;
        /// </summary>
        ICustomerRepository _customrService;

        public CustomersController(ICustomerRepository customrService)
        {
            //_context = context;
            _customrService = customrService;
        }

        // GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return Ok(customers);
        }

        // GET api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            //var customer = await _context.Customers.FindAsync(id);

            //if (customer == null)
            //{
            //    return NotFound();
            //}

            return Ok();
        }

        // POST api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            try
                {


                //customer.Id = _context.Customers.Count() + 1;
                //_context.Customers.Add(customer);
                //await _context.SaveChangesAsync();
                await _customrService.Create(customer);


                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/customers/{id}
        [HttpPut("{id}")]
        public ActionResult<Customer> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            throw new Exception("to be implement");
        }

        // DELETE api/customers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = customers.Find(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            customers.Remove(customer);
            return NoContent();
        }
    }
}
