using UnityEngine;
using UnityEngine.SceneManagement;

public class TestGameplayToBuff : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeScene();
    }
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
