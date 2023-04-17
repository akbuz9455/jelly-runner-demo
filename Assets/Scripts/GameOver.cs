using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float bonus;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"|| other.tag =="LittleJelly")
        {
            GameManager.Instance.win = true;
            GameManager.Instance.Dead();
            Debug.Log("win");
            ComplatePanel.Instance.OpenPanel();
        }
    }
}
