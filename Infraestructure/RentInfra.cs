using Infraestructure.Context;
using Infraestructure.Models;
namespace Infraestructure;

public class RentInfra : IRentInfraestructure
{
    private GeniusDBContext _geniusDbContext;

    public RentInfra(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }

    public List<Rent> GetAll()
    {
        return _geniusDbContext.Rents.ToList();
    }

    public Rent GetById(int id)
    {
        return _geniusDbContext.Rents.Single(rent => rent.isActive && rent.Id_rent == id);
    }

    public bool Create(Rent input)
    {
        try
        {
            _geniusDbContext.Rents.Add(input);
            _geniusDbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool Update(int id, Rent input)
    {
        try
        {
            using (var transaction = _geniusDbContext.Database.BeginTransaction())
            {
                try
                {
                    var rent = _geniusDbContext.Rents.Find(id);
                    rent.payment_type = input.payment_type;
                    rent.amount = input.amount;
                    rent.driver_id = input.driver_id;

                    _geniusDbContext.Rents.Update(rent);
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
        var rent = _geniusDbContext.Rents.Find(id);
        rent.isActive = false;
        _geniusDbContext.Rents.Update(rent);
        _geniusDbContext.SaveChanges();
        return true;
    }
}