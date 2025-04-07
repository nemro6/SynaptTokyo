using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP;
    public float defense = 100f;
    public float moveSpeed = 2f;

    private Transform target;

    public GameObject expItemPrefab;

    void Start()
    {
        currentHP = maxHP;
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (target == null) return;
        Vector2 dir = (target.position - transform.position).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(float skillPower, float attackerATK, bool isCritical)
    {
        float damage = skillPower * (attackerATK / (attackerATK + defense));
        if (isCritical) damage *= 1.25f;

        currentHP -= damage;

        if (currentHP <= 0)
        {
            if (expItemPrefab != null)
            {
                Instantiate(expItemPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
