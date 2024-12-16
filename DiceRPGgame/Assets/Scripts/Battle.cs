using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    private GameObject player, target;
    private Pawn playerPawn, targetPawn;
    private bool battleActive;
    //private float playerHealth, enemyHealth;
    //private float playerDefence, enemyDefence;
    //private float playerHitPeriod, enemyHitPeriod;
    //private float playerDamage, enemyDamage;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerPawn = player.GetComponent<Pawn>();
        //target = playerPawn.
    }
    private void Update()
    {
        if (battleActive)
        {
            playerPawn.speed = 0;
            targetPawn.speed = 0;

        }
    }

}
