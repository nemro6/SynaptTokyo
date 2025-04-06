// Assets/Scripts/Skill/SkillDataBase.cs
using UnityEngine;

public enum SkillAttribute
{
    Kinetic, Plasma, Neural, EMP, Combustion
}

public abstract class SkillDataBase : ScriptableObject
{
    public string skillName;
    public SkillAttribute attribute;
    public int maxLevel;

    public float baseDamage;
    public float projectileSpeed;
    public float criticalRate;
    public int penetration;
    public int enemyBounce;
    public int wallBounce;
    public float duration;
    public float baseEnergy;

    public GameObject projectilePrefab;

    // �X�L�����G�ɖ��������Ƃ��̏���
    public abstract void OnHit(GameObject self, GameObject target);
}
