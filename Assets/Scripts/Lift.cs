//Roman Baranov 24.10.2021

using UnityEngine;

public class Lift : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float _platformSpeed = 2;
    [SerializeField] private float _platformMoveDistance = 3;

    private bool _isUp = false;

    private SliderJoint2D _sliderJoint2D = null;
    #endregion

    #region UNITY Methods
    private void Awake()
    {
        _sliderJoint2D = transform.Find("Platform").GetComponent<SliderJoint2D>();

        InitLift();
    }

    private void Update()
    {
        PlatformMooveLoop();
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Initiate lift settings on start
    /// </summary>
    private void InitLift()
    {
        JointTranslationLimits2D newLimits = new JointTranslationLimits2D();
        newLimits = _sliderJoint2D.limits;

        newLimits.max = _platformMoveDistance;
        _sliderJoint2D.limits = newLimits;

        JointMotor2D newMotor = new JointMotor2D();
        newMotor = _sliderJoint2D.motor;

        newMotor.motorSpeed = _platformSpeed;
        _sliderJoint2D.motor = newMotor;
    }

    /// <summary>
    /// Flips motor speed
    /// </summary>
    private void FlipMotorSpeed()
    {
        JointMotor2D newMotor = new JointMotor2D();
        newMotor = _sliderJoint2D.motor;

        float newSpeed = _sliderJoint2D.motor.motorSpeed * -1;

        newMotor.motorSpeed = newSpeed;
        _sliderJoint2D.motor = newMotor;
    }

    /// <summary>
    /// Move platform loop
    /// </summary>
    private void PlatformMooveLoop()
    {
        if (_sliderJoint2D.jointTranslation >= _sliderJoint2D.limits.max && !_isUp)
        {
            FlipMotorSpeed();

            _isUp = !_isUp;
        }
        else if(_sliderJoint2D.jointTranslation <= _sliderJoint2D.limits.min && _isUp)
        {
            FlipMotorSpeed();

            _isUp = !_isUp;
        }
    }
    #endregion
}
