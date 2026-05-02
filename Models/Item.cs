using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Represents an Item. Has an Id, Name, Description, and stat modifiers.
/// </summary>
public class Item
{
    // Id is a primary key, but I want to enter it manually.
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double SpeedUp { get; set; }

    // Regular Damage Ups. eg. Pentagram gives +1, Magic Mushroom gives +0.3
    public double DamageUp { get; set; }

    // Damage Multipliers. eg. Cricket's Head and Magic Mushroom give *1.5
    public double DamageMult{ get; set; }

    // Regular Tears Ups. eg. The Sad Onion gives +0.7.
    public double TearsUp { get; set; }

    // Direct Fire Rate modifiers. eg. Cricket's Body gives +0.5
    public double FireRateUp { get; set; }
    
    public double RangeUp { get; set; }
    public double ShotSpeedUp { get; set; }
    public double LuckUp { get; set; }
}