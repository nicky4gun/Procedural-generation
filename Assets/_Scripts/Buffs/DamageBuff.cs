using UnityEngine;

public class DamageBuff : MonoBehaviour
{
    //StandardAttack playerDamage;

    void Start()
    {
        //playerDamage = GameObject.FindGameObjectWithTag("PlayerAttack").GetComponent<StandardAttack>();
    }

    void Activation()
    {
        StandardAttack.BuffDamage();
        Debug.Log("Damage boost");
    }
}