using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    public static float speedBuffAmount;
    public static float attackSpeedBuffAmount;

    public void BuffSpeed(float speedBuff)
    {
        speedBuffAmount += speedBuff;
    }
}
