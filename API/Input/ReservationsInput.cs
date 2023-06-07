using System.ComponentModel.DataAnnotations;
namespace API.Input;

public class ReservationsInput
{
    [Microsoft.Build.Framework.Required]
    public int idReservations { get; set; }
    [Microsoft.Build.Framework.Required]
    public int Driver_id { get; set; }
}