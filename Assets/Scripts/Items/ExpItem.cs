using UnityEngine;

public class ExpItem : MonoBehaviour
{
    public int expValue = 10;

    private Transform player;
    public float magnetDistance = 3f;     // 吸引が始まる距離
    public float moveSpeed = 5f;          // 吸引時のスピード

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < magnetDistance)
        {
            // 吸い寄せる方向へ移動
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.GainExp(expValue);
            }

            Debug.Log($"経験値 +{expValue} 獲得！");
            Destroy(gameObject);
        }
    }
}
