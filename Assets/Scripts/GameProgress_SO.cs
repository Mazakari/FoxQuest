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
    #endregion
}
