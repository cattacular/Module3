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
   
    private float timer;
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
        offset = new Vector3(/*this.transform.position.x*/0.0f, this.transform.position.y + 1.0f, 0.0f /*this.transform.position.z*/);
        //playerPosition = player.transform.position;
        //playerplacement = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //look at player game object
        timer += Time.deltaTime;
        hitstunTimer++;
        if (timer >= 5.0f)
        {
            timer = 0;
            playerplacement = player.transform;
            transform.LookAt(playerplacement);

            Debug.Log("Look at");
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
        }
        isAlive();
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
