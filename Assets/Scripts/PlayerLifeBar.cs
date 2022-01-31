//Roman Baranov 25.10.2021

using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeBar : MonoBehaviour
{
    #region VARIABLES
    private List<Transform> _lifeBars;
    private int _currentLifeBarNumber = 0;
    #endregion

    #region UNITY Methods
    private void Start()
    {
        EventManager.OnLifebarUpdate.AddListener(OnLifebarUpdate);
        InitLifebar();
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Init life bar
    /// </summary>
    private void InitLifebar()
    {
        _lifeBars = new List<Transform>();
        GetComponentsInChildren(true, _lifeBars);
        _lifeBars.RemoveAt(0);

        _currentLifeBarNumber = (_lifeBars.Count - 1) - LevelManager.gameProgress_SO.CurrentPlayerLives;

        UpdateLifeBar(_currentLifeBarNumber);
    }

    /// <summary>
    /// Updates lifebar
    /// </summary>
    /// <param name="barToActivate">Which life bar object to activate</param>
    private void UpdateLifeBar(int barToActivate)
    {
        for (int i = 0; i < _lifeBars.Count; i++)
        {
            if (i == barToActivate)
            {
                _lifeBars[i].gameObject.SetActive(true);
                continue;
            }

            _lifeBars[i].gameObject.SetActive(false);
        }
    }
    #endregion

    #region EVENTS
    /// <summary>
    /// Updates players life bar
    /// </summary>
    private void OnLifebarUpdate()
    {
        _currentLifeBarNumber = (_lifeBars.Count - 1) - LevelManager.gameProgress_SO.CurrentPlayerLives;
        UpdateLifeBar(_currentLifeBarNumber);
    }
    #endregion
}
