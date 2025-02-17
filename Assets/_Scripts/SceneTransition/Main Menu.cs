using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Options()
    {
        SceneManager.LoadSceneAsync(3);
    }
        
    public void QuitGame()
    {
        Application.Quit();
    }
}
