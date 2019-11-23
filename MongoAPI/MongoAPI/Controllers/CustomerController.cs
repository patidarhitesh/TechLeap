using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoAPI.Models;

namespace MongoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository service;

        public CustomerController(ICustomerRepository customerService)
        {
            service = customerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetCustomers());
        }

        [HttpGet]
        [Route("{customerId}")]//api/customer/{customerId}
        public IActionResult Get(int customerId)
        {

            return Ok(service.GetCustomerById(customerId));

        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {

            service.AddCustomer(customer);
            return StatusCode(201, customer);

        }

        [HttpPut("{customerId}")]
        public IActionResult Put(int customerId, [FromBody]Customer customer)
        {

            service.UpdateCustomer(customerId, customer);
            return Ok(customer);

        }

        [HttpDelete]

        public IActionResult Delete(int customerId)
        {

            return Ok(service.RemoveCustomer(customerId));

        }
    }
}