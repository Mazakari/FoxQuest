// Roman Baranov 28.01.2022

using UnityEngine;
using UnityEngine.UI;

public class MainMenu_VersionInfo : MonoBehaviour
{
    #region VARIABLES
    private Text _text = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = $"v {Application.version}\nDeveloped by Roman Baranov";

    }
    #endregion

}
