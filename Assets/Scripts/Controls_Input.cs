//Roman Baranov 21.10.2021

using UnityEngine;

[RequireComponent(typeof(Controls_Movement))]
public class Controls_Input : MonoBehaviour
{
    #region VARIABLES
    private Controls_Movement _controls_Movement = null;
    //private Shooter _shooter = null;

    private float _horizontal;
    private bool _isJumping;
    private bool _isShooting;

    #endregion

    #region UNITY Methods
    private void Awake()
    {
        _controls_Movement = GetComponent<Controls_Movement>();
        //_shooter = transform.Find("Shooter").GetComponent<Shooter>();

        _isJumping = false;
        _isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis(GlobalVariables.HORIZONTAL);
        _isJumping = Input.GetButtonDown(GlobalVariables.JUMP);
        _isShooting = Input.GetButtonDown(GlobalVariables.FIRE1);

        _controls_Movement.Jump(_isJumping);
        //_shooter.Shoot(_isShooting, _controls_Movement.FlipX);
    }

    private void FixedUpdate()
    {
        _controls_Movement.Move(_horizontal);
    }
    #endregion
}
