using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToSpawn : MonoBehaviour //INHERITANCE -> parent class for any spawned object
{

    public virtual void MoveDown(float speed) //ABSTRACTION
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    public void DestroyOutOfBounds(float boundPosZ) //ABSTRACTION
    {
        if (transform.position.z < boundPosZ)
        {
            Destroy(gameObject);
        }
    }
}
