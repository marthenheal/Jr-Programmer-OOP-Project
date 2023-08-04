using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : ObjectToSpawn //INHERITANCE -> Obstacle is a child of ObjectToSpawn
{
    [SerializeField] float speed;
    [SerializeField] float destroyBoundPosZ;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown(speed);
        DestroyOutOfBounds(destroyBoundPosZ);
    }

    private void OnCollisionEnter(Collision collision) //idk why particles isn't working on enemies, but they work on rocks, so...
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            explosionParticle.Play();
            Destroy(collision.gameObject);
        }
    }
}
