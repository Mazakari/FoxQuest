//Roman Baranov 25.10.2021

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region VARIABLES
    public static GameSettings_SO gameSettings_SO = null;
    public static GameProgress_SO gameProgress_SO = null;
    #endregion

    #region UNITY Methods
    private void Awake()
    {
        gameSettings_SO = Resources.Load<GameSettings_SO>("ScriptableObjects/GameSettings_SO");
        gameProgress_SO = Resources.Load<GameProgress_SO>("ScriptableObjects/GameProgress_SO");

        EventManager.OnLevelComplete.AddListener(LoadNextLevel);
        EventManager.OnPlayerDamaged.AddListener(RestartLevel);
        EventManager.OnPlayerDead.AddListener(GameOver);
    }

    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Loads next level or a main menu, if all levels completed
    /// </summary>
    private void LoadNextLevel()
    {
        int curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int scenesCount = SceneManager.sceneCountInBuildSettings;

        if (curSceneIndex < scenesCount - 1)
        {
            // Load next level
            SceneManager.LoadScene(curSceneIndex + 1);
        }
        else
        {
            // Last level completed, load main menu
            SceneManager.LoadScene(0);
        }
    }

    /// <summary>
    /// Restarts current level
    /// </summary>
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Shows game over popup
    /// </summary>
    private void GameOver()
    {
        // Pause game
        // Call Game over popup
        Debug.Log("Game over!");
        SceneManager.LoadScene(0);

    }
    #endregion
}
