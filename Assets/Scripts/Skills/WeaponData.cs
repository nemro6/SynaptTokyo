using UnityEngine;

public enum WeaponAttribute
{
    Kinetic, Plasma, Neural, EMP, Combustion
}

[CreateAssetMenu(menuName = "Weapons/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public WeaponAttribute attribute;
    public int maxLevel;

    public float baseDamage;
    public float projectileSpeed;
    public float criticalRate;
    public int penetration;
    public int enemyBounce;
    public int wallBounce;
    public float duration;
    public float baseEnergy;
    public int shotCount;

    public GameObject projectilePrefab;

    public string effectProcessorClassName;
}
