/// <summary>
/// Used to create a new Item.
/// </summary>
public class ItemCreateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double SpeedUp { get; set; }
    public double DamageUp { get; set; }
    public double DamageMult{ get; set; }
    public double TearsUp { get; set; }
    public double FireRateUp { get; set; }
    public double RangeUp { get; set; }
    public double ShotSpeedUp { get; set; }
    public double LuckUp { get; set; }
}