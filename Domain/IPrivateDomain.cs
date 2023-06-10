using Infraestructure.Models;

namespace Domain;

public interface IPrivateDomain
{
    bool Create(Private input);
    bool Update(int id, Private input);
    bool Delete(int id);
}