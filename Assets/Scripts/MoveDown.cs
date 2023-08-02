using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    //private Rigidbody objectRb;

    [SerializeField] float speed = 3.0f;
    //private float zBoundDestroy = -8.0f;

    // Start is called before the first frame update
    void Start()
    {
        //objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        //objectRb.AddForce(Vector3.forward * -speed);

        //if (transform.position.z < zBoundDestroy)
        //{
        //    Destroy(gameObject);
        //}
    }
}
