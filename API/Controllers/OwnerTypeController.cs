using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Input;
using Domain.OwnerTypeD;
using Infraestructure.OwnerType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerTypeController : ControllerBase
    {
        private IOwnerTypeInfra _ownerTypeInfra;

        private IOwnerTypeDomain _ownerTypeDomain;

        public OwnerTypeController(IOwnerTypeInfra ownerTypeInfra, IOwnerTypeDomain ownerTypeDomain)
        {
            _ownerTypeInfra = ownerTypeInfra;
            _ownerTypeDomain = ownerTypeDomain;
        }
        // GET: api/OwnerType
        [HttpGet]
        public List<OwnerType> Get()
        {
            return _ownerTypeInfra.GetAll();
        }

        // GET: api/OwnerType/5
        [HttpGet("{id}", Name = "GetOwnerType")]
        public OwnerType Get(int id)
        {
            return _ownerTypeInfra.GetById(id);
        }

        // POST: api/OwnerType
        [HttpPost]
        public void Post([FromBody] OwnerTypeInput input)
        {
            if (ModelState.IsValid)
            {
                OwnerType ot = new OwnerType()
                {
                    nameType = input.nameType,
                    description = input.description
                };
                _ownerTypeDomain.Create(ot);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT: api/OwnerType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OwnerTypeInput input)
        {
            if (ModelState.IsValid)
            {
                OwnerType ot = new OwnerType()
                {
                    nameType = input.nameType,
                    description = input.description
                };
                _ownerTypeDomain.Update(id, ot);
            }
            else
            {
                StatusCode(400);
            }
        }

        // DELETE: api/OwnerType/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerTypeInfra.Delete(id);
        }
    }
}
