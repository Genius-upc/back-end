using Infraestructure.Models;

namespace Infraestructure;

public interface IPrivateInfrastructure 
{
    List<Private> GetAll();
    Private GetById(int id);
    bool Create(Private input);
    bool Update(int id, Private input);
    bool Delete(int id);
}