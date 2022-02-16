using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Arrow : MonoBehaviour
{
    public AudioSource arrowBreaking;
    

    // Start is called before the first frame update
    void Start()
    {
        //find player position

        //point towards it
    }

    // Update is called once per frame
    void Update()
    {
        //each update move forward some amount of distance
    }

    //on collision with player or surface
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            //blood effect
        }
        else if(other.gameObject.CompareTag("SpinningSkelle2") || other.gameObject.CompareTag("RangedSkele"))
        {
            this.gameObject.SetActive(false);
            //dust cloud or breaking particles
            arrowBreaking.Play();
        }
        
    }
}
