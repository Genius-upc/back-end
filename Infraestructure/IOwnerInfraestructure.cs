using Infraestructure.Models;

namespace Infraestructure;

public interface IOwnerInfraestructure
{
    List<Owner> GetAll();
    Owner GetById(int id);
    bool Create(Owner input);
    bool Update(int id, Owner input);
    bool Delete(int id);
}