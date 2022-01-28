//Roman Baranov 25.10.2021

using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings_SO", menuName = "ScriptableObjects", order = 1)]
public class GameSettings_SO : ScriptableObject
{
    #region VARIABLES
    [SerializeField] private int _playerLives = 3;
    /// <summary>
    /// Maximum player lives per level
    /// </summary>
    public int PlayerLives { get { return _playerLives; } }

    [SerializeField] private int _levelScoresGoal = 8;
    /// <summary>
    /// How many gems player should collect per level to complete it
    /// </summary>
    public int LevelScoresGoal { get { return _levelScoresGoal; } }

    [SerializeField] private int _pickupScore = 1;
    /// <summary>
    /// How much scores player get for taking each pickable
    /// </summary>
    public int PickupScore { get { return _pickupScore; } }
    #endregion
}
