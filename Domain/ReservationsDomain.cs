using Infraestructure;
using Infraestructure.Models;

namespace Domain;

public class ReservationsDomain: IReservationsDomain
{
    private IReservationsInfraestructure _reservationsInfraestructure;


    public ReservationsDomain(IReservationsInfraestructure reservationsInfraestructure)
    {
        _reservationsInfraestructure = reservationsInfraestructure;
    }

    public bool Create(Reservations input)
    {
        //Reglas de negocio
    }

    public bool Update(int id, Reservations input)
    {
        return _reservationsInfraestructure.Update(id, input);
    }

    public bool Delete(int id)
    {
        return _reservationsInfraestructure.Delete(id);
    }
}