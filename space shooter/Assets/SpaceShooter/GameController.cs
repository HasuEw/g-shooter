using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemyEye;
    public Vector3 spawnValues;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GameObject[] obstaclePrefabs = new GameObject[0];

    private int obstacleNumber;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                obstacleNumber = Random.Range(0, obstaclePrefabs.Length);
                Instantiate(obstaclePrefabs[obstacleNumber], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
