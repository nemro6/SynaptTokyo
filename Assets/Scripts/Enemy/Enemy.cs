using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP;
    public float defense = 100f;

    public float moveSpeed = 2f;
    private Transform target;

    [Header("経験値アイテム")]
    public GameObject expItemPrefab;
    [Range(0f, 1f)] public float dropChance = 1f; // 今は100%、あとで変更OK

    void Start()
    {
        currentHP = maxHP;
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(float skillPower, float attackerATK, bool isCritical)
    {
        // ダメージ計算式（ATK & DEF 対応）
        float damage = skillPower * (attackerATK / (attackerATK + defense));
        if (isCritical)
            damage *= 1.25f;

        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("敵が死んだ！");

        if (expItemPrefab != null && Random.value <= dropChance)
        {
            Instantiate(expItemPrefab, transform.position, Quaternion.identity);
            Debug.Log("経験値アイテムをドロップ！");
        }

        Destroy(gameObject);
    }
}
