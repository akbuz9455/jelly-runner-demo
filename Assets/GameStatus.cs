using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : SceneDependentSingleton<GameStatus>
{

    public void StartGame()
    {
        GameManager.Instance.gameStatus = Enums.GameStatus.ready;
    }
}