using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    public static LoadingUI Instance;

    [SerializeField] private GameObject loadingPanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (loadingPanel != null)
        {
            loadingPanel.SetActive(false); // Hide loading screen on start
        }
        else
        {
            Debug.LogWarning("[LoadingUI] Loading panel is not assigned!");
        }
    }

    public void ShowLoading(bool show)
    {
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(show);
        }
        else
        {
            Debug.LogWarning("[LoadingUI] Cannot show/hide loading panel: reference is missing.");
        }
    }
}
