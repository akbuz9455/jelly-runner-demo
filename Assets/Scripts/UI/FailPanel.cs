using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailPanel : SceneDependentSingleton<FailPanel>
{
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void OpenPanel()
    {
     
        Debug.Log("Level Failed");


        transform.DOScale(Vector3.one, 0.65f).SetEase(Ease.InOutSine);
    }

    public void ClosePanel()
    {
        transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete(() => {

        });
    }

    public void RestartButtonAction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
