using Infraestructure.Models;
namespace Infraestructure;
public interface IRentInfraestructure
{
    List<Rent> GetAll();
    Rent GetById(int id);
    bool Create(Rent input);
    bool Update(int id, Rent input);
    bool Delete(int id);
}