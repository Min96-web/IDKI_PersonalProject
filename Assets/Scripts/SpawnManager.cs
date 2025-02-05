using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Array
    public GameObject[] obstaclePrefabs;
    public GameObject[] coinPrefabs;

    //Define a delay before starting action(spawn obstacles/coins)
    private float startDelay = 0;
    //how often an action is repeated measure in seconds
    private float repeatRate = 5;

    //Boundaries of the road where obstacles and coins can appear
    public BoxCollider roadBoxCollider;
    //Size of the road where obstacles and coins can be spawned
    private Vector3 roadSize;
    //Manages game states,scores.
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnCoin", startDelay, repeatRate);
        roadSize = roadBoxCollider.GetComponent<BoxCollider>().size; //BoxCollider attached to roadBoxCollider, the size gives dimension(width,height,depth) of the collider in Vector 3
    }

    // Update is called once per frame
    void Update()
    {
    }
   
    void SpawnObstacle()
    {
        if (gameManager.isGameOver == false)
        {
            //Random x coordinate within the horizontal bounds of the road, and it ranges half road's width to the negative half, y of spawn position above the ground level z how far along the road the obstacle will spawn.
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