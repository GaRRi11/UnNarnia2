using UnityEngine;

public class LevelSelectionUI : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneLoader.Instance.LoadScene("GameLevel01");
    }

    public void LoadLevel2()
    {
        //SceneLoader.Instance.LoadScene("GameLevel02");
    }

    public void BackToMainManu()
    {
        SceneLoader.Instance.LoadScene("MainMenu");
    }

    // Add more levels as needed
}
