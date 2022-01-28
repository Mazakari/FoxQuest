//Roman Baranov 25.10.2021

using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeBar : MonoBehaviour
{
    #region VARIABLES
    private Player _player = null;
    private List<Transform> _lifeBars;
    private int _currentLifeBarNumber = 0;
    #endregion

    #region UNITY Methods
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _player.OnPlayerDamaged += _player_OnPlayerDamaged;

        InitLifebar();
     
    }

    private void OnDestroy()
    {
        _player.OnPlayerDamaged -= _player_OnPlayerDamaged;
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

        _currentLifeBarNumber = _lifeBars.Count - LevelManager._gameSettings_SO.PlayerLives;

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

        if (_currentLifeBarNumber++ < _lifeBars.Count)
        {
            _currentLifeBarNumber++;
        }
        else
        {
            Debug.Log("No more lifebars in collection");
            return;
        }
    }
    #endregion

    #region EVENTS
    /// <summary>
    /// Updates players life bar when they takes damage
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void _player_OnPlayerDamaged(object sender, System.EventArgs e)
    {
        UpdateLifeBar(_currentLifeBarNumber);
    }
    #endregion
}
