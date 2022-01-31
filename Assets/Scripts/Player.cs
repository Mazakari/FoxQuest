//Roman Baranov 21.10.2021

using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    #region VARIABLES
    private int _maxLives;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    private void Start()
    {
        _maxLives = LevelManager.gameSettings_SO.PlayerLives;
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
        LevelManager.gameProgress_SO.CurrentPlayerLives--;
        // Update health UI
        EventManager.OnLifebarUpdate.Invoke();

        if (LevelManager.gameProgress_SO.CurrentPlayerLives <= 0)
        {
            LevelManager.gameProgress_SO.CurrentPlayerLives = 0;

            // Game Over!
            EventManager.OnPlayerDead.Invoke();
            return;
        }

        // Player damaged
        EventManager.OnPlayerDamaged.Invoke();
    }
    #endregion
}
