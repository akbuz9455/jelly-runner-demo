using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnife : MonoBehaviour
{
    public GameObject clonePlayerRagdoll;
        
        private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player" && Input.GetMouseButton(0))
        {
           
            Vector3 position = other.gameObject.transform.position;
            Quaternion rotation = other.gameObject.transform.rotation; 
            GameObject newPrefab = Instantiate(clonePlayerRagdoll, position, rotation);
            newPrefab.name = clonePlayerRagdoll.name + " Clone";
            newPrefab.transform.localScale = other.gameObject.transform.localScale;


            if (other.GetComponent<JellyFollow>().firstJelly)
            {
                GameManager.Instance.Dead();
            }
            else
            {
                other.GetComponent<JellyFollow>().Dead();
            }
        }

        if ((other.tag == "Player" && !Input.GetMouseButton(0) )|| (other.tag == "LittleJelly" && Input.GetMouseButton(0)))
        {
            float littleValue = PlayerManager.Instance.scaleFactor;
            GameObject player = GameManager.Instance.player;
            GameManager.Instance.player.transform.DOScale(new Vector3(player.transform.localScale.x - littleValue, player.transform.localScale.y - littleValue, player.transform.localScale.z - littleValue), .1f);
            GameManager.Instance.Dead();
            foreach (var item in JellyManager.Instance.jellyList)
            {
                Vector3 position = other.gameObject.transform.position;
                Quaternion rotation = other.gameObject.transform.rotation;
                GameObject newPrefab = Instantiate(clonePlayerRagdoll, position, rotation);
                newPrefab.name = clonePlayerRagdoll.name + " Clone";
                newPrefab.transform.localScale = other.gameObject.transform.localScale;
                newPrefab.transform.position = position;
            }
        }
    }

  
}
