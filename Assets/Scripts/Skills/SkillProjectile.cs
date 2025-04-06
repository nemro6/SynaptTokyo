using UnityEngine;

public class SkillProjectile : MonoBehaviour
{
    public SkillDataBase skillData;

    private float lifeTimer;

    void Start()
    {
        lifeTimer = skillData.duration;
    }

    void Update()
    {
        if (skillData.projectileSpeed > 0)
            transform.Translate(Vector2.right * skillData.projectileSpeed * Time.deltaTime);

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        skillData.OnHit(gameObject, other.gameObject);
        Destroy(gameObject);
    }
}

