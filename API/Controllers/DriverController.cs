using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Genius.API.Input;
using Genius.API.Response;
using Genius.Domain;
using Genius.Infraestructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Genius.Infraestructure.Models;



namespace Genius.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private IDriverDomain _driverDomain;
        private IDriverInfraestructure _driverInfraestructure;
        private IMapper _mapper;

        public DriverController(IDriverDomain driverDomain, IDriverInfraestructure driverInfraestructure, IMapper mapper)
        {
            _driverDomain = driverDomain;
            _driverInfraestructure= driverInfraestructure;
            _mapper = mapper;
        }

        
        // GET: api/Driver
        [HttpGet]
        public async Task<List<DriverResponse>> Get()
        {
            var result = await _driverInfraestructure.GetAll();
            //return await _driverDomain.GetAll();
            
            /* List<TutorialResponse> list = new List<TutorialResponse>();
            foreach (var tutorial in result)
            {
                list.Add(new TutorialResponse()
                {
                    Name = tutorial.Name,
                    Description = tutorial.Description,
                    Id = tutorial.Id
                });
                
            }*/
            
            var list = _mapper.Map<List<Driver>, List<DriverResponse>>(result);
            return list;
        }

        [HttpGet("{name}", Name = "GetByName")]
        public async Task<List<Driver>> GetByName(string name)
        {
            return await _driverInfraestructure.GetByName(name);
        }
        

        // GET: api/Driver/5
        [HttpGet("{id}")]
        public  Driver GetById(int id)
        {
            return _driverInfraestructure.GetById(id);
        }

        // POST: api/Driver
        [HttpPost]
        //public void Post([FromBody] string value,  int age, string license, string phone)
        public async Task PostAsync([FromBody] DriverInput input)
        {
            // _driverDomain.Create(value,age,license,phone);
            if (ModelState.IsValid) {
                /*
                Driver driver = new Driver()
                {
                    Name = input.Name,
                    Age = input.Age,
                    License = input.License,
                    Phone = input.Phone
                };*/ 
                
                var driver = _mapper.Map<DriverInput, Driver>(input);
                await _driverDomain.CreateAsync(driver);
            }
            else
            {
                StatusCode(400);
            }
        }


        // PUT: api/Driver/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DriverInput input)
        {
            if (ModelState.IsValid)
            {
                Driver driver = new Driver()
                {
                    Name = input.Name,
                    Age = input.Age,
                    License = input.License,
                    Phone = input.Phone
                };
                _driverDomain.Update(id, driver);
            }
            else
            {
                StatusCode(400);
            }
        }
        
        // DELETE: api/Driver/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _driverDomain.Delete(id);
        }
    }
    
}
