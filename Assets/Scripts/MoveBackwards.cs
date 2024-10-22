using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwards : MonoBehaviour
{
    private float speed = 10f;
    private float destroyBound = -15f;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.back * (Time.deltaTime * speed));
        }

        if (transform.position.x < destroyBound &&
            (gameObject.CompareTag("Obstacle") || gameObject.CompareTag("Road")))
            Destroy(gameObject);
    }
}