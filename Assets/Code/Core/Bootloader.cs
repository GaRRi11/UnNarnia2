using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootloader : MonoBehaviour
{
    [SerializeField] private GameObject gameManagerPrefab;

    void Awake()
    {
        // Instantiate manager if not already present
        if (GameManager.Instance == null)
        {
            Instantiate(gameManagerPrefab);
        }

        // You can also instantiate other startup managers here

        // Now load the main menu or game
        SceneManager.LoadScene("MainMenu");
    }
}
