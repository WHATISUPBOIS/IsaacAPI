/// <summary>
/// Used to create a new BaseCharacter.
/// </summary>
public class BaseCharacterCreateRequest
{
    public string Name { get; set; }
    public double Speed { get; set; }
    public double TearsUp { get; set; }
    public double BaseDamage { get; set; }
    public double DamageMult { get; set; }
    public double Range { get; set; }
    public double ShotSpeed { get; set; }
    public double Luck { get; set; }
}