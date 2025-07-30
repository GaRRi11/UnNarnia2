using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        // Load your first game scene
        SceneLoader.Instance.LoadScene("GameLevel01");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings button clicked");
        // You can show a settings panel here later
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
}
