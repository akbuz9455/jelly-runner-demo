using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyHammer : MonoBehaviour
{
    public GameObject hammer;


    void Start()
    {
        hammer.transform.DOLocalRotate(new Vector3(0, 0, 180), 1.45f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InExpo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag== "Player" || other.tag == "LittleJelly") && Input.GetMouseButton(0))
        {
            if (other.tag=="LittleJelly")
            {
                GameManager.Instance.Dead();
            }
            else
            {
                other.GetComponent<JellyFollow>().Dead();
            }
          
        }
        if (other.tag == "Player" && !Input.GetMouseButton(0))
        {
            
            float littleValue = PlayerManager.Instance.scaleFactor;
            GameObject player = GameManager.Instance.player;
            JellyManager.Instance.jellyList[JellyManager.Instance.jellyList.Count - 1].GetComponent<JellyFollow>().Dead();
            GameManager.Instance.player.transform.DOScale(new Vector3(player.transform.localScale.x - littleValue, player.transform.localScale.y - littleValue, player.transform.localScale.z - littleValue), .35f).SetEase(Ease.OutSine);
            GameManager.Instance.Dead();
            hammer.transform.DOKill();

            hammer.transform.DOLocalRotate(new Vector3(0, 0, 95), .45f).SetEase(Ease.OutSine) ;


        }
    }
}
