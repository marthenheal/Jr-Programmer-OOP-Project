using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI scoreText;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;

    public bool isGameActive;
    public bool isGameOver;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        scoreText.text = "SCORE: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver) //adding ability to pause
        {
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0f;
                isGameActive = false;
                pauseScreen.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                isGameActive = true;
                pauseScreen.SetActive(false);
            }
        }
    }

    public void StartGame() //ABSTRACTION
    {
        isGameActive = true;
        isGameOver = false;
        if (DataManager.Instance != null)
        {
            playerName.text = "Pilot's name: " + DataManager.Instance.playerName;
        }
    }

    public void GameOver() //ABSTRACTION
    {
        isGameActive = false;
        isGameOver = true;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame() //ABSTRACTION
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu() //ABSTRACTION
    {
        SceneManager.LoadScene(0);
    }

    public void AddScore(int value) //ABSTRACTION
    {
        score += value;
        scoreText.text = "SCORE: " + score;
    }
}
