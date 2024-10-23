using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public bool isGameRunning;
    public float difficulty;

    public GameObject gameOverUI;
    public GameObject titleUI;
    public TextMeshProUGUI coinsAmountText;
    public TextMeshProUGUI timeAliveText;

    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip coinCollectedSound;

    private float coinsCollected;
    public float timeAlive;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        isGameRunning = false;
        gameOverUI.gameObject.SetActive(false);
        InvokeRepeating("IncreaseDifficulty", 5f, 5f);
    }

    private void Update()
    {
        if (isGameRunning)
        {
            timeAlive += Time.deltaTime;
            var seconds = TimeSpan.FromSeconds(timeAlive).Seconds;
            var minutes = TimeSpan.FromSeconds(timeAlive).Minutes;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CoinCollected()
    {
        playerAudio.PlayOneShot(coinCollectedSound, 1.0f);
        coinsCollected++;
        coinsAmountText.text = $"${coinsCollected}";
    }
}