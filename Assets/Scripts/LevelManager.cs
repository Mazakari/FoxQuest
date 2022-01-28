//Roman Baranov 25.10.2021

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region VARIABLES
    public static GameSettings_SO _gameSettings_SO = null;
    private PlayerScores _playerScores = null;
    #endregion

    #region UNITY Methods
    private void Awake()
    {
        _gameSettings_SO = Resources.Load<GameSettings_SO>("ScriptableObjects/GameSettings_SO");
        _playerScores = FindObjectOfType<PlayerScores>();

        _playerScores.OnLevelComplete.AddListener(LoadNextLevel);

        Debug.Log($"{SceneManager.GetActiveScene().buildIndex}");
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

    #endregion
}
