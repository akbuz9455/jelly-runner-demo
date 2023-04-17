using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetRun()
    {

        animator.SetBool("Run",true);
        animator.SetBool("Idle", false);
        animator.SetBool("Slump", false);

    }

    public void SetIdle()
    {

        animator.SetBool("Run", false);
        animator.SetBool("Idle",true);
        animator.SetBool("Slump", false);
    }
    public void SetWin()
    {

        animator.SetBool("Win", true);
   
    }

    public void SetDead()
    {

        animator.SetBool("Dead", true);

    }
    public void SetSlump()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Slump", true);

    }

}
