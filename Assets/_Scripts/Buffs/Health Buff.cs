using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    Health playerHealth;
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void Activation()
    {
        playerHealth.IncreaseMaxHP();
    }
}
