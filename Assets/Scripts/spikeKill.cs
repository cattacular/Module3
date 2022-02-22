using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeKill : MonoBehaviour
{
    public GameObject skull;
    public AudioSource deathNoise;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AxeSkelleFinal")) {
            deathNoise.Play();
        }
        other.gameObject.SetActive(false);
    }
}
