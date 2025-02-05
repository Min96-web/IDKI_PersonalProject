using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    //Game has ended
    public bool isGameOver;
    //Game is currently active
    public bool isGameRunning;
    //Difficulty level
    public float difficulty;

    //UI panel
    public GameObject gameOverUI;
    public GameObject titleUI;
    //Text to display the amount of coins collected
    public TextMeshProUGUI coinsAmountText;
    //the time player has survived
    public TextMeshProUGUI timeAliveText;
    //Play sounds
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip coinCollectedSound;

    //Tracks the number of coins collected
    private float coinsCollected;
    //How long the player has survived
    public float timeAlive;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        isGameRunning = false;
        gameOverUI.gameObject.SetActive(false);
        //every 5 seconds after an delay 5 seconds
        InvokeRepeating("IncreaseDifficulty", 5f, 5f);
    }

    private void Update()
    {
        if (isGameRunning)
        {
            //the time has passed sin the last frame add to TimeAlive accumulates the total time the game has runed.
            timeAlive += Time.deltaTime;
            //Convert the total time in seconds into a Time Span object which easily broken down into minutes and seconds
            var seconds = TimeSpan.FromSeconds(timeAlive).Seconds;
            var minutes = TimeSpan.FromSeconds(timeAlive).Minutes;
            // Ensure seconds are displayed with two digits 05 instead of 5 if they are less than 10
            timeAliveText.text = $"{minutes}:{(seconds < 10 ? "0" + seconds : seconds)}";
        }
    }

    public void StartGame()
    {
        isGameRunning = true;
        titleUI.gameObject.SetActive(false);
        difficulty = 1;
    }

    void IncreaseDifficulty()
    {
        //Increases the difficulty level over time
        difficulty += difficulty / 100;
    }

    public void GameOver()
    {
        playerAudio.PlayOneShot(crashSound, 1.0f);
        isGameOver = true;
        isGameRunning = false;
        gameOverUI.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        //reload the current scene to the restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CoinCollected()
    {
        //play sound
        playerAudio.PlayOneShot(coinCollectedSound, 1.0f);
        //increment the coin count
        coinsCollected++;
        //update the amount
        coinsAmountText.text = $"${coinsCollected}";
    }
}