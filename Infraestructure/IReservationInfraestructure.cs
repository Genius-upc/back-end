using Infraestructure.Models;
namespace Infraestructure;
public interface IReservationInfrastructure
{
    List<Reservation> GetAll();
    Reservation GetById(int id);
    bool Create(Reservation input);
    bool Update(int id, Reservation input);
    bool Delete(int id);
}