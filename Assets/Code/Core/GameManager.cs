using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    public GameState CurrentState { get; private set; }

    // === Global game state ===
    public int CurrentLevel { get; set; } = 1;
    public int CurrentRoom { get; set; } = 1;
    public bool IsRetryingAfterAd { get; set; } = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning($"[GameManager] Duplicate found in scene '{gameObject.scene.name}'. Destroying...");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log($"[GameManager] Initialized in scene '{gameObject.scene.name}'.");
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                Debug.Log("[GameManager] State changed to: MainMenu");
                break;
            case GameState.Playing:
                Debug.Log("[GameManager] State changed to: Playing");
                break;
            case GameState.Paused:
                Debug.Log("[GameManager] State changed to: Paused");
                break;
            case GameState.GameOver:
                Debug.Log("[GameManager] State changed to: GameOver");
                break;
        }
    }

    public void ResetGameState()
    {
        Debug.Log("[GameManager] Resetting game state.");
        CurrentLevel = 1;
        CurrentRoom = 1;
        IsRetryingAfterAd = false;
    }
}
