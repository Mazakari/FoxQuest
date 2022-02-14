// Roman Baranov 31.01.2022

using UnityEngine;

public class GameSettingsLoader : MonoBehaviour
{
    #region VARIABLES
    private GameSettings_SO _gameSettings_SO = null;
    private GameProgress_SO _gameProgress_SO = null;
    #endregion

    #region UNITY Methdos
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        _gameSettings_SO = Resources.Load<GameSettings_SO>("ScriptableObjects/GameSettings_SO");
        _gameProgress_SO = Resources.Load<GameProgress_SO>("ScriptableObjects/GameProgress_SO");

        _gameProgress_SO.CurrentPlayerLives = _gameSettings_SO.PlayerLives;
        _gameProgress_SO.TotalScores = 0;
    }
    #endregion
}
