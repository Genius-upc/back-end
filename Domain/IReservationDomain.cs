using Infraestructure.Models;
namespace Domain;
public interface IReservationDomain
{
    bool Create(Reservation input);
    bool Update(int id, Reservation input);
    bool Delete(int id);
}