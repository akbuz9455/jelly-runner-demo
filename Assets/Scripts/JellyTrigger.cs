using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (tag=="JellyMan"&& other.tag=="Player" && Input.GetMouseButton(0) && PlayerManager.Instance.readyCollect)
        {
            GetComponent<JellyFollow>().StartFollow();
            
        }
        if (tag == "JellyMan" && other.tag == "Player" && !Input.GetMouseButton(0) && PlayerManager.Instance.readyCollect)
        {
            GetComponent<JellyFollow>().StartFollow();

            gameObject.SetActive(false);
        }
    }
}
