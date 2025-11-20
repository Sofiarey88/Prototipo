using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // Tu prefab del enemigo
    public float respawnDelay = 1f;     // Segundos para reaparecer

    public void RespawnEnemy()
    {
        Invoke(nameof(SpawnEnemy), respawnDelay);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}

