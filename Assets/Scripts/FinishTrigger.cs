using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    bool startFinishScale;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"|| other.tag=="LittleJelly")
        {
            if (GameManager.Instance.gameStatus == Enums.GameStatus.ready)
            {
                GameManager.Instance.gameStatus = Enums.GameStatus.gameEnd;
                bool aloneMode = true;
                if (!PlayerManager.Instance.aloneMode)
                {
                    GameManager.Instance.player.GetComponent<PlayerManager>().modeChange(aloneMode);
                    
                }
                other.GetComponent<EmojiManager>().HappyEmoji[Random.Range(0, other.GetComponent<EmojiManager>().HappyEmoji.Count)].GetComponent<ParticleSystem>().Play();
                startFinishScale = true;
                GameManager.Instance.player.GetComponent<PlayerManager>().bigTrail.SetActive(false);
                GameManager.Instance.player.GetComponent<PlayerManager>().winTrail.SetActive(true);
                GameManager.Instance.player.GetComponent<PlayerManager>().winTrail.GetComponent<ParticleSystem>().Play();

            }

        }

    }

    private void Update()
    {
        if (startFinishScale)
        {
            GameManager.Instance.player.transform.localScale = (new Vector3(GameManager.Instance.player.transform.localScale.x - (.2f * Time.deltaTime), GameManager.Instance.player.transform.localScale.y - (.2f * Time.deltaTime), GameManager.Instance.player.transform.localScale.z - (.2f * Time.deltaTime)));
            if (GameManager.Instance.player.transform.localScale.x < 0.2f)
            {
                startFinishScale = false;
                GameManager.Instance.win = true;
                GameManager.Instance.Dead();
                Debug.Log("win");
                ComplatePanel.Instance.OpenPanel();
            }


        }
    }

}
