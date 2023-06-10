using Genius.Infraestructure.Models;
namespace Genius.Domain;

public interface IDriverDomain
{
    public Task<List<Driver>> GetAll();
    
    //bool Create(string name, int age, string license, string phone);
   
    
    Task <bool>CreateAsync(Driver input);
    Task <bool>Update(int id, Driver input);
    Task<bool> Delete(int id);
}