// Roman Baranov 10.02.2022

using UnityEngine;
using UnityEngine.UI;

public class LevelUI_LevelResults : MonoBehaviour
{
    #region VARIABLES
    [Header("Level Result Popup Background Panels")]
    [SerializeField] private GameObject _levelWonBackground = null;
    [SerializeField] private GameObject _gameOverBackground = null;

    [Header("Level Result Popup Total Scores Text")]
    [SerializeField] private Text _totalScoresText = null;
    private string _levelScores = "total scores:";

    [Header("Level Result Popup Buttons")]
    [SerializeField] private Button _restartLevelButton = null;
    [SerializeField] private Button _nextLevelButton = null;
    [SerializeField] private Button _menuButton = null;

    private LevelManager _levelManager = null;
    private PlayerScores _playerScores = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        _playerScores = FindObjectOfType<PlayerScores>();
        _levelManager = FindObjectOfType<LevelManager>();

        _restartLevelButton.onClick.AddListener(_levelManager.RestartLevel);
        _nextLevelButton.onClick.AddListener(_levelManager.LoadNextLevel);
        _menuButton.onClick.AddListener(_levelManager.LoadMainMenu);

        InitLevelResultPopup();
    }
    #endregion

    #region PUBLIC Methods
    /// <summary>
    /// Activates level won result popup
    /// </summary>
    /// <param name="levelScores">level scores amount</param>
    public void ShowLevelWonPopup()
    {
        Time.timeScale = 0f;

        _levelWonBackground.SetActive(true);
        _gameOverBackground.SetActive(false);

        // Add level scores to total scores
        int totalScores = LevelManager.gameProgress_SO.TotalScores += _playerScores.CurrentScores;
        _totalScoresText.text = $"{_levelScores}\n{totalScores}";
        _totalScoresText.gameObject.SetActive(true);

        _restartLevelButton.gameObject.SetActive(true);
        _nextLevelButton.gameObject.SetActive(true);
        _menuButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// Activates game over result popup
    /// </summary>
    /// <param name="totalScores">Player total scores</param>
    public void ShowGameOverPopup()
    {
        Time.timeScale = 0f;

        _levelWonBackground.SetActive(false);
        _gameOverBackground.SetActive(true);

        // Show total player scores
        _totalScoresText.text = $"{_levelScores}\n{LevelManager.gameProgress_SO.TotalScores}";
        _totalScoresText.gameObject.SetActive(true);

        _menuButton.gameObject.SetActive(true);
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Initialize popup on level start
    /// </summary>
    private void InitLevelResultPopup()
    {
        _levelWonBackground.SetActive(false);
        _gameOverBackground.SetActive(false);

        _totalScoresText.gameObject.SetActive(false);

        _restartLevelButton.gameObject.SetActive(false);
        _nextLevelButton.gameObject.SetActive(false);
        _menuButton.gameObject.SetActive(false);
    }
    #endregion
}
