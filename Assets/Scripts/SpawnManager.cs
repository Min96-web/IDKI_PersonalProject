using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject roadPrefab;

    private Vector3 spawnPosition = new Vector3(25, 0, 0);

    private float startDelay = 2;

    private float repeatRate = 2;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRoad", 0.85f, 7.9f);
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRoad()
    {
        if (playerControllerScript.gameOver == false)
        {
            Vector3 spawnPos = new Vector3(56.6f, -131.52f, 225f);
            Instantiate(roadPrefab, spawnPosition, roadPrefab.transform.rotation);
        }
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}