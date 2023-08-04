using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ObjectToSpawn //INHERITANCE -> Enemy is a child of ObjectToSpawn
{
    [SerializeField] float m_speed = -7f;
    public float speed //why this isn't working?
    {
        get { return m_speed; }
        set
        {
            if (value > 0.0f)
            {
                Debug.LogError("Positive speed will turn enemy AWAY of the player");
            }
            else
            {
                m_speed = value;
            }
        }
    }


    [SerializeField] float destroyBoundPosZ;

    // Update is called once per frame
    void Update()
    {
        MoveDown(speed);
        DestroyOutOfBounds(destroyBoundPosZ);
    }
}
