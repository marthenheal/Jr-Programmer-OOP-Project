using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public string playerName;
    public TextMeshProUGUI entryText;

    public GameObject mainMenuPanel;
    public GameObject highscorePanel;

    public void GetPlayerName(string inputName)
    {
        playerName = inputName;
        DataManager.Instance.playerName = playerName;
        entryText.text = "Let's fly, " + playerName + "!";
    }

    public void OpenHighscore()
    {
        mainMenuPanel.SetActive(false);
        highscorePanel.SetActive(true);
    }

    public void CloseHighscore()
    {
        highscorePanel.SetActive(false);
        mainMenuPanel.SetActive(true);      
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
}
