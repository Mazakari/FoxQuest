//Roman Baranov 25.10.2021

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region VARIABLES
    public static GameSettings_SO gameSettings_SO = null;
    public static GameProgress_SO gameProgress_SO = null;

    private LevelUI_LevelResults _levelResultsPopup = null;
    #endregion

    #region UNITY Methods
    private void Awake()
    {
        Time.timeScale = 1f;

        _levelResultsPopup = FindObjectOfType<LevelUI_LevelResults>();

        gameSettings_SO = Resources.Load<GameSettings_SO>("ScriptableObjects/GameSettings_SO");
        gameProgress_SO = Resources.Load<GameProgress_SO>("ScriptableObjects/GameProgress_SO");

        EventManager.OnLevelComplete.AddListener(_levelResultsPopup.ShowLevelWonPopup);
        EventManager.OnPlayerDamaged.AddListener(RestartLevel);
        EventManager.OnPlayerDead.AddListener(_levelResultsPopup.ShowGameOverPopup);
    }

    #endregion

    #region PUBLIC Methods
    /// <summary>
    /// Loads next level or a main menu, if all levels completed
    /// </summary>
    public void LoadNextLevel()
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
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Shows game over popup
    /// </summary>
    public void GameOver()
    {
        // Pause game
        // Call Game over popup
        Debug.Log("Game over!");
        SceneManager.LoadScene(0);

    }

    /// <summary>
    /// Loads main menu
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}
