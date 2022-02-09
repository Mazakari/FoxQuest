//Roman Baranov 23.10.2021

using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float _projectileSpeed = 20f;
    [SerializeField] private GameObject _projectilePrefab = null;

    [SerializeField] private float _shootDelay = 3f;
    private float _shootTimer = 0f;
    private bool _shootAllowed = true;
    private bool flipX = false;

    private Animator _anim = null;
    #endregion

    #region UNITY Methods
    private void Start()
    {
        flipX = transform.parent.Find("HellBeast").GetComponent<SpriteRenderer>().flipX;
        _anim = transform.parent.Find("HellBeast").GetComponent<Animator>();
    }
    #endregion

    #region PUBLIC Methods
    /// <summary>
    /// Shoot projectile in direction character facing
    /// </summary>
    public IEnumerator Shoot()
    {
        if (_shootAllowed)
        {
            _shootAllowed = false;

            _anim.SetTrigger("Shoot");
            yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(0).length);
            
            GameObject projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);

            int shootDirection;
            if (!flipX)
            {
                shootDirection = -1;
            }
            else
            {
                shootDirection = 1;
            }

            while (_shootTimer < _shootDelay)
            {
                if (projectile != null)
                {
                    projectile.transform.Translate(new Vector2(shootDirection, 0) * _projectileSpeed);
                    _shootTimer += Time.deltaTime;
                }

                yield return new WaitForEndOfFrame();
            }

            _shootTimer = 0f;
            _shootAllowed = true;
        }

        yield return null;
    }
    #endregion




}
