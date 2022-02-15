using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehavior : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPosition;
    private int health;
    public float moveSpeed;

    public AudioSource skellyNoises;
    public AudioSource deathNoise;
    
    public GameObject skull;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        moveSpeed = 2;
        rb = GetComponent<Rigidbody>();
        playerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {  
        isAlive();

        
    }

    //fixed update for damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            health--;
        }
        else if (other.gameObject.CompareTag("Skull"))
        {
            health--;
            //spawn particles for skull getting broken
        }
        else if (other.gameObject.CompareTag("Spike01"))
        {
            health = 0;
            this.gameObject.SetActive(false);
        }
    }

    //checks unit health each update to see if they died or not
    void isAlive() 
    {
        if (health <= 0) 
        {
            //despawn model/play death noise/spawn skull throwable

            deathNoise.Play();
            Instantiate(skull, this.transform);
            //score increased
        }
    }

    //script to chase/walk towards player once they're close enough
}