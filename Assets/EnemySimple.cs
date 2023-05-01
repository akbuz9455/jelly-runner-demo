using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimple : MonoBehaviour
{
    private bool isTrigger;
    private void OnTriggerEnter(Collider other)
    {
   
        if (other.tag == "Player" && !Input.GetMouseButton(0) && GameManager.Instance.gameStatus != Enums.GameStatus.gameOver&& !isTrigger)
        {
            isTrigger = true;

            float littleValue = PlayerManager.Instance.scaleFactor;
            GameObject player = GameManager.Instance.player;
            GameManager.Instance.player.transform.DOScale(new Vector3(player.transform.localScale.x - (littleValue*2), player.transform.localScale.y - (littleValue * 2), player.transform.localScale.z - (littleValue * 2)), .35f).SetEase(Ease.OutSine);

            JellyManager.Instance.jellyList[JellyManager.Instance.jellyList.Count - 1].GetComponent<JellyFollow>().Dead();
            if (JellyManager.Instance.jellyList.Count < 2)
            {
                GameManager.Instance.Dead();
            }
            else
            {
                GameManager.Instance.player.GetComponent<EmojiManager>().SadEmoji[Random.Range(0, GameManager.Instance.player.GetComponent<EmojiManager>().SadEmoji.Count)].GetComponent<ParticleSystem>().Play();

            }
            transform.parent = null;
            transform.DOJump(new Vector3(transform.position.x,0,transform.position.z+14f),3,1,0.95f).SetEase(Ease.OutBounce);


        }
    }
}
