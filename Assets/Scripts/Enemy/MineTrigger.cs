using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineTrigger : MonoBehaviour
{

    public bool isActive;
    public GameObject bombParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Input.GetMouseButton(0))
        {
            if (isActive)
            {
                GameManager.Instance.player.transform.DOKill();
                float littleValue = PlayerManager.Instance.scaleFactor;
                GameObject player = GameManager.Instance.player;
                GameManager.Instance.player.transform.DOScale(new Vector3(player.transform.localScale.x - littleValue, player.transform.localScale.y - littleValue, player.transform.localScale.z - littleValue), .35f).SetEase(Ease.OutSine);
         
                bombParticle.transform.parent = GameManager.Instance.ParticlePooling.transform;
                bombParticle.GetComponent<ParticleSystem>().Play();
                isActive = false;
            }


        }
        if ((other.tag == "Player"|| other.tag =="LittleJelly") && Input.GetMouseButton(0))
        {
            if (isActive)
            {
                if (other.tag == "LittleJelly")
                {
                    GameManager.Instance.Dead();
                  


                }
                else
                {
                    other.GetComponent<JellyFollow>().Dead();
                }
               
                bombParticle.transform.parent = GameManager.Instance.ParticlePooling.transform;
                bombParticle.GetComponent<ParticleSystem>().Play();
                isActive = false;
                transform.DOScale(Vector3.zero, .15f).SetEase(Ease.OutSine);
            }
           
          
          


        }

    }
}
