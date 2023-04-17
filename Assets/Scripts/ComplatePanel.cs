using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComplatePanel : SceneDependentSingleton<ComplatePanel>
{
    public int bonusAmount;

    [Header("Props")]
    public Button nextButton;

    bool openPanelController;
    public void OpenPanel()
    {
        if (!openPanelController)
        {
            openPanelController = true;
        }

        Debug.Log("Level Completed");
        nextButton.transform.localScale = Vector3.zero;
        nextButton.enabled = true;

        transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).SetDelay(0.4f).OnComplete(() =>
        {

            nextButton.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);



        });
    }
    public void ClosePanel()
    {
        transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
    }
    public void LoadNewLevel()
    {


        nextButton.enabled = false;

        Camera.main.transform.SetParent(null);
        ClosePanel();
        LevelManager.LoadNextLevel();
    }
}
