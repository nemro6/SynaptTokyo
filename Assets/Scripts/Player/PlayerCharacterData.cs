using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/Player Character")]
public class PlayerCharacterData : ScriptableObject
{
    public string characterName;
    public Sprite characterPortrait;         // キャラアイコン（UI用）
    public GameObject characterPrefab;       // 実際に使うプレイヤーのプレハブ

    [Header("スキル関連")]
    public SkillData initialSkill;           // 初期武器
    public SkillData characterSkill;         // キャラクタースキル（今後追加予定）

    [Header("ステータス")]
    public float moveSpeed = 5f;             // 移動速度
    public float maxHP = 100f;               // HP
    public float shieldMax = 100f;           // シールド
    public float defense = 100f;             // 防御力
    public float attack = 100f;              // 攻撃力
    public float criticalRate = 0.1f;        // 会心率（0.1 = 10%）

    [Header("攻撃関連")]
    public int projectileCount = 1;          // 弾数
    public float projectileSize = 1f;        // 攻撃範囲（サイズ倍率）
    public float duration = 1f;              // 有効時間（燃焼など）
    public float energyEfficiency = 1f;      // エネルギー効率（1.0 = 等倍）

    [Header("特殊効果")]
    public int pierce = 0;                   // 貫通力
    public int bounceEnemy = 0;              // 敵反射回数
    public int bounceWall = 0;               // 壁反射回数

    [Header("その他")]
    public float itemPickupRange = 1f;       // アイテム回収範囲（倍率）
}
