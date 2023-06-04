using Infraestructure;
using Infraestructure.Models;
namespace Domain;

public class RentDomain : IRentDomain
{
    private IRentInfraestructure _rentInfraestructure;

    public RentDomain(IRentInfraestructure rentInfraestructure)
    {
        _rentInfraestructure = rentInfraestructure;
    }

    public bool Create(Rent input)
    {
        //Reglas de negocio
        if (input.amount <= 0) throw new Exception("El monto debe ser mayor a cero");
        return _rentInfraestructure.Create(input);
    }

    public bool Update(int id, Rent input)
    {
        return _rentInfraestructure.Update(id, input);
    }

    public bool Delete(int id)
    {
        return _rentInfraestructure.Delete(id);
    }
}