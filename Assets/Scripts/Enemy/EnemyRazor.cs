using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRazor : MonoBehaviour
{
    void Start()
    {
       transform.DOLocalMoveX(1.7f, 1.85f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCirc);
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("LittleJelly")) && Input.GetMouseButton(0))
        {
            if ( other.CompareTag("LittleJelly"))
            {
                GameManager.Instance.Dead();
            }
            else
            {
                other.GetComponent<JellyFollow>().Dead();

                foreach (var item in JellyManager.Instance.jellyList)
                {
                    if (!item.GetComponent<JellyFollow>().isDead)
                    {
                        item.GetComponent<EmojiManager>().SadEmoji[Random.Range(0, item.GetComponent<EmojiManager>().SadEmoji.Count)].GetComponent<ParticleSystem>().Play();

                    }

                }
            }

        }
        if (other.tag == "Player" && !Input.GetMouseButton(0))
        {

            float littleValue = PlayerManager.Instance.scaleFactor;
            GameObject player = GameManager.Instance.player;
            GameManager.Instance.player.transform.DOScale(new Vector3(player.transform.localScale.x - littleValue, player.transform.localScale.y - littleValue, player.transform.localScale.z - littleValue), .35f).SetEase(Ease.OutSine);
            
            if (JellyManager.Instance.jellyList.Count >2)
            {
                JellyManager.Instance.jellyList[JellyManager.Instance.jellyList.Count - 1].GetComponent<JellyFollow>().Dead();

            }
            else
            {
                GameManager.Instance.Dead();
                player.GetComponent<EmojiManager>().SadEmoji[Random.Range(0, player.GetComponent<EmojiManager>().SadEmoji.Count)].GetComponent<ParticleSystem>().Play();

            }


        }
    }
}
