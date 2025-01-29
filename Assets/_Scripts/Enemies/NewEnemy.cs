using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    enum Behavior
    {
        Passive,
        Aggresive
    }
    void Start()
    {
        
    }

    void Update()
    {
        switch( Behavior.Passive )
        {
            case Behavior.Passive:
                checkForPlayer();
                break;
            case Behavior.Aggresive:
                attackPlayer();
                break;
        }
    }
}
