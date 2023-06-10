namespace Genius.Infraestructure.Models;

public class Driver
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string License { get; set; }
    public string Phone { get; set; }
    
    public  List<Car> Cars { get; set; }
    
    public bool IsActive { get; set; }

}