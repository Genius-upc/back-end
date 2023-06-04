using System.ComponentModel.DataAnnotations;
namespace API.Input;
public class RentInput
{
    [Microsoft.Build.Framework.Required]
    public string payment_type { get; set; }
    [Microsoft.Build.Framework.Required]
    public double amount { get; set; }
    [Microsoft.Build.Framework.Required]
    public int Driver_id { get; set; }
}