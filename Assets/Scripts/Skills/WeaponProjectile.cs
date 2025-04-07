using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    private WeaponData data;
    private float speed;
    private float lifeTime;

    public void Init(WeaponData weapon)
    {
        data = weapon;
        speed = data.projectileSpeed;
        lifeTime = data.duration;

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !string.IsNullOrEmpty(data.effectProcessorClassName))
        {
            System.Type type = System.Type.GetType(data.effectProcessorClassName);
            if (type != null)
            {
                var processor = System.Activator.CreateInstance(type) as IWeaponEffect;
                if (processor != null)
                {
                    processor.ApplyEffect(gameObject, other.gameObject, data);
                }
                else
                {
                    Debug.LogWarning($"クラス {type} は IWeaponEffect を実装していません");
                }
            }
            else
            {
                Debug.LogWarning($"指定されたクラスが見つかりません: {data.effectProcessorClassName}");
            }

            Destroy(gameObject);
        }
    }
}
