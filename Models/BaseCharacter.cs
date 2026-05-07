/// <summary>
/// Represents a Character's starting point for their stats. The guys you see on the character select screen.
/// </summary>
public class BaseCharacter
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public double Speed { get; set; }
    public double TearsUp { get; set; }
    public double BaseDamage { get; set; }
    public double DamageMult { get; set; }
    public double Range { get; set; }
    public double ShotSpeed { get; set; }
    public double Luck { get; set; }
}