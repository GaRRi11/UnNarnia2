using UnityEngine;

public class GameLevelUI : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneLoader.Instance.LoadScene("MainMenu");
    }
}
