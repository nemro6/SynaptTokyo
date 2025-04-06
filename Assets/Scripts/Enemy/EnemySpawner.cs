using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // �G�v���n�u
    public Transform player;       // �v���C���[�ւ̎Q��
    public float spawnInterval = 2f;
    private float spawnTimer;

    public float spawnRadius = 8f; // �v���C���[����̋����i��ʊO�j

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || player == null) return;

        // �v���C���[�̎��͂Ƀ����_���œG���o��������
        Vector2 spawnDir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)player.position + spawnDir * spawnRadius;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
