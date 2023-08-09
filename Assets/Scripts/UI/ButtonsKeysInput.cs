using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsKeysInput : MonoBehaviour //this script allows player hit RESTART button with space key
{
    private GameUIHandler gameUIHandler;
    private void Start()
    {
        gameUIHandler = GameObject.Find("GameUIHandler").GetComponent<GameUIHandler>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameUIHandler.RestartGame();
        }
    }
}
