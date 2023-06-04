using Infraestructure.Context;
using Infraestructure.Models;

namespace Infraestructure;

public class OwnerParkInfra : IOwnerInfraestructure
{
    private GeniusDBContext _geniusDbContext;

    public OwnerParkInfra(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }
    public List<Owner> GetAll()
    {
        return _geniusDbContext.Owners.ToList();
    }

    public Owner GetById(int id)
    {
        return _geniusDbContext.Owners.Single(own => own.isActive && own.Id == id);
    }

    public bool Create(Owner input)
    {
        try
        {
            _geniusDbContext.Owners.Add(input);
            _geniusDbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool Update(int id, Owner input)
    {
        try
        {
            using (var transaction = _geniusDbContext.Database.BeginTransaction())
            {
                try
                {
                    var owner = _geniusDbContext.Owners.Find(id);
                    owner.firstName = input.firstName;
                    owner.lastName = input.lastName;
                    owner.age = owner.age;
                    owner.phone = owner.phone;

                    _geniusDbContext.Owners.Update(owner);
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
        var owner = _geniusDbContext.Owners.Find(id);
        owner.isActive = false;
        _geniusDbContext.Owners.Update(owner);
        _geniusDbContext.SaveChanges();
        return true;
    }
}