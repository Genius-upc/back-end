using System.ComponentModel.DataAnnotations;

namespace API.Input;

public class OwnerInput
{
    [Microsoft.Build.Framework.Required]
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int age { get; set; }
    [DataType(DataType.PhoneNumber)]
    [MaxLength(9)]
    [MinLength(9)]
    public string phone { get; set; }
}