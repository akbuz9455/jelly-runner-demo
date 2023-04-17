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
    public bool win;
    void Awake()
    {
        Instance = this;


    }

    public void Dead() {
        if (gameStatus != Enums.GameStatus.gameOver)
        { player.transform.DOScale(Vector3.zero,.35f).SetEase(Ease.OutSine);
        firstJelly.transform.DOScale(Vector3.zero, .35f).SetEase(Ease.OutSine);
            firstJelly.GetComponent<JellyFollow>().deadParticle.transform.parent = ParticlePooling.transform;
            firstJelly.GetComponent<JellyFollow>().deadParticle.GetComponent<ParticleSystem>().Play();
            foreach (var item in JellyManager.Instance.jellyList)
        {
            if (!item.GetComponent<JellyFollow>().isDead)
            {
                    item.transform.position = firstJelly.transform.position;
                item.GetComponent<JellyFollow>().Dead();
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
