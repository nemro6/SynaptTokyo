using UnityEngine;

public class RapidBurstEffect : IWeaponEffect
{
    public void ApplyEffect(GameObject projectile, GameObject target, WeaponData data)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(data.baseDamage, 100f, false);
        }
    }
}
