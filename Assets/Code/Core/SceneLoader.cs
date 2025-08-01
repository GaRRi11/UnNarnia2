using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    private string targetScene;
    private bool isLoading = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log($"[SceneLoader] Initialized in scene '{gameObject.scene.name}'");
    }

    public void LoadScene(string sceneName)
    {
        if (isLoading) return;

        targetScene = sceneName;
        isLoading = true;

        // ✅ First load the loading scene (synchronously)
        SceneManager.LoadScene("LoadingScene");

        // ✅ Then continue async from there
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        // Small delay just to show loading UI clearly
        yield return new WaitForSeconds(0.2f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene);
        asyncLoad.allowSceneActivation = true;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        isLoading = false;
    }
}
