using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] coinPrefabs;

    private float startDelay = 0;
    private float repeatRate = 5;

    public BoxCollider roadBoxCollider;
    private Vector3 roadSize;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnCoin", startDelay, repeatRate);
        roadSize = roadBoxCollider.GetComponent<BoxCollider>().size;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacle()
    {
        if (gameManager.isGameOver == false)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-roadSize.x / 2, roadSize.x / 2), 2, 220);
            var randomIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomIndex], spawnPosition, obstaclePrefabs[randomIndex].transform.rotation);
        }
    }
    void SpawnCoin()
    {
        if (gameManager.isGameOver == false)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-roadSize.x / 2, roadSize.x/ 2), 2, 220);
            var randomIndex = Random.Range(0, coinPrefabs.Length);
            Instantiate(coinPrefabs[randomIndex], spawnPosition, obstaclePrefabs[randomIndex].transform.rotation);
        }
    }
}