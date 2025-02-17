using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    public static float speedBuffAmount;

    public void BuffSpeed(float speedBuff)
    {
        speedBuffAmount += speedBuff;
    }
}
