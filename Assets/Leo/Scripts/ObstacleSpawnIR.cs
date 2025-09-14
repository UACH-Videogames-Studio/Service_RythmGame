using System.Collections;
using UnityEngine;
public class ObstacleSpawnIR : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField][Tooltip("Low values, like 1 or less")] private float timeBetweenSpawn;
    [SerializeField][Tooltip("This value is converted, for example an 30 is a 30%")] private float percentForSpawnObstacle;
    [SerializeField] private Vector2 spawnPoint;
    [SerializeField] private float obstacleVelocity;
    private bool isSpawning = true;
    private float randomValue;
    private int randomIndex;
    private void Awake()
    {
        StartCoroutine(TimeBetween());
    }
    private void Update()
    {
        if (!isSpawning) return;
        randomValue = Random.Range(0f, 100f);
        if (randomValue < percentForSpawnObstacle) ChoseObstacle();
    }
    private void ChoseObstacle()
    {
        isSpawning = false;
        randomIndex = Random.Range(0, obstacles.Length);
        SpawnObstacle(obstacles[randomIndex]);
    }
    private void SpawnObstacle(GameObject prefab)
    {
        GameObject instance = Instantiate(prefab, spawnPoint, Quaternion.identity);
        ObstacleScript obstacleScript = instance.GetComponent<ObstacleScript>();
        obstacleScript.SetVelocity(obstacleVelocity);
        StartCoroutine(TimeBetween());
    }
    private IEnumerator TimeBetween()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        isSpawning = true;
    }
}