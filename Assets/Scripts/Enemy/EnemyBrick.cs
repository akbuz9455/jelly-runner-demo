using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyBrick : MonoBehaviour
{
    public int WallLevel;
    public List<GameObject> brickList = new List<GameObject>();
    public GameObject parentWall;
    public bool brickTrigger;
    void Start()
    {
        for (int i = 0; i < parentWall.transform.childCount; i++)
        {
            Transform child = parentWall.transform.GetChild(i);
            // child nesnesini brickList'e ekle
            brickList.Add(child.gameObject);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (!brickTrigger)
        {

     
        if (other.tag == "Player" && !Input.GetMouseButton(0)  && !brickTrigger)
        {
           
            foreach (var item in brickList)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
                float littleValue = PlayerManager.Instance.scaleFactor;
                GameObject player = GameManager.Instance.player;
                for (int i = 0; i < WallLevel; i++)
                {
                    player.transform.DOScale(new Vector3(player.transform.localScale.x - littleValue, player.transform.localScale.y - littleValue, player.transform.localScale.z - littleValue), 0f);

                    JellyManager.Instance.jellyList[JellyManager.Instance.jellyList.Count - 1].GetComponent<JellyFollow>().Dead();
                    if (JellyManager.Instance.jellyList.Count < 2)
                    {
                        GameManager.Instance.Dead();
                    }
                    else
                    {
                        player.GetComponent<EmojiManager>().SadEmoji[Random.Range(0, player.GetComponent<EmojiManager>().SadEmoji.Count)].GetComponent<ParticleSystem>().Play();

                    }
                }
                brickTrigger = true;

            }
        if ((other.tag=="Player"&& Input.GetMouseButton(0) || (other.tag == "LittleJelly" && Input.GetMouseButton(0))))
        {
                if (other.tag == "Player")
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
                else if (other.tag ==  "LittleJelly")
                {
                    GameManager.Instance.Dead();
                    brickTrigger = true;
                }

              }
        }
    }
}
