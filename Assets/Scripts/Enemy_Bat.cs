// Roman Baranov 01.02.2022

using System.Collections;
using UnityEngine;

public class Enemy_Bat : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private bool _flipSprite = false;
    [SerializeField] private Transform _pointA = null;
    [SerializeField] private Transform _pointB = null;
    [SerializeField] private float pushForce = 5;

    [SerializeField] private float _speed = 5f;
    private float _interpolateAmount = 0f;


    private SpriteRenderer _spriteRenderer = null;

    #endregion

    #region UNITY Methods
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        CheckFlipOnStart();

        StartCoroutine(Interpolate(_pointA.position, _pointB.position));
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <returns></returns>
    private IEnumerator Interpolate(Vector2 startPos, Vector2 endPos)
    {
        while (true)
        {
            _interpolateAmount += _speed * Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, endPos, _interpolateAmount);

            if (_interpolateAmount >= 1f)
            {
                Vector2 tmp = startPos;
                startPos = endPos;
                endPos = tmp;

                _interpolateAmount = 0f;
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
            }
            yield return null;
        }
  
    }

    /// <summary>
    /// Check state of the flip x flag in sprite renderer
    /// </summary>
    private void CheckFlipOnStart()
    {
        if (_flipSprite)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player)
        {
            Vector2 pushDirection = player.transform.position - gameObject.transform.position;

            player.GetComponent<Rigidbody2D>().AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            player.Invoke("GetDamage",0.2f);
        }
    }
    #endregion
}
