using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnderProp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" || other.tag =="LittleJelly")&& Input.GetMouseButton(0) && GameManager.Instance.gameStatus != Enums.GameStatus.gameOver)
        {
            if (other.tag == "LittleJelly")
            {
                GameManager.Instance.Dead();
            }
            else
            {
                other.GetComponent<JellyFollow>().Dead();
            }

        }
        if (other.tag == "Player" && !Input.GetMouseButton(0) && GameManager.Instance.gameStatus!=Enums.GameStatus.gameOver)
        {

            float littleValue = PlayerManager.Instance.scaleFactor;
            GameObject player = GameManager.Instance.player;
            GameManager.Instance.player.transform.DOScale(new Vector3(player.transform.localScale.x - littleValue, player.transform.localScale.y - littleValue, player.transform.localScale.z - littleValue), .35f).SetEase(Ease.OutSine);
          
            JellyManager.Instance.jellyList[JellyManager.Instance.jellyList.Count - 1].GetComponent<JellyFollow>().Dead();
            if (JellyManager.Instance.jellyList.Count<2)
            {
                GameManager.Instance.Dead();
            }

            transform.DOMoveX(7.73f, .55f).SetEase(Ease.OutSine);


        }
    }
}
