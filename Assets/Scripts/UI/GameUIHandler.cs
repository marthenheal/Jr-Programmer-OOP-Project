using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class GameUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;

    private string playerName = "[UNIDENTIFIED]";
    private string highScoreName = "[UNIDENTIFIED]";
    public bool isGameActive;
    private bool isGameOver;
    private int score = 0;
    private int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();      
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

        //adding ability to interact with buttons via keyboard
        if (Input.GetKeyDown(KeyCode.Space) && isGameOver)
        {
            RestartGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isGameOver)
        {
            BackToMenu();
        }
    }

    public void StartGame() //ABSTRACTION
    {
        isGameActive = true;
        isGameOver = false;
        if (DataManager.Instance != null)
        {
            playerName = DataManager.Instance.playerName;
            playerNameText.text = "Pilot's name: " + DataManager.Instance.playerName;
        }
        else
        {
            playerNameText.text = "Pilot's name: " + playerName;
        }

        highScoreText.text = LoadHighScore();
        scoreText.text = "SCORE: " + score;
    }

    public void GameOver() //ABSTRACTION
    {
        isGameActive = false;
        isGameOver = true;
        gameOverScreen.SetActive(true);
        if (score > highScore)
        {
            SaveNameAndScore(playerName, score);
        }
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

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }

    public void SaveNameAndScore(string playerName, int scoreValue)
    {
        SaveData data = new SaveData();
        data.name = playerName;
        data.highScore = scoreValue;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscorefile.json", json);
    }

    public string LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscorefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.name;
            highScore = data.highScore;
            return "HIGHSCORE: " + highScoreName + " - " + highScore;
        }
        return null;
    }
}
