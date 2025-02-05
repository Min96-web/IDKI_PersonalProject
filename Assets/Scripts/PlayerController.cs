using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody playerRigidbody;
    public ParticleSystem explosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        //Retrieves Rigidbody attached to same GameObject,it responsible for physics interactions, allow object to move and react to forces.
        playerRigidbody = GetComponent<Rigidbody>();
        //Searches for GameManager in the scene, access gamemanagement functions such as scoring,level management.
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOver == false)
        {
            //Input for horizontal movement,
            var moveDirection = Input.GetAxis("Horizontal");
            //Input from player
            if (moveDirection != 0)
            {
                //Move player
                playerRigidbody.Move(
                    new Vector3(moveDirection * 4f, transform.position.y, transform.position.z), //new vector for movement
                    Quaternion.Euler(0, 0, 0)); //Rotation for the movement as player's curren rotation
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision) // It calls when the object is attached to collides with another object.
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionParticles.Play();
            gameManager.GameOver();
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            gameManager.CoinCollected();
            Destroy(collision.gameObject);
        }
    }
}