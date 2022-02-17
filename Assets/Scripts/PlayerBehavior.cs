using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public int health;
    public int timer;
    

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(timer > 300)
        {
            timer = 0;
            health--;
        }

        
    }
}
