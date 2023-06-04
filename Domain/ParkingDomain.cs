using Infraestructure;
using Infraestructure.Models;
namespace Domain;

public class ParkingDomain : IParkingDomain
{
    private IParkingInfraestructure _parkingInfraestructure;

    public ParkingDomain(IParkingInfraestructure parkingInfraestructure)
    {
        _parkingInfraestructure = parkingInfraestructure;
    }

    public bool Create(Parking input)
    {
        //Reglas de negocio
        if (input.costPerHour <= 0) throw new Exception("El costo por hora debe ser mayor a cero");
        if (input.spaces <= 0) throw new Exception("El número de espacios debe ser mayor a cero");
        return _parkingInfraestructure.Create(input);
    }

    public bool Update(int id, Parking input)
    {
        return _parkingInfraestructure.Update(id, input);
    }

    public bool Delete(int id)
    {
        return _parkingInfraestructure.Delete(id);
    }
}