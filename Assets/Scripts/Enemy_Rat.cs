// Roman Baranov 05.02.2022

using UnityEngine;

public class Enemy_Rat : MonoBehaviour
{
    #region VARIABLES
    private Rigidbody2D _rigidbody2D = null;

    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _maxMoveDistance = 3f;
    [SerializeField] private float pushForce = 5;
    private float _curDistance = 0f;
    private Vector2 _targetPoint = Vector2.zero;

    private float _moveDirectionX = 1f;

    private bool _flipX = false;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _targetPoint = new Vector2(gameObject.transform.localPosition.x, 0) + new Vector2(_maxMoveDistance, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(_moveDirectionX);
    }
    #endregion

    /// <summary>
    /// Move character
    /// </summary>
    /// <param name="direction"></param>
    private void Move(float direction)
    {
        if (direction != 0f)
        {
            HorizontalMovement(direction);

            _curDistance = Vector2.Distance(new Vector2(gameObject.transform.localPosition.x, 0), _targetPoint);// TO DO
            if (_curDistance <= 0.01f)
            {
                _targetPoint.x *= -1;
                _moveDirectionX *= -1;
            }
        }
    }

    /// <summary>
    /// Move character horizontaly
    /// </summary>
    /// <param name="direction">Character direction</param>
    private void HorizontalMovement(float direction)
    {
        if (direction < 0)
        {
            _flipX = true;
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            _flipX = false;
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        _rigidbody2D.velocity = new Vector2(direction * _moveSpeed, _rigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player)
        {
            Vector2 pushDirection = player.transform.position - gameObject.transform.position;

            player.GetComponent<Rigidbody2D>().AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            player.Invoke("GetDamage", 0.2f);
        }
    }
}
