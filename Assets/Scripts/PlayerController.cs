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
        playerRigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOver == false)
        {
            var moveDirection = Input.GetAxis("Horizontal");
            if (moveDirection != 0)
            {
                playerRigidbody.Move(
                    new Vector3(moveDirection * 4f, transform.position.y, transform.position.z),
                    Quaternion.Euler(0, 0, 0));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
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