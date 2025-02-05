using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls the movement of GameObjects(Obstacles and coins)
public class MoveBackwards : MonoBehaviour
{
    //Constant speed for movement
    private const float Speed = 20.0f;
    // A boundary in z when the GameObject moves pst this point it will be destroyed.
    private const float LeftBound = -15.0f;
    //The direction of movement true moves forward,false moves backward
    public bool reverse;
    //check game state
    private GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Check game is not over and still running
        if (!gameManager.isGameOver && gameManager.isGameRunning)
            //reverse true then moves forward otherwise move backward and the movement is scaled by Time.deltaTime also affected by gamManger.difficulty
            transform.Translate(reverse ? Vector3.forward : Vector3.back * (Time.deltaTime * Speed * gameManager.difficulty));
        //z position less than leftBound and gameobject has tag if both are met then destroys and removing from the scene.
        if (transform.position.z < LeftBound && (gameObject.CompareTag("Obstacle") || gameObject.CompareTag("Coin")))
            Destroy(gameObject);
    }
}