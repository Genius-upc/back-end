using API.Input;
using Domain;
using Infraestructure;
using Infraestructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationInfrastructure _reservationInfrastructure;
        private IReservationDomain _reservationDomain;

        public ReservationController(IReservationInfrastructure reservationInfrastructure, IReservationDomain reservationDomain)
        {
            _reservationInfrastructure = reservationInfrastructure;
            _reservationDomain = reservationDomain;
        }
        // GET: api/reservation
        [HttpGet]
        public List<Reservation> Get()
        {
            return _reservationInfrastructure.GetAll();
        }

        // GET: api/reservation/5
        [HttpGet("{id}", Name = "Get")]
        public Reservation Get(int id)
        {
            return _reservationInfrastructure.GetById(id);
        }

        // POST: api/reservation
        [HttpPost]
        public void Post([FromBody] ReservationInput input)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation()
                {
                    Driver_id = input.Driver_id
                };
                _reservationDomain.Create(reservation);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT: api/reservation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ReservationInput input)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation()
                {
                    Driver_id = input.Driver_id
                };
                _reservationDomain.Update(id, reservation);
            }
            else
            {
                StatusCode(400);
            }
        }

        // DELETE: api/reservation/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _reservationDomain.Delete(id);
        }
    }
}
