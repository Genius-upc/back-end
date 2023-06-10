using System.ComponentModel.DataAnnotations;

namespace Genius.API.Input;

public class DriverInput
{
    [Required]
    [MaxLength(20)]
    [MinLength(3)]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string License { get; set; }
    [Required]
    public string Phone { get; set; }
    
}