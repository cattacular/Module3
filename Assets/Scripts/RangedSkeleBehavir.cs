using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSkeleBehavir : MonoBehaviour
{
    public GameObject player;
    private int health;
    private Rigidbody rb;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        rb = GetComponent<Rigidbody>();
        playerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //look at player game object
        transform.LookAt(player.transform.position);
    }
}
