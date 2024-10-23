using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwards : MonoBehaviour
{
    private const float Speed = 20.0f;
    private const float LeftBound = -15.0f;
    public bool reverse;
    private GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameManager.isGameOver && gameManager.isGameRunning)
            transform.Translate(reverse ? Vector3.forward : Vector3.back * (Time.deltaTime * Speed * gameManager.difficulty));

        if (transform.position.z < LeftBound && (gameObject.CompareTag("Obstacle") || gameObject.CompareTag("Coin")))
            Destroy(gameObject);
    }
}