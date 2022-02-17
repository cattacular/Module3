using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RangedSkeleBehavir : MonoBehaviour
{
    public GameObject player;
    private int health;
    private Rigidbody rb;
    private Vector3 playerPosition;
    private Transform playerplacement;
    private int timer;
    private Vector3 offset;
    public GameObject arrow;
    public int hitstunTimer;
    public AudioSource deathNoise;
    public GameObject skull;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        timer = 0;
        hitstunTimer = 0;
        rb = GetComponent<Rigidbody>();

        playerPosition = player.transform.position;
        playerplacement = player.transform;
        offset = new Vector3(this.transform.position.x - 1.0f, this.transform.position.y + 1.2f, this.transform.position.z - 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //look at player game object
        isAlive();
        transform.LookAt(player.transform.position);
        timer++;
        hitstunTimer++;
        if (timer >= 600)
        {
            timer = 0;
            Instantiate(arrow, this.transform.position + offset, this.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hitstunTimer >= 30)
        {
            hitstunTimer = 0;
            if (other.gameObject.CompareTag("Sword"))
            {
                health--;
            }
            else if (other.gameObject.CompareTag("Skull"))
            {
                health--;
                //spawn particles for skull getting broken
            }
            else if (other.gameObject.CompareTag("SpikeHitbox"))
            {
                health = 0;
                this.gameObject.SetActive(false);
            }
        }
    }
    //checks unit health each update to see if they died or not
    void isAlive()
   {
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            deathNoise.Play();
            Instantiate(skull, this.transform);
            //score increased?
        }
    }
}
