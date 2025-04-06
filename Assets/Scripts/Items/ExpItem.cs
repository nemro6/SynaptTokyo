using UnityEngine;

public class ExpItem : MonoBehaviour
{
    public int expValue = 10;

    private Transform player;
    public float magnetDistance = 3f;     // �z�����n�܂鋗��
    public float moveSpeed = 5f;          // �z�����̃X�s�[�h

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
            // �z���񂹂�����ֈړ�
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

            Debug.Log($"�o���l +{expValue} �l���I");
            Destroy(gameObject);
        }
    }
}
