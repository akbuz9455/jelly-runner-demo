using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Enums.GameStatus gameStatus;
    public GameObject player;
    public GameObject firstJelly;
    public GameObject ParticlePooling;
    public GameObject DeadParticle;
    public bool win;
    public Vector3 addedScale;
    public bool isGround;
    void Awake()
    {
        Instance = this;
        addedScale =  Vector3.zero;
        Application.targetFrameRate = 60;
    }

    public void Dead() {
        if (gameStatus != Enums.GameStatus.gameOver)
        {
            DeadParticle.transform.parent = ParticlePooling.transform;
            DeadParticle.transform.position = new Vector3(player.transform.position.x, 1.6f, player.transform.position.z); 
            player.transform.DOScale(Vector3.zero,.35f).SetEase(Ease.OutSine);
            DeadParticle.GetComponent<ParticleSystem>().Play();
            if (JellyManager.Instance.jellyList.Count>0)
            {
                foreach (var item in JellyManager.Instance.jellyList)
                {
                    if (!item.GetComponent<JellyFollow>().isDead)
                    {
                        // item.transform.position = firstJelly.transform.position;
                        item.transform.DOMove(player.transform.position, 35f).SetEase(Ease.OutSine);
                        item.GetComponent<JellyFollow>().Dead();
                    }
                }
            }
          
            Debug.Log("GameOver");
            gameStatus = Enums.GameStatus.gameOver;
            if (!win)
            {
                FailPanel.Instance.OpenPanel();
            }
        }
    }
}
