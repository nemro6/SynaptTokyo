using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Kinetic/RapidBurst")]
public class RapidBurstSkill : SkillDataBase
{
    public override void OnHit(GameObject self, GameObject target)
    {
        // ’Êí‚Ìƒ_ƒ[ƒWˆ—‚Ì‚İ
        Debug.Log("Rapid Burst hit");
    }
}
