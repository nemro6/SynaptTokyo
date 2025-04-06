using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/Player Character")]
public class PlayerCharacterData : ScriptableObject
{
    public string characterName;
    public Sprite characterPortrait;         // �L�����A�C�R���iUI�p�j
    public GameObject characterPrefab;       // ���ۂɎg���v���C���[�̃v���n�u

    [Header("�X�L���֘A")]
    public SkillData initialSkill;           // ��������
    public SkillData characterSkill;         // �L�����N�^�[�X�L���i����ǉ��\��j

    [Header("�X�e�[�^�X")]
    public float moveSpeed = 5f;             // �ړ����x
    public float maxHP = 100f;               // HP
    public float shieldMax = 100f;           // �V�[���h
    public float defense = 100f;             // �h���
    public float attack = 100f;              // �U����
    public float criticalRate = 0.1f;        // ��S���i0.1 = 10%�j

    [Header("�U���֘A")]
    public int projectileCount = 1;          // �e��
    public float projectileSize = 1f;        // �U���͈́i�T�C�Y�{���j
    public float duration = 1f;              // �L�����ԁi�R�ĂȂǁj
    public float energyEfficiency = 1f;      // �G�l���M�[�����i1.0 = ���{�j

    [Header("�������")]
    public int pierce = 0;                   // �ђʗ�
    public int bounceEnemy = 0;              // �G���ˉ�
    public int bounceWall = 0;               // �ǔ��ˉ�

    [Header("���̑�")]
    public float itemPickupRange = 1f;       // �A�C�e������͈́i�{���j
}
