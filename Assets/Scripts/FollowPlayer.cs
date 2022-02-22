using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2;
    public float distanceToAttack = 10.0f;

    // Update is called once per frame
    void Update()
    {
        // Face towards the player
        transform.LookAt(player);

        // Move the enemy forward
        float distance = Vector3.Distance(player.position, transform.position);
        //if player is within 5 units of enemy
        if (distance <= distanceToAttack)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}