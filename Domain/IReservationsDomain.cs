using System.Reflection.Metadata;
using Infraestructure.Models;
namespace Domain;


public interface IReservationsDomain
{
    bool Create(Reservations input);

    bool Update(int id, Reservations input);

    bool Delete(int id);
}