//Roman Baranov 21.10.2021

using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    #region VARIABLES
    private int _maxLives;
    private CapsuleCollider2D _capsuleCollider2 = null;
    private Animator _animator = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    private void Start()
    {
        _maxLives = LevelManager.gameSettings_SO.PlayerLives;
        _capsuleCollider2 = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
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

        // Turn off player collider
        _capsuleCollider2.enabled = false;

        // Activate player hurt animation trigger
        _animator.SetTrigger("Hurt");

        // Play player death sound
        PlayerAudioManager.Instance.PlayDeathSound();

        // Send callbacks after a short delay to play death sound
        Invoke(nameof(ResolveDamage), 0.3f);
    }
    #endregion

    #region PRIVATE Methods
    private void ResolveDamage()
    {
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
