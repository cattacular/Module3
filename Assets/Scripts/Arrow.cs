using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Arrow : MonoBehaviour
{
    //public AudioSource arrowBreaking;
    public GameObject player;
    private Vector3 playerposition;
    public int moveSpeed;
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //find player position
        playerposition = player.transform.position;
        target = player.transform;
        //point towards it
        moveSpeed = 3;
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        //each update move forward some amount of distance
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

    }

    //on collision with player or surface
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            //blood sound
            //blood effect
        }
        else
        {
            this.gameObject.SetActive(false);
            //arrowBreaking.Play();
        }
    }
}
