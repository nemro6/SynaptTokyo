using UnityEngine;

public abstract class WeaponEffectProcessor : ScriptableObject
{
    public abstract void ApplyEffect(GameObject projectile, GameObject target, WeaponData data);
}

