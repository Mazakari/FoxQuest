//Roman Baranov 23.10.2021
using UnityEngine;


public class Projectile : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float _destroyDelay = 1f;
    #endregion

    #region UNITY Methods
    private void Start()
    {
        Destroy(gameObject, _destroyDelay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        Player player = collision.gameObject.GetComponent<Player>();
        if (player is null)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Damage");
            IDamagable damagable = player.GetComponent<IDamagable>();
            damagable.GetDamage();
            Destroy(gameObject);
        }
    }
    #endregion

}
