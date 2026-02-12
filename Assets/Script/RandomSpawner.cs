using UnityEngine;
public class RandomSpawner : MonoBehaviour
{
    [Header("Pieces to Spawn")]
    [SerializeField]
    GameObject[] piecePrefabs;

    [Header("Time between waves")]
    [SerializeField]
    float timeBetweenSpawns;
    private float spawnTimer = 0;

    [Header("Pieces to spawn for each wave")]
    [SerializeField]
    public int spawnCount = 10;

    [Header("2 points to spawn between. Set 1 to lower left point")]
    [SerializeField]
    Transform corner1;
    [SerializeField]
    Transform corner2;

    void Start()
    {
        spawnTimer = 0;
    }
    private void Update()
    {
        if (spawnTimer > timeBetweenSpawns)
        {
            DoSpawning();
            spawnTimer = 0;
        }
        else spawnTimer += Time.deltaTime;
    }

    private void DoSpawning()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float corner1X = corner1.position.x;
            float corner1Y = corner1.position.y;
            Vector3 randomSpawnPos = new Vector3(corner1X + Random.Range(0, corner2.position.x - corner1X), transform.position.y, corner1Y + Random.Range(0, corner2.position.y - corner1Y));
            int randomIndex = Random.Range(0, piecePrefabs.Length);

            Instantiate(piecePrefabs[randomIndex], randomSpawnPos, new Quaternion());
        }
    }
}