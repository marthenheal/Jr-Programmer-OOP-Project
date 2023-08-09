using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : ObjectToSpawn
{
    [SerializeField] float speed;
    [SerializeField] float boundPosZ;

    public ParticleSystem explosionParticle;
    private GameUIHandler gameUIHandler;

    // Start is called before the first frame update
    void Start()
    {
        gameUIHandler = GameObject.Find("GameUIHandler").GetComponent<GameUIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown(speed);
        DestroyOutOfBounds(boundPosZ);
    }

    public override void DestroyOutOfBounds(float boundPosZ) //POLYMORPHISM -> rocket will be destroyed on the top of the screen
    {
        if (transform.position.z > boundPosZ)
        {
            Destroy(gameObject);
        }
    }

    public override void MoveDown(float speed) //POLYMORPHISM -> rocket is moving up
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameUIHandler.AddScore(5);

            explosionParticle.Play();                                   //kinda kludge
            gameObject.GetComponent<MeshRenderer>().enabled = false;    //I failed to Instantiate particle the other way
            Destroy(collision.gameObject);           
            Destroy(gameObject, 0.5f);
        }
        if (collision.gameObject.CompareTag("Rock"))
        {
            explosionParticle.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
}
