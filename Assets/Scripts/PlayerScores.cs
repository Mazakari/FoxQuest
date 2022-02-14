//Roman Baranov 25.10.2021

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour
{
    #region VARIABLES
    private Text _playerScoresText = null;
    private int _targetScores = 1;
    private int _currentScores = 0;
    /// <summary>
    /// Current player scores
    /// </summary>
    public int CurrentScores { get { return _currentScores; } }
    #endregion

    #region UNITY Methods
    private void Start()
    {
        _targetScores = LevelManager.gameSettings_SO.LevelScoresGoal;
        _playerScoresText = transform.Find("PlayerScoresText").GetComponent<Text>();

        UpdateScoresText(0);
    }
    #endregion

    #region PUBLIC Methods
    public void UpdateScoresText(int scoresToAdd)
    {
        _currentScores += scoresToAdd;

        if (_currentScores >= _targetScores)
        {
            _currentScores = _targetScores;
            EventManager.OnLevelComplete.Invoke();
        }
        
        _playerScoresText.text = $"{_currentScores} / {_targetScores}";
    }
    #endregion
}
