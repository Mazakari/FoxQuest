//Roman Baranov 24.10.2021

using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PickablesSpawner))]
public class GemChest : MonoBehaviour
{
    #region VARIABLES
    private List<SpriteRenderer> _chestSprites = null;
    private PickablesSpawner _pickableSpawner = null;
    private AudioSource _audioSource = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    private void Start()
    {
        _pickableSpawner = GetComponent<PickablesSpawner>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        InitChest();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
            _audioSource.Play();
            OpenChest();
            _pickableSpawner.SpawnPickables();
        }
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Gets sprite renderer component from all its children
    /// </summary>
    private void InitChest()
    {
        _chestSprites = new List<SpriteRenderer>();
        GetComponentsInChildren(true, _chestSprites);

        _chestSprites[0].gameObject.SetActive(true);
        _chestSprites[1].gameObject.SetActive(false);
    }

    /// <summary>
    /// Switch close sprite to open one
    /// </summary>
    private void OpenChest()
    {
        _chestSprites[0].gameObject.SetActive(false);
        _chestSprites[1].gameObject.SetActive(true);
    }
    #endregion
}
