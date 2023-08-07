using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : ObjectToSpawn //INHERITANCE -> RepeatGround is a child of ObjectToSpawn
{
    private Vector3 startPos;
    private float repeatLength;
    [SerializeField] float speed;

    private GameUIHandler gameUI;

    // Start is called before the first frame update
    void Start()
    {
        gameUI = GameObject.Find("GameUIHandler").GetComponent<GameUIHandler>();

        startPos = transform.position;
        repeatLength = GetComponent<BoxCollider>().size.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameUI.isGameActive)
        {
            MoveDown(speed);
        }             
    }

    public override void MoveDown(float speed) //POLYMORPHISM -> ground is moving down but the image of it also repeats under player
    {
        base.MoveDown(speed);
        if (transform.position.z < startPos.z - repeatLength)
        {
            transform.position = startPos;
        }
    }
}
