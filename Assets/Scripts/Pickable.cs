//Roman Baranov 24.10.2021

using System;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private int _pickupScore = 1;
    private PlayerScores _playerScores = null;
    private AudioSource _audioSource = null;
    private SpriteRenderer _spriteRenderer = null;
    #endregion

    #region UNITY Methods
    private void Start()
    {
        _pickupScore = LevelManager.gameSettings_SO.PickupScore;
        _playerScores = FindObjectOfType<PlayerScores>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = transform.Find("gem-1").GetComponent<SpriteRenderer>();
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
            _audioSource.Play();
            _playerScores.UpdateScoresText(_pickupScore);
            _spriteRenderer.enabled = false;
            Destroy(gameObject,_audioSource.clip.length);
        }
    }
    #endregion
}
