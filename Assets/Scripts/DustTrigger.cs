using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrigger : MonoBehaviour
{
    public GameObject hammerParticle;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Hammer")
        {
            hammerParticle.GetComponent<ParticleSystem>().Play();
        }
    }
}
