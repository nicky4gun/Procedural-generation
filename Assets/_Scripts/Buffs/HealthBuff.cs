using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    public int buffAmount = 0;

    public void BoostHP(int boost)
    {
        buffAmount += boost;
    }
}
