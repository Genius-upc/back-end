using Infraestructure.OwnerType;

namespace Domain.OwnerTypeD;

public interface IOwnerTypeDomain
{
    bool Create(OwnerType input);
    bool Update(int id, OwnerType input);
    bool Delete(int id);
}