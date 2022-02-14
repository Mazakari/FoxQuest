// Roman Baranov 31.01.2022

using UnityEngine;

[CreateAssetMenu(fileName = "GameProgress_SO")]
public class GameProgress_SO : ScriptableObject
{
    #region VARIABLES
    private int _currentPlayerLives = 0;
    /// <summary>
    /// Current player lifes amount
    /// </summary>
    public int CurrentPlayerLives { get { return _currentPlayerLives; } set { _currentPlayerLives = value; } }

    [SerializeField]private int _totalScores = 0;
    /// <summary>
    /// Player total scores
    /// </summary>
    public int TotalScores { get { return _totalScores; } set { _totalScores = value; } }
    #endregion
}
