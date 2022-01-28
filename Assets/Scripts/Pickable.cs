//Roman Baranov 24.10.2021

using System;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private int _pickupScore = 1;
    private PlayerScores _playerScores = null;
    #endregion

    #region UNITY Methods
    private void Start()
    {
        _pickupScore = LevelManager._gameSettings_SO.PickupScore;
        _playerScores = FindObjectOfType<PlayerScores>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.GetComponent<Player>())
    //    {
    //        _playerScores.UpdateScoresText(_pickupScore);
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            _playerScores.UpdateScoresText(_pickupScore);
            Destroy(gameObject);
        }
    }
    #endregion
}
