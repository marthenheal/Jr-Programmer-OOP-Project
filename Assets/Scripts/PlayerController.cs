using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    //constraint player's movements
    private float zBound = 9f; 
    private float zBoundTopOffset = 4.5f;
    private float xBound = 12.5f;
    private float reloadTime = 0.5f;
    private float elapsedTime = 0f;

    private Rigidbody playerRb;
    public ParticleSystem explosionParticle;

    private GameUIHandler gameUI;

    public GameObject rocketPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameUI = GameObject.Find("GameUIHandler").GetComponent<GameUIHandler>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (gameUI.isGameActive) 
        {
            MovePlayer();
            ConstrainPlayerPosition();
        }     
        
        if (Input.GetKeyDown(KeyCode.Space) && elapsedTime > reloadTime) //why this time stopper isn't working?
        {
            Instantiate(rocketPrefab, transform.position, Quaternion.identity);
            elapsedTime = 0f;
        }
    }

    //Moves player in horizontal & vertical based on player's input
    void MovePlayer() //ABSTRACTION
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    //Constrain player's movements in boundaries
    void ConstrainPlayerPosition() //ABSTRACTION
    {
        //z-axis constraints
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if (transform.position.z > zBound - zBoundTopOffset)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound - zBoundTopOffset);
        }
        //x-axis constraints
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with an enemy");
            explosionParticle.Play();
            Destroy(collision.gameObject);
            gameUI.GameOver();
        }
        if (collision.gameObject.CompareTag("Rock"))
        {
            Debug.Log("Player has collided with a rock");
            explosionParticle.Play();
            gameUI.GameOver();
        }
    }
}
