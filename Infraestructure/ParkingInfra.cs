using Infraestructure.Context;
using Infraestructure.Models;
namespace Infraestructure;

public class ParkingInfra : IParkingInfraestructure
{
    private GeniusDBContext _geniusDbContext;

    public ParkingInfra(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }

    public List<Parking> GetAll()
    {
        return _geniusDbContext.Parkings.ToList();
    }

    public Parking GetById(int id)
    {
        return _geniusDbContext.Parkings.Single(park => park.isActive && park.id_parking == id);
    }

    public bool Create(Parking input)
    {
        try
        {
            _geniusDbContext.Parkings.Add(input);
            _geniusDbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool Update(int id, Parking input)
    {
        try
        {
            using (var transaction = _geniusDbContext.Database.BeginTransaction())
            {
                try
                {
                    var parking = _geniusDbContext.Parkings.Find(id);
                    parking.costPerHour = input.costPerHour;
                    parking.address = input.address;
                    parking.spaces = input.spaces;
                    parking.driver_id = input.driver_id;

                    _geniusDbContext.Parkings.Update(parking);
                    _geniusDbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool Delete(int id)
    {
        var parking = _geniusDbContext.Parkings.Find(id);
        parking.isActive = false;
        _geniusDbContext.Parkings.Update(parking);
        _geniusDbContext.SaveChanges();
        return true;
    }
}