using Infraestructure.OwnerType;

namespace Domain.OwnerTypeD;

public class OwnerTypeDomain : IOwnerTypeDomain
{
    private IOwnerTypeInfra _ownerTypeInfra;

    public OwnerTypeDomain(IOwnerTypeInfra ownerTypeInfra)
    {
        _ownerTypeInfra = ownerTypeInfra;
    }
    public bool Create(OwnerType input)
    {
        if (input.description.Length < 10)
            throw new Exception("Debe describir el nuevo tipo de duenio con mas de 25 caracteres");
        return _ownerTypeInfra.Create(input);
    }

    public bool Update(int id, OwnerType input)
    {
        return _ownerTypeInfra.Update(id, input);
    }

    public bool Delete(int id)
    {
        return _ownerTypeInfra.Delete(id);
    }
}