using Infraestructure.Models;
namespace Infraestructure;
public interface IParkingInfraestructure
{
    List<Parking> GetAll();
    Parking GetById(int id);
    bool Create(Parking input);
    bool Update(int id, Parking input);
    bool Delete(int id);
}