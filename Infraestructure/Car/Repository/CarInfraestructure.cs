using Genius.Infraestructure.Models;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Genius.Infraestructure;

public class CarInfraestructure:ICarInfraestructure
{
    private GeniusDBContext _geniusDbContext;
    

    public CarInfraestructure(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }
    
    
    public async Task<List<Car>>GetAll()
    {
        //return _geniusDbContext.Cars.ToList();
        //return _geniusDbContext.Cars.Where(car=> car.IsActive).ToList(); //solo filtramos los activos con expresiones lambda
        return await _geniusDbContext.Cars.Where(car => car.IsActive).ToListAsync();
    }

    public List<Car> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Car GetById(int id)
    {
        return _geniusDbContext.Cars.Single(car=> car.IsActive && car.Id ==id); //solo se implementa en capa estructure
        


    }

    public async Task<bool> Create(Car car)
    {  {
            try
            {
                /* Driver driver = new Driver();
                 driver.Name = name;
                 driver.Age = age;
                 driver.License = license;
                 driver.Phone = phone;
               
                */
                car.IsActive = true;
               await _geniusDbContext.Cars.AddAsync(car);
               await _geniusDbContext.SaveChangesAsync();
        
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }

    public bool Update(int id, Car input)
    {
        try
        {
            var car = _geniusDbContext.Cars.Find(id);
            car.Modelo = input.Modelo;
            car.Placa = input.Placa;
            _geniusDbContext.SaveChanges();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        var car = _geniusDbContext.Cars.Find(id); //obtengo con id
        car.IsActive = false;
        _geniusDbContext.Cars.Remove(car);
        _geniusDbContext.Cars.Update(car);
        _geniusDbContext.SaveChanges();
        return true;
    }
}