using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JellyFollow : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent _NavMesh;
    public bool isDead;
    public bool startFollow;
    public bool firstJelly;
    public bool isJump;
    public GameObject deadParticle;
    public GameObject margeParticle;
    float distanceToTarget;
    private void OnEnable()
    {
        if (!firstJelly)
        {
        _NavMesh = GetComponent<NavMeshAgent>();
        if (startFollow)
        {
            tag = "Player";
            Target = TargetManager.Instance.CheckFreeTarget();
            GetComponent<Animator>().SetBool("Idle", false);
            GetComponent<Animator>().SetBool("Run", true);
                //  JellyManager.Instance.jellyList.Add(gameObject);

            }
        }

    }
    public void StartFollow()
    {
        if (!startFollow && !firstJelly)
        {
            tag = "Player";
            Target = TargetManager.Instance.CheckFreeTarget();
            startFollow = true;
            GetComponent<Animator>().SetBool("Run", true);
            JellyManager.Instance.jellyList.Add(gameObject);
   
        }

    }

    public void Dead()
    {
       
        isDead = true;
        deadParticle.transform.parent = null;
        deadParticle.GetComponent<ParticleSystem>().Play();
       // transform.DOMove(Target.transform.position, .35f);
        transform.DOScale(Vector3.zero, .25f).SetEase(Ease.OutSine).OnComplete(() => {
            JellyManager.Instance.jellyList.Remove(gameObject);
            TargetManager.Instance.removeTarget(GetComponent<JellyFollow>().Target);
            startFollow = false;
            if (JellyManager.Instance.jellyList.Count < 2 && GameManager.Instance.gameStatus==Enums.GameStatus.ready)
            {
                GameManager.Instance.Dead();
            }
        });


    }
    private void FixedUpdate()
    {
       

        if (!isDead && startFollow && GameManager.Instance.gameStatus == Enums.GameStatus.ready && !firstJelly && !GameManager.Instance.isGround)
        {
            distanceToTarget = Vector3.Distance(transform.position, Target.transform.position); 

            if (distanceToTarget > 0.55f)
            {
                _NavMesh.speed = 11.25f;
            }
            else
            { 
                _NavMesh.speed = 6.25f;
            }
            _NavMesh.SetDestination(Target.transform.position);
        }

    }
}
