// Roman Baranov 26.01.2022

using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    #region VARIABLES
    private Animator _animator = null;
    private Controls_Movement _controls_Movement = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _controls_Movement = GetComponent<Controls_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveAnimation();
        JumpAnimation();
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Run movement blend tree animation
    /// </summary>
    private void MoveAnimation()
    {
        _animator.SetFloat("Speed", _controls_Movement.CurSpeed);
    }

    private void JumpAnimation()
    {
        _animator.SetBool("Grounded", _controls_Movement.IsGrounded());
    }
    #endregion
}
