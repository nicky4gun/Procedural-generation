using UnityEngine;
using UnityEngine.SceneManagement;

public class TestGameplayToBuff : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
