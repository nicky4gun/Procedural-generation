using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    [SerializeField]
    public static int buffAmount = 0;

    public void BoostHP(int buff)
    {
        buffAmount += buff;
    }
}
