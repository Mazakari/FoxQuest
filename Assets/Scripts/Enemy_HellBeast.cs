// Roman Baranov 07.02.2022

using UnityEngine;

public class Enemy_HellBeast : MonoBehaviour
{
    #region VARIABLES
    private Shooter _shooter = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        _shooter = transform.parent.Find("Shooter").GetComponent<Shooter>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player)
        {
            _shooter.StartCoroutine(_shooter.Shoot());
        }
    }
    #endregion
}
