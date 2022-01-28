//Roman Baranov 23.10.2021
using UnityEngine;


public class Projectile : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float _destroyDelay = 1f;
    #endregion

    #region UNITY Methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<Player>())
        {
            IDamagable target = collision.collider.GetComponent<IDamagable>();

            if (target != null)
            {
                target.GetDamage();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject, _destroyDelay);
            }
        }
    }
    #endregion

}
