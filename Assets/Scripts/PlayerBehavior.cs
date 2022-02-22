using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public int health;
    public float timer;

    public TextMeshProUGUI healthText;
    public GameObject deathText;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        healthText.text = "Health: " + health;
        timer = 0;
        deathText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(timer > 10.0f)
        {
            timer = 0;
            health--;
            isAlive();
            if (other.gameObject.CompareTag("Arrow1"))
            {
                other.gameObject.SetActive(false);
            }
        }
    }

    private void isAlive()
    {
        if (health <= 0) {
            this.transform.position = new Vector3(0, 0, 0);
            deathText.SetActive(true);
        }
    }
}
