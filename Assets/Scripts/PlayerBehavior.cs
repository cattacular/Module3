using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public int health;
    public float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(timer > 30.0f)
        {
            timer = 0;
            health--;
            isAlive();
            if (other.gameObject.CompareTag("Arrow")) 
            {
                other.gameObject.SetActive(false);
            }
        }
    }


    private void isAlive()
    {
        if (health <= 0) {
            this.transform.position = new Vector3(0, 0, 0);
        }
    }
}
