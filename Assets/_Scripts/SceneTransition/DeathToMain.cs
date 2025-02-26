using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathToMain : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
