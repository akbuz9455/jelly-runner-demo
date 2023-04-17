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
    public GameObject deadParticle;
    public GameObject margeParticle;
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
            GameManager.Instance.player.transform.localScale = (Vector3.one/10) + GameManager.Instance.player.transform.localScale;
        }

    }

    public void Dead()
    {
        isDead = true;
        deadParticle.transform.parent = GameManager.Instance.ParticlePooling.transform;
        deadParticle.GetComponent<ParticleSystem>().Play();

        transform.DOScale(Vector3.zero, .25f).SetEase(Ease.OutSine).OnComplete(() => {
            JellyManager.Instance.jellyList.Remove(gameObject);
            TargetManager.Instance.removeTarget(GetComponent<JellyFollow>().Target);
            startFollow = false;
            if (JellyManager.Instance.jellyList.Count < 2)
            {
                GameManager.Instance.Dead();
            }
        });


    }
    private void FixedUpdate()
    {
        if (!isDead && startFollow && GameManager.Instance.gameStatus == Enums.GameStatus.ready && !firstJelly)
        {
            _NavMesh.SetDestination(Target.transform.position);
        }

    }
}
