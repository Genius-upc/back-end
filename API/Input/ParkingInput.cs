using System.ComponentModel.DataAnnotations;
namespace API.Input;
public class ParkingInput
{
    [Microsoft.Build.Framework.Required]
    public double costPerHour { get; set; }
    [Microsoft.Build.Framework.Required]
    public string address { get; set; }
    [Microsoft.Build.Framework.Required]
    public int spaces { get; set; }
    [Microsoft.Build.Framework.Required]
    public int Driver_id { get; set; }
}