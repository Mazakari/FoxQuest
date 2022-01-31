
using UnityEngine.Events;

public class EventManager
{
    #region EVENTS
    /// <summary>
    /// Send this callback when player have no lives left.
    /// </summary>
    public static UnityEvent OnPlayerDead = new UnityEvent();

    /// <summary>
    /// Send this callback when player gets damage.
    /// </summary>
    public static UnityEvent OnPlayerDamaged = new UnityEvent();

    /// <summary>
    /// Send this callback when player lifebar should be updated.
    /// </summary>
    public static UnityEvent OnLifebarUpdate = new UnityEvent();

    /// <summary>
    /// Send this callback when all levelt targets complete
    /// </summary>
    public static UnityEvent OnLevelComplete = new UnityEvent();
    #endregion
}
