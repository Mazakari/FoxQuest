//Roman Baranov 23.10.2021

using UnityEngine;

public class Shooter : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float _projectileSpeed = 20f;
    private GameObject _projectilePrefab = null;
    #endregion

    #region UNITY Methods
    private void Awake()
    {
        _projectilePrefab = Resources.Load<GameObject>("Prefabs/Projectile");
    }
    #endregion

    #region PUBLIC Methods
    /// <summary>
    /// Shoot projectile in direction character facing
    /// </summary>
    /// <param name="isShooting">Is shoot button pressed</param>
    /// <param name="flipX">Is character SpriteRenderer flipX true or false</param>
    public void Shoot(bool isShooting, bool flipX)
    {
        if (isShooting)
        {
            GameObject projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D currentBulletVelocity = projectile.GetComponent<Rigidbody2D>();

            if (!flipX)
            {
                currentBulletVelocity.velocity = new Vector2(_projectileSpeed * 1, currentBulletVelocity.velocity.y);
            }
            else
            {
                currentBulletVelocity.velocity = new Vector2(_projectileSpeed * -1, currentBulletVelocity.velocity.y);
            }
        }
    }
    #endregion




}
