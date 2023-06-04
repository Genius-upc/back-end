using Infraestructure;
using Infraestructure.Models;

namespace Domain;

public class OwnerDomain : IOwnerDomain
{
    private IOwnerInfraestructure _ownerInfraestructure;

    public OwnerDomain(IOwnerInfraestructure ownerInfraestructure)
    {
        _ownerInfraestructure = ownerInfraestructure;
    }
    
    public bool Create(Owner input)
    {
        //Reglas de negocio
        if (input.age < 18) throw new Exception("Debes ser mayor de edad");
        if (input.phone.Length != 9) throw new Exception("Ingrese un numero de celular valido");
        return _ownerInfraestructure.Create(input);
    }

    public bool Update(int id, Owner input)
    {
        return _ownerInfraestructure.Update(id, input);
    }

    public bool Delete(int id)
    {
        return _ownerInfraestructure.Delete(id);
    }
}