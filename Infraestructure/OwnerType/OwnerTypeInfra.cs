using Infraestructure.Context;

namespace Infraestructure.OwnerType;

public class OwnerTypeInfra : IOwnerTypeInfra
{
    private GeniusDBContext _geniusDbContext;

    public OwnerTypeInfra(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }

    public List<OwnerType> GetAll()
    {
        return _geniusDbContext.OwnerTypes.ToList();
    }

    public OwnerType GetById(int id)
    {
        return _geniusDbContext.OwnerTypes.Single(ot => ot.isActive && ot.idOwnerType == id);
    }

    public bool Create(OwnerType input)
    {
        try
        {
            _geniusDbContext.OwnerTypes.Add(input);
            _geniusDbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool Update(int id, OwnerType input)
    {
        try
        {
            using (var transaction = _geniusDbContext.Database.BeginTransaction())
            {
                try
                {
                    var ownerType = _geniusDbContext.OwnerTypes.Find(id);
                    ownerType.nameType = input.nameType;
                    ownerType.description = input.description;
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
        var ownerType = _geniusDbContext.OwnerTypes.Find(id);
        ownerType.isActive = false;
        _geniusDbContext.OwnerTypes.Update(ownerType);
        _geniusDbContext.SaveChanges();
        return true;
    }
}