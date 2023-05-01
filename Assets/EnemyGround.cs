using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyGround : MonoBehaviour
{

    public GameObject ground;
 
    private void OnTriggerStay(Collider other)
    {
        GameManager.Instance.isGround = true;
        if ((other.tag =="LittleJelly") && ground.activeSelf)
        {
            other.GetComponent<Animator>().SetBool("Slump",true);
            ground.SetActive(false);
            GameManager.Instance.isGround = true;
            other.transform.DOJump(new Vector3(other.transform.position.x,other.transform.position.y-16.6f,other.transform.position.z+5f),5f,0,.75f).OnComplete(()=> {

                GameManager.Instance.isGround = false;
                other.GetComponent<Animator>().SetBool("Slump", false);

            });



            foreach (var item in JellyManager.Instance.jellyList)
            {
                item.GetComponent<Animator>().SetBool("Slump", true);

                item.GetComponent<JellyFollow>()._NavMesh.enabled = false;
                item.GetComponent<JellyFollow>().startFollow = false;
                
                item.transform.DOJump(new Vector3(item.transform.position.x, item.transform.position.y - 16.6f, item.transform.position.z + 5f), 5f, 0, .75f).OnComplete(()=> {
                    item.GetComponent<JellyFollow>()._NavMesh.enabled = true;
                    item.GetComponent<JellyFollow>().startFollow = true;
                    item.GetComponent<Animator>().SetBool("Slump", false);
                    item.GetComponent<EmojiManager>().SadEmoji[Random.Range(0, item.GetComponent<EmojiManager>().SadEmoji.Count)].GetComponent<ParticleSystem>().Play();
                });

            }
            GameManager.Instance.player.GetComponent<EmojiManager>().SadEmoji[Random.Range(0, GameManager.Instance.player.GetComponent<EmojiManager>().SadEmoji.Count)].GetComponent<ParticleSystem>().Play();

        }

    }
    private void OnTriggerExit(Collider other)
    {
        GameManager.Instance.isGround = false;
    }
}
