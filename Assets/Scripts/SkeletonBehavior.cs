using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehavior : MonoBehaviour
{
    private int health;
    public int score;

    public GameObject player;
    public AudioSource skellyNoises;
    public AudioSource deathNoise;
    public GameObject skull;
    

    // Start is called before the first frame update
    void Start()
    {
        health = 3;

    }

    // Update is called once per frame
    void Update()
    {
        isAlive();
        chasePlayer();
        

    }

    //checks unit health each update to see if they died or not
    void isAlive() 
    {
        //if it died or not
        if (health <= 0) 
        {
            //despawn model/play death noise/spawn skull throwable

            deathNoise.Play();
            Instantiate(skull, this.transform);
        }
    }

    //script to chase/walk towards player once they're close enough
    void chasePlayer() 
    {
        
    }
}
