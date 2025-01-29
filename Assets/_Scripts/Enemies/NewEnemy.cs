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
                
                break;
            case Behavior.Aggresive:
                
                break;
        }
    }
}
