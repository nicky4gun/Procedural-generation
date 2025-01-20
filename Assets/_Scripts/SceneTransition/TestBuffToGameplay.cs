using UnityEngine;
using UnityEngine.SceneManagement;

public class TestBuffToGameplay : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
