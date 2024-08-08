using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int levelIndex)
    {
        // Ensure the scene index or name exists in the build settings
        if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            Debug.LogError("Scene index out of bounds. Ensure the scene is added to the build settings.");
        }
    }
}
