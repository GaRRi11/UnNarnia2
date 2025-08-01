using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject pauseButton;  // Add this reference

    private bool isPaused = false;

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);   // Hide pause button
        Time.timeScale = 0f; // freeze game
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);    // Show pause button
        Time.timeScale = 1f; // resume game
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneLoader.Instance.LoadScene("MainMenu");
    }
}
