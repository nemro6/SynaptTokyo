using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // 弾の速度
    public float lifeTime = 3f; // 自動消滅時間（秒）

    void Start()
    {
        Destroy(gameObject, lifeTime); // 一定時間後に自動削除
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                float skillPower = 20f; // 仮の威力
                float atk = 100f;       // プレイヤーの攻撃力（今は仮で固定）
                bool isCrit = Random.value < 0.1f; // 10%クリティカル（仮）

                enemy.TakeDamage(skillPower, atk, isCrit);
            }

            Destroy(gameObject); // 弾を消す
        }
    }

}
