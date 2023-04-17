using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRazor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       transform.DOLocalMoveX(1.7f, 1.85f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCirc);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Input.GetMouseButton(0))
        {
            if (other.GetComponent<JellyFollow>().firstJelly)
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
            GameManager.Instance.player.transform.DOScale(new Vector3(player.transform.localScale.x - littleValue, player.transform.localScale.y - littleValue, player.transform.localScale.z - littleValue), .35f).SetEase(Ease.OutSine);
           

        }
    }
}
