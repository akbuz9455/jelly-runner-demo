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
                Debug.Log("girdi duvar algoritma");
            foreach (var item in brickList)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            float littleValue = WallLevel * PlayerManager.Instance.scaleFactor;
            GameObject player = GameManager.Instance.player;
            GameManager.Instance.player.transform.DOScale(new Vector3(player.transform.localScale.x- littleValue, player.transform.localScale.y- littleValue, player.transform.localScale.z- littleValue),.35f).SetEase(Ease.OutSine);
            for (int i = 0; i < JellyManager.Instance.jellyList.Count; i++)
            {
                player.transform.localScale -= new Vector3(transform.localScale.x-PlayerManager.Instance.scaleFactor, transform.localScale.y- PlayerManager.Instance.scaleFactor, transform.localScale.z-PlayerManager.Instance.scaleFactor);

            }
                brickTrigger = true;

            }
        if (other.tag=="Player" && Input.GetMouseButton(0))
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
            if (WallLevel < JellyManager.Instance.jellyList.Count)
            {
             //   Debug.Log("Game Over");
            }
        }
    }
}
