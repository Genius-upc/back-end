using Genius.Infraestructure.Models;

namespace Genius.Infraestructure;

public interface ICarInfraestructure
{
    Task <List<Car>> GetAll();
    List<Car> GetByName(string name);
    Car GetById(int id); 
    //bool Create(string name, int age, string license, string phone);
    Task<bool> Create(Car input);
    bool Update(int id, Car input);
    bool Delete(int id);
    
    
}