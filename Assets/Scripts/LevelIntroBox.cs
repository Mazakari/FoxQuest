// Roman Baranov 12.02.2022

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelIntroBox : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private GameObject _cmVCam1 = null;
    [SerializeField] private GameObject _cmVCam2 = null;

    [SerializeField] private Canvas _canvas = null;
    [SerializeField] private Text _goalText = null;

    [SerializeField] private float _introStartDelay = 2f;
    [SerializeField] private float _cameraFlyDelay = 2f;
    [SerializeField] private float _goalTextShowDelay = 1f;
    [SerializeField] private float _cam2ActiveTime = 2f;

    private Controls_Input _controls_Input = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        _controls_Input = FindObjectOfType<Controls_Input>();
        _goalText.gameObject.SetActive(false);
        SwitchIntroState(false);
        StartCoroutine(StartIntro());

    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Enable or disable intro
    /// </summary>
    /// <param name="active">Is intro active</param>
    private void SwitchIntroState(bool active)
    {
        _canvas.gameObject.SetActive(active);
    }

    private IEnumerator StartIntro()
    {
        // Turn player controls off
        _controls_Input.enabled = false;

        // Activate camera 1
        _cmVCam1.gameObject.SetActive(true);

        // Deactivate camera 2
        _cmVCam2.gameObject.SetActive(false);

        // Wait for intro start delay
        yield return new WaitForSeconds(_introStartDelay);

        // Show cinematic stripes
        SwitchIntroState(true);

        // Deactivate camera 1
        _cmVCam1.gameObject.SetActive(false);

        // Activate camera 2
        _cmVCam2.gameObject.SetActive(true);

        // Wait for camera fly to the chest position
        yield return new WaitForSeconds(_cameraFlyDelay);

        // Show goal text
        _goalText.gameObject.SetActive(true);

        // Text show delay
        yield return new WaitForSeconds(_cam2ActiveTime);

        // Deactivate camera 2
        _cmVCam2.gameObject.SetActive(false);

        // Activate camera 1
        _cmVCam1.gameObject.SetActive(true);

        // Wait for camera fly back to the player position
        yield return new WaitForSeconds(_cameraFlyDelay);

        // Turn player controls on
        _controls_Input.enabled = true;

        // Hide cinematic stripes
        SwitchIntroState(false);

        yield return null;

    }
    #endregion
}
