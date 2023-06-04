using Infraestructure.Models;

namespace Domain;

public interface IOwnerDomain
{
    bool Create(Owner input);
    bool Update(int id, Owner input);
    bool Delete(int id);
}