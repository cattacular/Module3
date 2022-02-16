using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    private Rigidbody rb;
    private Vector3 myTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myTransform = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, myTransform, moveSpeed * Time.deltaTime);
        myTransform = player.transform.position;
        float distance = Vector3.Distance(myTransform, transform.position);
        //if player is within 5 units of enemy
        if (distance < 10.0)
        {
            transform.position = Vector3.MoveTowards(transform.position, myTransform, moveSpeed * Time.deltaTime);
        }
    }
}
