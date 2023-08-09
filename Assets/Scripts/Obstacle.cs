using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : ObjectToSpawn //INHERITANCE -> Obstacle is a child of ObjectToSpawn
{
    [SerializeField] float speed;
    [SerializeField] float destroyBoundPosZ;

    public ParticleSystem explosionParticle;
    private GameUIHandler gameUI;

    // Start is called before the first frame update
    void Start()
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            explosionParticle.Play();
            Destroy(collision.gameObject);
        }
    }
}
