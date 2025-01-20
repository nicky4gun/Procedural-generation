using UnityEngine;

public class DamageBuff : MonoBehaviour
{
    [SerializeField]
    public static int buffAmount;

    public void BoostDamage(int buff)
    {
        buffAmount += buff;
    }
}