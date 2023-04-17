using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField]
    public List<Level> levels;
    public Level activeLevel;
    public Transform levelHolder;
    public bool isLevelRestarted = false;
    public int activeLevelID;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        levelHolder = transform.GetChild(0).transform;
       LoadLevel(GetLevelID());
    }

    public static void SetLevelID(int levelID)
    {
        PlayerPrefs.SetInt("levelIndex", levelID);
    }

    public static int GetLevelNumber()
    {
        int levelID = PlayerPrefs.GetInt("levelNumber", 0);

  
        return levelID;
    }

    public static int GetLevelID()
    {
        int levelID = PlayerPrefs.GetInt("levelIndex", 0);
        if (levelID >= instance.levels.Count)
        {
            levelID = 0;

        }

        return levelID;
    }

    public static void LoadNextLevel()
    {
       
        int levelID = GetLevelID() + 1;



        SetLevelID(levelID);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("levelNumber", PlayerPrefs.GetInt("levelNumber") + 1);
        //CanvasManager.instance.levelTxt.SetText("LEVEL " + (PlayerPrefs.GetInt("levelNumber") + 1).ToString());


    }

    public void LoadLevel(int index)
    {
        this.RemoveLevel();
        Level currentLevel = Instantiate(levels[index], levelHolder.transform);
       this.activeLevel = currentLevel;
        activeLevelID = index;

        CanvasManager.Instance.guide.SetActive(true);
    }

    public void RestartCurrentLevel()
    {
        LoadLevel(activeLevelID);
    }

    public void RemoveLevel()
    {

        if (GetActiveLevel() != null)
            Destroy(GetActiveLevel().gameObject);
    }
    public Level GetActiveLevel()
    {
        if (levelHolder.childCount > 0)
            return levelHolder.GetChild(0).GetComponent<Level>();
        else
            return null;


    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
         
        }
    }

  
}
