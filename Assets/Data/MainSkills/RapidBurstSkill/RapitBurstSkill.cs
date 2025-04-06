using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Kinetic/RapidBurst")]
public class RapidBurstSkill : SkillDataBase
{
    public override void OnHit(GameObject self, GameObject target)
    {
        // 通常のダメージ処理のみ
        Debug.Log("Rapid Burst hit");
    }
}
