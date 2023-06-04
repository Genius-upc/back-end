using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Input;
using Domain;
using Infraestructure;
using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IOwnerInfraestructure _ownerInfraestructure;
        private IOwnerDomain _ownerDomain;

        public OwnerController(IOwnerInfraestructure ownerInfraestructure, IOwnerDomain ownerDomain)
        {
            _ownerInfraestructure = ownerInfraestructure;
            _ownerDomain = ownerDomain;
        }
        // GET: api/Owner
        [HttpGet]
        public List<Owner> Get()
        {
            return _ownerInfraestructure.GetAll();
        }

        // GET: api/Owner/5
        [HttpGet("{id}", Name = "Get")]
        public Owner Get(int id)
        {
            return _ownerInfraestructure.GetById(id);
        }

        // POST: api/Owner
        [HttpPost]
        public void Post([FromBody] OwnerInput input)
        {
            if (ModelState.IsValid)
            {
                Owner owner = new Owner()
                {
                    firstName = input.firstName,
                    lastName = input.lastName,
                    age = input.age,
                    phone = input.phone
                };
                _ownerDomain.Create(owner);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OwnerInput input)
        {
            if (ModelState.IsValid)
            {
                Owner owner = new Owner()
                {
                    firstName = input.firstName,
                    lastName = input.lastName,
                    age = input.age,
                    phone = input.phone
                };
                _ownerDomain.Update(id, owner);
            }
            else
            {
                StatusCode(400);
            }
        }

        // DELETE: api/Owner/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerDomain.Delete(id);
        }
    }
}
