using Infraestructure.Models;
namespace Domain;
public interface IParkingDomain
{
    bool Create(Parking input);
    bool Update(int id, Parking input);
    bool Delete(int id);
}