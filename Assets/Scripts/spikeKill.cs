using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeKill : MonoBehaviour
{
    public GameObject skull;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Instantiate(skull, this.transform);
    }
}
