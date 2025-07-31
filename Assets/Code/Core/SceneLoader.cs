using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    private bool isLoading = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning($"[SceneLoader] Duplicate found in scene '{gameObject.scene.name}'. Destroying...");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log($"[SceneLoader] Initialized in scene '{gameObject.scene.name}'.");
    }

    public void LoadScene(string sceneName)
    {
        if (isLoading) return;

        isLoading = true;
        Debug.Log($"[SceneLoader] Loading scene: {sceneName}");
        SceneManager.LoadScene(sceneName);
        isLoading = false;
    }
}
