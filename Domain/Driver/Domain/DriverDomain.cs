using Genius.Infraestructure;
using Genius.Infraestructure.Models;

namespace Genius.Domain;

public class DriverDomain : IDriverDomain
{
    private IDriverInfraestructure _driverInfraestructure;

    public DriverDomain(IDriverInfraestructure driverInfraestructure)
    {
        _driverInfraestructure = driverInfraestructure;
        
    }

    public Task<List<Driver>> GetAll()
    {
        return _driverInfraestructure.GetAll();
    }

    //public bool Create(string name, int age, string license, string phone)
    public async Task<bool> CreateAsync(Driver input)
    {
        if (input.Name.Length < 3) throw new Exception("less than 3 char");
        if (input.Name.Length > 15) throw new Exception("more than 15 char");
          //return _driverInfraestructure.Create(name,age,license,phone);
          return await _driverInfraestructure.CreateAsync(input);
    }

    public Task<bool> Update(int id, Driver driver)
    {
        return _driverInfraestructure.Update(id, driver);
    }

    public Task<bool> Delete(int id)
    {
        return _driverInfraestructure.Delete(id);
    }

   
}