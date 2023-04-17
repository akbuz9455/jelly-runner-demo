using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyMine : MonoBehaviour
{
   
    public List<GameObject> mineList = new List<GameObject>();
    public GameObject parentMine;

    public GameObject buttonBrokeAllMine;
  
    void Start()
    {
        for (int i = 0; i < parentMine.transform.childCount; i++)
        {
            Transform child = parentMine.transform.GetChild(i);
            // child nesnesini brickList'e ekle
            mineList.Add(child.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Input.GetMouseButton(0))
        {
            foreach (var item in mineList)
            {
                item.GetComponent<MineTrigger>().bombParticle.transform.parent = GameManager.Instance.ParticlePooling.transform;
                item.GetComponent<MineTrigger>().bombParticle.GetComponent<ParticleSystem>().Play();
                item.transform.DOScale(Vector3.zero,.25f);
                item.GetComponent<MineTrigger>().isActive = false;
                buttonBrokeAllMine.transform.DOLocalMoveY(-0.39f, .75f).SetEase(Ease.OutSine);
                //particle patlatalim
               
            }
        }

        if (other.tag == "Player" && Input.GetMouseButton(0))
        {
           
                other.GetComponent<JellyFollow>().startFollow = false;
                other.transform.DOJump(new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 4f), 2, 1, .4f).OnComplete(() => {

                    other.GetComponent<JellyFollow>().startFollow = true;


                });
            
          
        }
    }
}
