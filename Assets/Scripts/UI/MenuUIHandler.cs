using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private string playerName;
    private int highScore;

    public TextMeshProUGUI entryText;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText.text = LoadHighScore();
        if (highScoreText.text == null)
        {
            highScoreText.text = "[there's no highscore yet]";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    public void GetPlayerName(string inputName)
    {
        playerName = inputName;
        DataManager.Instance.playerName = playerName;
        entryText.text = "Let's fly, " + playerName + "!";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }

    public string LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscorefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.name;
            highScore = data.highScore;
            return "Highscore: " + playerName + " - " + highScore;
        }
        return null;
    }

    public void DeleteHighScore()
    {
        string path = Application.persistentDataPath + "/highscorefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif
            highScoreText.text = "[there's no highscore yet]";
        }
    }
}


