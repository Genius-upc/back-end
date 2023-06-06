using System.ComponentModel.DataAnnotations;

namespace API.Input;

public class OwnerTypeInput
{
    [DataType(DataType.Text)]
    [MaxLength(50)]
    [MinLength(10)]
    public string nameType { get; set; }
    [DataType(DataType.Text)]
    [MaxLength(50)]
    [MinLength(10)]
    public string description { get; set; }
}