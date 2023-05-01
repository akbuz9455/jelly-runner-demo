using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
    AnimationManager animManager;

    float countdownAloneJelly = 3f;
    float countdownMultiJelly = 3f;
    float counterTotalAlone = .35f;
    float counterTotalMulti = .25f;
   

    public bool aloneMode;

   
    void Start()
    {
        countdownAloneJelly = counterTotalAlone;
        animManager = GetComponent<AnimationManager>();
    }

    
    void Update()
    {
        if (GameManager.Instance.gameStatus != Enums.GameStatus.gameOver && GameManager.Instance.gameStatus != Enums.GameStatus.gameEnd && !GameManager.Instance.isGround)
        {
        if (Input.GetMouseButton(0))
        {
               
            tag = "LittleJelly";
            countdownMultiJelly = counterTotalMulti;
            if (GameManager.Instance.gameStatus == Enums.GameStatus.ready)
                {
                    CanvasManager.Instance.GameStart();
                    animManager.SetRun();
                }

            if (countdownAloneJelly >= 0)
            {
                countdownAloneJelly -= Time.deltaTime;
            }
            else
            {
                if (aloneMode)
                {
                    aloneMode = false;
                    GetComponent<PlayerManager>().modeChange(aloneMode);

                }
            }
        }
        else
        {
            tag = "Player";

            countdownAloneJelly = counterTotalAlone;

            if (countdownMultiJelly>=0)
            {
                countdownMultiJelly -= Time.deltaTime;

            }
            else
            {
                if (!aloneMode)
                {
                    aloneMode = true;
                    GetComponent<PlayerManager>().modeChange(aloneMode);
                }
            }

        }
        }
    }
}
