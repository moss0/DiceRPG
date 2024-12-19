using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    private GameObject player, target;
    private Pawn playerPawn, targetPawn;
    public bool battleActive;
    //private float playerHealth, enemyHealth;
    //private float playerDefence, enemyDefence;
    //private float playerHitPeriod, enemyHitPeriod;
    //private float playerDamage, enemyDamage;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerPawn = player.GetComponent<Pawn>();
        target = playerPawn.triggerEnemyRef;
        targetPawn = target.GetComponent<Pawn>();
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
