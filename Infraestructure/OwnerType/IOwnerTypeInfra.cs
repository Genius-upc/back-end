namespace Infraestructure.OwnerType;

public interface IOwnerTypeInfra
{
    List<OwnerType> GetAll();
    OwnerType GetById(int id);
    bool Create(OwnerType input);
    bool Update(int id, OwnerType input);
    bool Delete(int id);
}