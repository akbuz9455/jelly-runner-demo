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
        counterTotalMulti = counterTotalMulti;
        animManager = GetComponent<AnimationManager>();
    }

    
    void Update()
    {
        if (GameManager.Instance.gameStatus != Enums.GameStatus.gameOver && GameManager.Instance.gameStatus != Enums.GameStatus.gameEnd)
        {

     
        if (Input.GetMouseButton(0))
        {
               
            tag = "LittleJelly";
            countdownMultiJelly = counterTotalMulti;
            if (GameManager.Instance.gameStatus == Enums.GameStatus.waiting)
                {
                    CanvasManager.Instance.GameStart();
                    GameManager.Instance.gameStatus = Enums.GameStatus.ready;
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

        ///


    }
}
