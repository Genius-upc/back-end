using Genius.Infraestructure.Models;

namespace Genius.Infraestructure;

public interface IDriverInfraestructure
{
    Task<List<Driver>> GetAll();
    Task<List<Driver>> GetByName(string name);
    Driver GetById(int id); 
    //bool Create(string name, int age, string license, string phone);
    Task <bool> CreateAsync(Driver input);
    Task <bool>Update(int id, Driver input);
    Task <bool> Delete(int id);
    
    
}