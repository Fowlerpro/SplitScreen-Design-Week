using UnityEngine;
public class RandomSpawner : MonoBehaviour
{
    public GameObject piecePrefab;

    public int spawnCount = 10;

    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector2 spawnPosition = new Vector2(randomX, randomY);

            Instantiate(piecePrefab, spawnPosition, Quaternion.identity);

        }
    }
}