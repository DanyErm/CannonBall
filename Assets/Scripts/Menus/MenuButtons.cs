using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }


    public void Authors()
    {
        SceneManager.LoadScene("AuthorsMenu");
    }


    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}