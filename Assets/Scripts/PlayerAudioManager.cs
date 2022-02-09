// Roman Baranov 09.02.2022

using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    #region VARIABLES
    public static PlayerAudioManager Instance = null;

    [SerializeField] private AudioClip _jumpSound = null;
    [SerializeField] private AudioClip _deathSound = null;

    private AudioSource _audioSource = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Plays jump sound
    /// </summary>
    public void PlayJumpSound()
    {
        _audioSource.clip = _jumpSound;
        _audioSource.Stop();
        _audioSource.Play();
    }

    /// <summary>
    /// Plays damage sound
    /// </summary>
    public void PlayDeathSound()
    {
        _audioSource.clip = _deathSound;
        _audioSource.Stop();
        _audioSource.Play();
    }
    #endregion

}
