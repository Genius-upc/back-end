namespace API.Input;
public class ReservationInput
{
    [Microsoft.Build.Framework.Required]
    public int Driver_id { get; set; }
}