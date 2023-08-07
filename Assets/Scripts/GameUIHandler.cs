using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive) //adding ability to pause
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

    public void StartGame()
    {
        isGameActive = true;
        if (DataManager.Instance != null)
        {
            playerName.text = "Pilot's name: " + DataManager.Instance.playerName;
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
