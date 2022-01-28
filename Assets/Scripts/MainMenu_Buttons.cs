// Roman Baranov 28.01.2022

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Buttons : MonoBehaviour
{
    #region VARIABLES
    private Button _startGameButton = null;
    private Button _quitGameButton = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        _startGameButton = transform.Find("StartGameButton").GetComponent<Button>();
        _quitGameButton = transform.Find("QuitGameButton").GetComponent<Button>();

        _startGameButton.onClick.AddListener(StartGame);
        _quitGameButton.onClick.AddListener(QuitGame);
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Load first game level
    /// </summary>
    private void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Quit game
    /// </summary>
    private void QuitGame()
    {
        Debug.Log("Quit game!");
        Application.Quit();
    }
    #endregion
}
