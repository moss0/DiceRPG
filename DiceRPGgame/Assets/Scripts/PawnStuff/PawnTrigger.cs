using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnTrigger : MonoBehaviour
{
    private Pawn parent;
    public GameObject targetInTrigger;
    private void Start()
    {
        parent = GetComponentInParent<Pawn>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            parent.enemyInBattleRange = true;
            targetInTrigger = collision.gameObject;
        }
        //Debug.Log("Enter called");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        parent.enemyInBattleRange = false;
        //Debug.Log("Exit called");
    }

}
