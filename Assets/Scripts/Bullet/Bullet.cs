using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // �e�̑��x
    public float lifeTime = 3f; // �������Ŏ��ԁi�b�j

    void Start()
    {
        Destroy(gameObject, lifeTime); // ��莞�Ԍ�Ɏ����폜
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
                float skillPower = 20f; // ���̈З�
                float atk = 100f;       // �v���C���[�̍U���́i���͉��ŌŒ�j
                bool isCrit = Random.value < 0.1f; // 10%�N���e�B�J���i���j

                enemy.TakeDamage(skillPower, atk, isCrit);
            }

            Destroy(gameObject); // �e������
        }
    }

}
