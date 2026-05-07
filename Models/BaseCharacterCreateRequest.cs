using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Used to create a new BaseCharacter.
/// </summary>
public class BaseCharacterCreateRequest
{
    [Required]
    public required string Name { get; set; }

    [Required]
    [Range(0.00d, 2.00d)]
    [DefaultValue(1.00d)]
    public double Speed { get; set; }

    [Required]
    [Range(-10.00d, 10.00d)]
    [DefaultValue(0.00d)]
    public double TearsUp { get; set; }

    [Required]
    [Range(0.00d, 100.00d)]
    [DefaultValue(3.50d)]
    public double BaseDamage { get; set; }

    [Required]
    [Range(0.00d, 100.00d)]
    [DefaultValue(1.00d)]
    public double DamageMult { get; set; }

    [Required]
    [Range(0.00d, 100.00d)]
    [DefaultValue(6.50d)]
    public double Range { get; set; }

    [Required]
    [Range(0.00d, 100.00d)]
    [DefaultValue(1.00d)]
    public double ShotSpeed { get; set; }

    [Required]
    [Range(-100.00d, 100.00d)]
    [DefaultValue(0.00d)]
    public double Luck { get; set; }
}