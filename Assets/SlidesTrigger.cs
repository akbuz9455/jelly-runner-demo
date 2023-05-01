using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class SlidesTrigger : MonoBehaviour
{
    public List<GameObject> targetList = new();
    private bool slidesTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag =="Player" || other.tag == "LittleJelly") && !slidesTrigger)
        {
      
               PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
             //   slidesTrigger = true;
                playerMovement.enabled = false;
                other.transform.DOMoveX(0,.2f).OnComplete(()=> {
                    Slides(other.gameObject, 0, .25f);
                    other.GetComponent<Animator>().SetBool("Fly", true);
                });

                GameManager.Instance.isGround = true;
            }
            else
            {
                if (!other.GetComponent<JellyFollow>().isSlides)
                {
                    other.GetComponent<JellyFollow>().isSlides = true;  
                    other.GetComponent<JellyFollow>().startFollow = false;
                    other.GetComponent<JellyTrigger>().enabled = false;
                    other.GetComponent<JellyFollow>().enabled = false;
                    other.transform.DOMoveX(0, .2f).OnComplete(() => {
                        Slides(other.gameObject, 0, Random.Range(0.25f,0.5f), true);
                        NavMeshAgent navAgent = other.GetComponent<NavMeshAgent>();
                        if (navAgent != null)
                        {
                            navAgent.enabled = false;
                        }
                        other.GetComponent<Animator>().SetBool("Fly", true);
                    });

                }


            }
        }
    }

    public void Slides(GameObject other,int startIndex,float goTime,bool isClon=false)
    {
       
        other.transform.DOMove(targetList[startIndex].transform.position, goTime).OnComplete(()=> {

            if (targetList.Count != startIndex)
            {
                goTime += 0.55f;
               
                Slides(other.gameObject, startIndex + 1, .2f, isClon);

            }

          

        });

        if (targetList.Count == startIndex + 1)
        {
            GameManager.Instance.player.GetComponent<PlayerMovement>().enabled = true;
            GameManager.Instance.player.GetComponent<Animator>().SetBool("Fly", false);
            GameManager.Instance.isGround = false;
            if (isClon == true)
            {
                NavMeshAgent navAgent = other.GetComponent<NavMeshAgent>();
                if (navAgent != null)
                {
                    navAgent.enabled = true;
                }
                other.GetComponent<JellyFollow>().enabled = true;
                other.GetComponent<JellyTrigger>().enabled = true;
                other.GetComponent<JellyFollow>().startFollow = true;
            }
            other.GetComponent<Animator>().SetBool("Fly", false);
        }
       

    }
}
