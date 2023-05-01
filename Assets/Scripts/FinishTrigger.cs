using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            if (GameManager.Instance.gameStatus == Enums.GameStatus.ready)
            {
                GameManager.Instance.gameStatus = Enums.GameStatus.gameEnd;
                bool aloneMode = true;
                if (!PlayerManager.Instance.aloneMode)
                {
                    GameManager.Instance.player.GetComponent<PlayerManager>().modeChange(aloneMode);
                }
             
            }

        }
    }
}
