using Infraestructure.Models;
namespace Domain;
public interface IRentDomain
{
    bool Create(Rent input);
    bool Update(int id, Rent input);
    bool Delete(int id);
}