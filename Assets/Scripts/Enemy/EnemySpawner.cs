using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 敵プレハブ
    public Transform player;       // プレイヤーへの参照
    public float spawnInterval = 2f;
    private float spawnTimer;

    public float spawnRadius = 8f; // プレイヤーからの距離（画面外）

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

        // プレイヤーの周囲にランダムで敵を出現させる
        Vector2 spawnDir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)player.position + spawnDir * spawnRadius;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
