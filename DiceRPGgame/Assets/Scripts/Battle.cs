using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public Pawn player, enemy;
    //private float playerHealth, enemyHealth;
    //private float playerDefence, enemyDefence;
    //private float playerHitPeriod, enemyHitPeriod;
    //private float playerDamage, enemyDamage;
    private void Start()
    {
        player = player.GetComponent<Pawn>();
        enemy = player.GetComponent<Pawn>();
    }


}
