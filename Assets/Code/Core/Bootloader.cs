using UnityEngine;

public class Bootloader : MonoBehaviour
{
    [SerializeField] private GameObject gameManagerPrefab;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            Instantiate(gameManagerPrefab);
        }
    }

    private void Start()
    {
        // Delay 1 frame so that SceneLoader and LoadingUI singletons are initialized
        StartCoroutine(LoadMainMenuNextFrame());
    }

    private System.Collections.IEnumerator LoadMainMenuNextFrame()
    {
        yield return null;

        if (SceneLoader.Instance != null)
        {
            SceneLoader.Instance.LoadScene("MainMenu");
        }
        else
        {
            Debug.LogError("SceneLoader.Instance is null!");
        }
    }
}
