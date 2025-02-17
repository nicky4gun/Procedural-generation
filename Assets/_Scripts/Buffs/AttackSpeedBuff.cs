using UnityEngine;

public class AttackSpeedBuff : MonoBehaviour
{
    public static float AttackSpeedBuffAmount;

    public void BuffAttackSpeed(float attackSpeedBuff)
    {
        AttackSpeedBuffAmount += attackSpeedBuff;
    }
}
