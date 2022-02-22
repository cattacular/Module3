using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehavior : MonoBehaviour
{
    public GameObject player;
    private int health;

    public AudioSource skellyNoises;
    public AudioSource deathNoise;
    public GameObject damageParticles;
    private float soundTimer;
    
    public GameObject skull;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {  
        isAlive();
        soundTimer += Time.deltaTime;
        if (soundTimer >= 300)
        {
            soundTimer = 0;
            skellyNoises.Play();
        }
    }

    //fixed update for damage
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(damageParticles, this.transform);
        if (other.gameObject.CompareTag("Sword"))
        {
            health--;
            deathNoise.Play();
        }
        else if (other.gameObject.CompareTag("Skull") || other.gameObject.CompareTag("Arrow1"))
        {
            health--;
            other.gameObject.SetActive(false);
            deathNoise.Play();
            //spawn particles for skull getting broken
        }
    }

    //checks unit health each update to see if they died or not
    void isAlive() 
    {
        if (health <= 0) 
        {
            //despawn model/play death noise/spawn skull throwable'
            this.gameObject.SetActive(false);
            //deathNoise.Play();
            Instantiate(skull, this.transform);
            //score increased
        }
    }
}
