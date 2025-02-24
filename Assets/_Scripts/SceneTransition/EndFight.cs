using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFight : MonoBehaviour
{
    public int enemies;
    public static int clearedStages = 0;

    public void Start()
    {
        enemies = GameObject.FindWithTag("MapGenerator").GetComponent<room_maker>().enemies;
    }

    public void EnemyDied()
    {
        enemies--;

        if (enemies <= 0)
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        clearedStages++;

        SceneManager.LoadSceneAsync(0);
    }
}
