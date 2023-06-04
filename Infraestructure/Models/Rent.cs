namespace Infraestructure.Models;
public class Rent
{
    public int Id_rent { get; set; }
    public String payment_type { get; set; }
    public double amount { get; set; }
    public int driver_id { get; set; }
    public bool isActive { get; set; }
}