public interface IDamage
{
    Dice GetDamagesRoll();
    int GetRange();

    double GetAttackSpeed();

    DamageType GetDamageType();

    WeaponType GetWeaponType();
}