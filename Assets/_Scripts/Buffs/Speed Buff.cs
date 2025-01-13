using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    PlayerMovement1 playerSpeed;
    PlayerAttack playerAttackspeed;

    void Start()
    {
        playerSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement1>();
        playerAttackspeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    void Activation()
    {
        playerSpeed.SpeedBuff();
        playerAttackspeed.AttackspeedBuff();
    }
}
