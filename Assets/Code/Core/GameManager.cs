using UnityEngine;
using System;

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

    // Optional: Event when state changes
    public event Action<GameState> OnGameStateChanged;

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
        if (CurrentState == newState)
            return;

        CurrentState = newState;
        Debug.Log($"[GameManager] State changed to: {newState}");

        // Control time scale for certain states
        switch (newState)
        {
            case GameState.MainMenu:
            case GameState.Playing:
                Time.timeScale = 1f;
                break;
            case GameState.Paused:
            case GameState.GameOver:
                Time.timeScale = 0f;
                break;
        }

        OnGameStateChanged?.Invoke(newState); // Optional: Notify listeners
    }

    public void ResetGameState()
    {
        Debug.Log("[GameManager] Resetting game state.");
        CurrentLevel = 1;
        CurrentRoom = 1;
        IsRetryingAfterAd = false;
    }
}
