using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : SceneDependentSingleton<CanvasManager>
{

    [Header("GUI")]
  
    public GameObject guide;

   
    public void GameStart()
    {

        guide.transform.DOScale(Vector3.zero, 0);
     
   
    }

 



}
