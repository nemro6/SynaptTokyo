using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP;
    public float defense = 100f;

    public float moveSpeed = 2f;
    private Transform target;

    [Header("�o���l�A�C�e��")]
    public GameObject expItemPrefab;
    [Range(0f, 1f)] public float dropChance = 1f; // ����100%�A���ƂŕύXOK

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
        // �_���[�W�v�Z���iATK & DEF �Ή��j
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
        Debug.Log("�G�����񂾁I");

        if (expItemPrefab != null && Random.value <= dropChance)
        {
            Instantiate(expItemPrefab, transform.position, Quaternion.identity);
            Debug.Log("�o���l�A�C�e�����h���b�v�I");
        }

        Destroy(gameObject);
    }
}
