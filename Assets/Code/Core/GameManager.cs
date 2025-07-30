using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // === Global game state ===
    public int CurrentLevel { get; set; } = 1;
    public int CurrentRoom { get; set; } = 1;
    public bool IsRetryingAfterAd { get; set; } = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ResetGameState()
    {
        CurrentLevel = 1;
        CurrentRoom = 1;
        IsRetryingAfterAd = false;
    }
}
