//Roman Baranov 22.10.2021

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Controls_Movement : MonoBehaviour
{
    #region VARIABLES
    private Rigidbody2D _rigidbody2D = null;
    [SerializeField] private LayerMask _groundMask; 

    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _moveSpeed = 10f;

    private float _curSpeed = 0f;
    /// <summary>
    /// Current player Abs speed
    /// </summary>
    public float CurSpeed { get { return Mathf.Abs(_curSpeed); } }

    private bool _grounded = true;
    /// <summary>
    /// Is player grounded
    /// </summary>
    public bool Grounded { get { return _grounded; } }

    private bool _flipX = false;
    /// <summary>
    /// Is character sprite x flipped
    /// </summary>
    public bool FlipX { get { return _flipX; } }
    #endregion

    #region UNITY Methods
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region PUBLIC Methods
    /// <summary>
    /// Move character
    /// </summary>
    /// <param name="direction"></param>
    public void Move(float direction)
    {
        if (direction != 0f)
        {
            HorizontalMovement(direction);
        }
    }
    #endregion
    /// <summary>
    /// Makes character jump
    /// </summary>
    /// <param name="isJumping">Is character pressed jump button</param>
    public void Jump(bool isJumping)
    {
        if (isJumping && _grounded)
        {
            PlayerAudioManager.Instance.PlayJumpSound();
            _rigidbody2D.velocity = Vector2.up * _jumpForce;
        }
    }

    #region PRIVATE Methods
    /// <summary>
    /// Check if character is grounded
    /// </summary>
    /// <returns>Returns true if character grounded or false if not</returns>
    public bool IsGrounded()
    {
        CapsuleCollider2D capsuleCollider2D = GetComponent<CapsuleCollider2D>(); 

        float extraHight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(capsuleCollider2D.bounds.center, capsuleCollider2D.bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, extraHight, _groundMask);

        if (raycastHit)
        {
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }
        return raycastHit.collider != null;
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

        _curSpeed = direction * _moveSpeed;
        _rigidbody2D.velocity = new Vector2(_curSpeed, _rigidbody2D.velocity.y);
    }
    #endregion
}
