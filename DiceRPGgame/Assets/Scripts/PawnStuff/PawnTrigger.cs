using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnTrigger : MonoBehaviour
{
    private Pawn parent;
    //private Pawn target;
    private void Start()
    {
        parent = GetComponentInParent<Pawn>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (CompareTag("Player")) // player target
        //{
        //    parent.playerInBattleRange = true;
        //}
        //else
        //{
        //    parent.playerInBattleRange = false;
        //}
        
        if (CompareTag("Enemy")) // enemy target
        {
            parent.enemyInBattleRange = true;
        }
        else
        {
            parent.enemyInBattleRange = false;
        }
        
        //if (CompareTag("h")) // new class target
        //{
            
        //}
        //else
        //{
            
        //}
    }
}
