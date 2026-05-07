using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Used to create a new Item.
/// </summary>
public class ItemCreateRequest
{
    [Required]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    [Range(-2.0d, 2.0d)]
    [DefaultValue(0.00d)]
    public double SpeedUp { get; set; }

    [Required]
    [Range(-100.00d, 100.00d)]
    [DefaultValue(0.00d)]
    public double DamageUp { get; set; }

    [Required]
    [Range(0.00d, 100.00d)]
    [DefaultValue(1.00d)]
    public double DamageMult{ get; set; }

    [Required]
    [Range(-100.00d, 100.00d)]
    [DefaultValue(0.00d)]
    public double TearsUp { get; set; }

    [Required]
    [Range(-100.00d, 100.00d)]
    [DefaultValue(0.00d)]
    public double FireRateUp { get; set; }

    [Required]
    [Range(-100.00d, 100.00d)]
    [DefaultValue(0.00d)]
    public double RangeUp { get; set; }

    [Required]
    [Range(-100.00d, 100.00d)]
    [DefaultValue(0.00d)]
    public double ShotSpeedUp { get; set; }

    [Required]
    [Range(-100.00d, 100.00d)]
    [DefaultValue(0.00d)]
    public double LuckUp { get; set; }
}