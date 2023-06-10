using API.Input;
using Domain;
using Infraestructure;
using Infraestructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateController : ControllerBase
    {
        private IPrivateInfrastructure _privateInfrastructure;
        private IPrivateDomain _privateDomain;

        public PrivateController(IPrivateInfrastructure privateInfrastructure, IPrivateDomain privateDomain)
        {
            _privateInfrastructure = privateInfrastructure;
            _privateDomain = privateDomain;
        }
        // GET: api/private
        [HttpGet]
        public List<Private> Get()
        {
            return _privateInfrastructure.GetAll();
        }

        // GET: api/private/5
        [HttpGet("{id}", Name = "Get")]
        public Private Get(int id)
        {
            return _privateInfrastructure.GetById(id);
        }

        // POST: api/private
        [HttpPost]
        public void Post([FromBody] PrivateInput input)
        {
            if (ModelState.IsValid)
            {
                Private privat = new Private()
                {
                    firstName = input.firstName,
                    lastName = input.lastName,
                    age = input.age,
                    phone = input.phone
                };
                _privateDomain.Create(privat);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT: api/private/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PrivateInput input)
        {
            if (ModelState.IsValid)
            {
                Private privat = new Private()
                {
                    firstName = input.firstName,
                    lastName = input.lastName,
                    age = input.age,
                    phone = input.phone
                };
                _privateDomain.Update(id, privat);
            }
            else
            {
                StatusCode(400);
            }
        }

        // DELETE: api/private/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _privateDomain.Delete(id);
        }
    }
}
