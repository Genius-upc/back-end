namespace Infraestructure.Models;
public class Parking
{
    public int id_parking { get; set; }
    public double costPerHour { get; set; }
    public String address { get; set; }
    public int spaces { get; set; }
    public int driver_id { get; set; }
    public bool isActive { get; set; }
}