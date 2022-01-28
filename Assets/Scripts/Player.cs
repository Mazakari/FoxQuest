//Roman Baranov 21.10.2021

using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    #region VARIABLES
    private int _maxLives;
    private int _curLives;

    #region EVENTS
    /// <summary>
    /// Send this callback when player have no lives left.
    /// </summary>
    public event EventHandler OnPlayerDead;

    /// <summary>
    /// Send this callback when player gets damage.
    /// </summary>
    public event EventHandler OnPlayerDamaged;
    #endregion
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    private void Start()
    {
        _maxLives = LevelManager._gameSettings_SO.PlayerLives;
        _curLives = _maxLives;
    }
    #endregion

    #region PUBLIC Methods
    /// <summary>
    /// Decrease current player lives amount when player gets damage. 
    /// Send OnPlayerDamaged callback when player gets damage.
    /// Send OnPlayerDeath callback when player have no lives left.
    /// </summary>
    public void GetDamage()
    {
        _curLives--;

        if (_curLives == 0)
        {
            // Game Over!
            OnPlayerDead?.Invoke(this, EventArgs.Empty);
            return;
        }

        // Player Damaged
        OnPlayerDamaged?.Invoke(this, EventArgs.Empty);
    }
    #endregion
}
