using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Kinetic/RapidBurst")]
public class RapidBurstSkill : SkillDataBase
{
    public override void OnHit(GameObject self, GameObject target)
    {
        // �ʏ�̃_���[�W�����̂�
        Debug.Log("Rapid Burst hit");
    }
}
