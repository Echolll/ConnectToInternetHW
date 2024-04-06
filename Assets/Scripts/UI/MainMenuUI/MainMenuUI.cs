#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _connectToRoomPanel;
    [SerializeField]
    private GameObject _mainToMainPanel;

    public void OnClick_OpenRoomPanel()
    {
        _mainToMainPanel.SetActive(false);
        _connectToRoomPanel.SetActive(true);
    }

    public void OnClick_BackToMainMenu()
    {        
        _connectToRoomPanel.SetActive(false);
        _mainToMainPanel.SetActive(true);
    }

    public void OnClick_ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
