using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ObjectToSpawn //INHERITANCE -> Enemy is a child of ObjectToSpawn
{
    [SerializeField] float speed = -7f;
    [SerializeField] float destroyBoundPosZ;

    private GameUIHandler gameUI;

    private void Start()
    {
        gameUI = GameObject.Find("GameUIHandler").GetComponent<GameUIHandler>();
    }
    // Update is called once per frame
    void Update()
    {
        if (gameUI.isGameActive)
        {
            MoveDown(speed);
            DestroyOutOfBounds(destroyBoundPosZ);
        }       
    }
}
