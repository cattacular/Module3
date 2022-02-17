using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 2;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        GetPlayerTransform();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        //if player is within 5 units of enemy
        if (distance <= 10.0)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    void GetPlayerTransform()
    {
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.Log("Player not specified in Inspector");
        }
    }
}
