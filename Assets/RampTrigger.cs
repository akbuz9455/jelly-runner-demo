using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RampTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void JumpJelly(GameObject other, PlayerMovement playerMovement=null,JellyFollow jellyFollow=null,float jumpSpeed=1.15f)
    {
        other.transform.DOJump(new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 15f), 10, 1, jumpSpeed).SetEase(Ease.OutSine).OnComplete(() => {
            if (playerMovement != null)
            {
                playerMovement.enabled = true;
                GameManager.Instance.isGround = false;
                other.GetComponent<Animator>().SetBool("Jump", false);
            }
            if (jellyFollow != null)
            {
                jellyFollow.startFollow = true;
                other.GetComponent<Animator>().SetBool("Jump", false);

            }

        });

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="LittleJelly" || other.tag == "Player")
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            JellyFollow jellyFollow = other.GetComponent<JellyFollow>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
                GameManager.Instance.isGround = true;
                JumpJelly(other.gameObject,playerMovement,null,1.15f);
                other.GetComponent<Animator>().SetBool("Jump",true);
            }
            if (jellyFollow != null)
            {
                if (!jellyFollow.isJump)
                {
                jellyFollow.isJump = true;
                jellyFollow.startFollow = false;
                JumpJelly(other.gameObject, null, jellyFollow,0.85f);
                    other.GetComponent<Animator>().SetBool("Jump", true);
                }


            }
         

        }

    }
}
